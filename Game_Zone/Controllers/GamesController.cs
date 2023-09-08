namespace Game_Zone.Controllers;

public class GamesController : Controller
{
    private readonly ICategoryService _categoryService;
    private readonly IDeviceService _deviceService;
    private readonly IGameService _gameServices;

    public GamesController(ICategoryService categoryService,
        IDeviceService deviceService, 
        IGameService gameServices)
    {
        _categoryService = categoryService;
        _deviceService = deviceService;
        _gameServices = gameServices;
    }

    #region Index
    public IActionResult Index()
    {
        //var game = _dbContext.Games.ToList();
        return View();
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
        await _gameServices.Create(model);
        return RedirectToAction(nameof(Index));
    }

    #endregion

    #region Edit

    #endregion

    #region Delete

    #endregion

}
