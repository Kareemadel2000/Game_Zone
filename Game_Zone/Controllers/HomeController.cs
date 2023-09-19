namespace Game_Zone.Controllers;

public class HomeController : Controller
{
    private readonly IGameService _gameService;

    public HomeController(IGameService gameService)
    {
        _gameService = gameService;
    }

    public IActionResult Index()
    {
        var game = _gameService.GetAll();
        return View(game);
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
