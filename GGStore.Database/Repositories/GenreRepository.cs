using GGStore.Domain;
using GGStore.Domain.GameDomain;
using GGStore.Domain.GameDomain.Interfaces;
using GGStore.Domain.GenreDomain;
using GGStore.Domain.GenreDomain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GGStore.Database.Repositories;

public class GenreRepository(GGStoreDbContext context) : IGenreRepository
{
    public async Task<int> AddAsync(GenreDto genreDto)
    {
        var games = await context.Games
            .Where(x => genreDto.GameIds.Contains(x.Id))
            .ToListAsync();

        if (genreDto.GameIds.Count != games.Count)
        {
            throw new Exception("Неправильная игра");
        }

        var genre = new Genre
        {
            Title = genreDto.Title,
            Games = games
        };
        await context.AddAsync(genre);
        await context.SaveChangesAsync();

        return genre.Id;
    }

    public async Task DeleteAsync(int id) =>
        await context.Genres
            .Where(genre => genre.Id == id)
            .ExecuteDeleteAsync();

    public async Task EditAsync(int id, GenreDto genreDto)
    {
        var games = await context.Games
            .Where(x => genreDto.GameIds.Contains(x.Id))
            .ToListAsync();

        var editingGenre = await context.Genres
            .Include(x => x.Games)
            .SingleAsync(editing => editing.Id == id);

        editingGenre.Games.Clear();

        editingGenre.Title = genreDto.Title;
        editingGenre.Games = games;

        await context.SaveChangesAsync();
    }

    public IEnumerable<Genre> GetAll() =>
        context.Genres;

    public async Task<Genre> GetByIdAsync(int id) =>
        await context.Genres.SingleAsync(genre => genre.Id == id);
}