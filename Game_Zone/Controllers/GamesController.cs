namespace Game_Zone.Controllers;

public class GamesController : Controller
{
    private readonly ICategoryService _categoryService;
    private readonly IDeviceService _deviceService;
    private readonly IGameService _gameService;

    public GamesController(ICategoryService categoryService,
        IDeviceService deviceService, 
        IGameService gameService)
    {
        _categoryService = categoryService;
        _deviceService = deviceService;
        _gameService = gameService;
    }

    #region Index
    public IActionResult Index()
    {
        var game = _gameService.GetAll();
        return View(game);
    }
    #endregion

    #region Details
    public IActionResult Details(int id)
    {
        var game = _gameService.GetById(id);
        if (game is null)
            return NotFound();
        return View(game);
    } 
    #endregion

    #region Create
    [HttpGet]
    public IActionResult Create()
    {
        CreateGameFormViewModel viewModel = new()
        {
            Categories = _categoryService.GetSelectListCategory() ,
            Devices = _deviceService.GetSelectListsDevice() ,
        };
        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateGameFormViewModel model)
    {
        if (!ModelState.IsValid)
        {
            model.Categories = _categoryService.GetSelectListCategory();
            model.Devices = _deviceService.GetSelectListsDevice();
            return View(model);
        }
        await _gameService.Create(model);
        return RedirectToAction(nameof(Index));
    }

    #endregion

    #region Edit
    [HttpGet]
    public IActionResult Edit(int id)
    {
        //if (id.ToString() == null)
        //    return BadRequest();
        var game = _gameService.GetById(id);

        if (game is null)
            return NotFound();

        EditGameFormViewModel viewModel = new()
        {
            Id = id,
            Name = game.Name,
            Description = game.Description,
            CategoryId = game.CategoryId,
            SelectedDevices = game.Devices.Select(d=>d.DeviceId).ToList(),
            Categories = _categoryService.GetSelectListCategory(),
            Devices = _deviceService.GetSelectListsDevice(),
            CurrentCover = game.Cover,
        };
        return View(viewModel);
    }
    #endregion

    #region Delete

    #endregion

}
