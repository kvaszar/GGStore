using GGStore.Domain.GameDomain;

namespace GGStore.Domain.GenreDomain.Interfaces;

public interface IGenreRepository 
{
    IEnumerable<Genre> GetAll();
    Task<Genre> GetByIdAsync(int id);
    Task<int> AddAsync(GenreDto genreDto);
    Task EditAsync(int id, GenreDto genreDto);
    Task DeleteAsync(int id);
}