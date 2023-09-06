using Game_Zone.ViewModels;

namespace Game_Zone.Controllers;

public class GamesController : Controller
{
    private readonly ApplicationDBContext _dbContext;

    public GamesController(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
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
            Categories = _dbContext.Categories
            .Select(c => new SelectListItem { Value = c.Id.ToString() ,Text=c.Name})
            .OrderBy(c=>c.Text)
            .ToList()
        };
        return View(viewModel);
    }

    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public IActionResult Create(ApplicationDBConte)
    //{

    //    return View();
    //}

    #endregion

    #region Edit

    #endregion

    #region Delete

    #endregion

}
