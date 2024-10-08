using GGStore.Domain;
using GGStore.Domain.GameDomain;
using GGStore.Domain.GameDomain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GGStore.Database.Repositories;

public class GameRepository(GGStoreDbContext context) : IGameRepository
{
    public async Task<int> AddAsync(GameDto gameDto)
    {
        var genres = await context.Genres
            .Where(x => gameDto.IdGenres.Contains(x.Id))
            .ToListAsync();

        if (gameDto.IdGenres.Count != genres.Count)
        {
            throw new Exception("Неправильный жанр");
        }

        var game = new Game
        {
            Title = gameDto.Title,
            Description = gameDto.Description,
            Genres = genres,
            Publisher = gameDto.Publisher,
            DateRelease = gameDto.DateRelease,
        };

        await context.AddAsync(game);
        await context.SaveChangesAsync();

        return game.Id;
    }

    public async Task DeleteAsync(int id) =>
        await context.Games
        .Where(game => game.Id == id)
        .ExecuteDeleteAsync();

    public async Task EditAsync(int id, GameDto gameDto)
    {
        var genres = await context.Genres
           .Where(x => gameDto.IdGenres.Contains(x.Id))
           .ToListAsync();

        var editingGame = await context.Games
            .Include(x => x.Genres)
            .SingleAsync(editing => editing.Id == id);

        editingGame.Genres.Clear();

        editingGame.Title = gameDto.Title;
        editingGame.Description = gameDto.Description;
        editingGame.Genres = genres;
        editingGame.Publisher = gameDto.Publisher;
        editingGame.DateRelease = gameDto.DateRelease;

        await context.SaveChangesAsync();
    }

    public IEnumerable<Game> GetAll() =>
        context.Games.Include(x => x.Genres);

    public async Task<Game> GetByIdAsync(int id) =>
        await context.Games.Include(x => x.Genres).SingleAsync(game => game.Id == id);
}