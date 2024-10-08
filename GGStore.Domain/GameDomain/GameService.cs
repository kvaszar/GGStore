using AutoMapper;
using GGStore.Domain.GameDomain.Interfaces;

namespace GGStore.Domain.GameDomain;

public class GameService(IMapper mapper, IGameRepository gameRepository) : IGameService
{
    public Task<int> AddAsync(GameDto gameDto) =>
        gameRepository.AddAsync(gameDto);

    public Task DeleteAsync(int id) =>
        gameRepository.DeleteAsync(id);

    public Task EditAsync(int id, GameDto gameDto) =>
        gameRepository.EditAsync(id, gameDto);

    public IEnumerable<Game> GetAll() =>
        gameRepository.GetAll();

    public async Task<GameVM> GetByIdAsync(int id)
    {
        var game = await gameRepository.GetByIdAsync(id);
        var gameVM = mapper.Map<GameVM>(game);

        return gameVM;
    }
}