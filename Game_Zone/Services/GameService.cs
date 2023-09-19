
namespace Game_Zone.Services;

public class GameService : IGameService
{
    private readonly ApplicationDBContext _dbContext;
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly string _imagesPath;

    public GameService(ApplicationDBContext dbContext,
        IWebHostEnvironment webHostEnvironment)
    {
        _dbContext = dbContext;
        _webHostEnvironment = webHostEnvironment;
        _imagesPath = $"{_webHostEnvironment.WebRootPath}{FileSettingImage.ImagesPath}";
    }
    public IEnumerable<Game> GetAll()
    {
        return _dbContext.Games
            .Include(g=> g.Category)
            .Include(g=> g.Devices)
            .ThenInclude(d=>d.Device)
            .AsNoTracking()
            .ToList();
       
    }

    public Game? GetById(int id)
    {
        return _dbContext.Games
            .Include(g => g.Category)
            .Include(g => g.Devices)
            .ThenInclude(d => d.Device)
            .AsNoTracking()
            .SingleOrDefault(g=>g.Id== id);

    }
    public async Task Create(CreateGameFormViewModel model)
    {
        var coverName = $"{Guid.NewGuid()}{Path.GetExtension(model.Cover.FileName)}";
        var path = Path.Combine(_imagesPath, coverName);

        using var stream = File.Create(path);
        await model.Cover.CopyToAsync(stream);
     

        Game game = new()
        {
            Name = model.Name,
            Description = model.Description,
            CategoryId = model.CategoryId,
            Cover = coverName,
            Devices = model.SelectedDevices.Select(d => new GameDevice { DeviceId = d }).ToList()
        };
        _dbContext.Add(game);
        _dbContext.SaveChanges();
    }

  
}
