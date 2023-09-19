namespace Game_Zone.Services;

public interface IGameService
{
    IEnumerable<Game> GetAll();
    Game? GetById(int id);
    Task Create(CreateGameFormViewModel model);
}
