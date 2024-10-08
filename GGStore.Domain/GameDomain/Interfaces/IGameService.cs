namespace GGStore.Domain.GameDomain.Interfaces;

public interface IGameService
{
    IEnumerable<Game> GetAll();
    Task<GameVM> GetByIdAsync(int id);
    Task<int> AddAsync(GameDto gameDto);
    Task EditAsync(int id, GameDto gameDto);
    Task DeleteAsync(int id);
}