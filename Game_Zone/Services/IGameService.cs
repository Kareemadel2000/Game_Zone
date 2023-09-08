namespace Game_Zone.Services;

public interface IGameService
{
    Task Create(CreateGameFormViewModel model);
}
