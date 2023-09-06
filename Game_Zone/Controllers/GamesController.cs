namespace Game_Zone.Controllers;

public class GamesController : Controller
{
    private readonly ICategoryService _categoryService;
    private readonly IDeviceService _deviceService;

    public GamesController(ICategoryService categoryService, IDeviceService deviceService)
    {
        _categoryService = categoryService;
        _deviceService = deviceService;
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
    public IActionResult Create(CreateGameFormViewModel model)
    {
        if (!ModelState.IsValid)
        {
            model.Categories = _categoryService.GetSelectListCategory();
            model.Devices = _deviceService.GetSelectListsDevice();
            return View(model);
        }
        return RedirectToAction(nameof(Index));
    }

    #endregion

    #region Edit

    #endregion

    #region Delete

    #endregion

}
