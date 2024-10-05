using GGStore.Domain.GenreDomain.Interfaces;

namespace GGStore.Domain.GenreDomain;

public class GenreService(IGenreRepository genereRepository) : IGenreService 
{
    public Task<int> AddAsync(GenreDto genreDto) =>
        genereRepository.AddAsync(genreDto);

    public Task DeleteAsync(int id) =>
        genereRepository.DeleteAsync(id);

    public Task EditAsync(int id, GenreDto genreDto) =>
        genereRepository.EditAsync(id, genreDto);

    public IEnumerable<Genre> GetAll() =>
        genereRepository.GetAll();

    public Task<Genre> GetByIdAsync(int id) =>
         genereRepository.GetByIdAsync(id);
}