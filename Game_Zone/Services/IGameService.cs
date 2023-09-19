namespace Game_Zone.Services;

public interface IGameService
{
    IEnumerable<Game> GetAll();
    Task Create(CreateGameFormViewModel model);
}
