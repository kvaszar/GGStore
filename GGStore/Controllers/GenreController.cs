using GGStore.Domain.GameDomain;
using GGStore.Domain.GameDomain.Interfaces;
using GGStore.Domain.GenreDomain;
using GGStore.Domain.GenreDomain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GGStore.Controllers;

[ApiController]
[Route("[controller]")]
public class GenreController(IGenreService genreService) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Genre>> Get()
    {
        var genres = genreService.GetAll();
        return Ok(genres);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Genre>> GetDetails(int id)
    {
        var game = await genreService.GetByIdAsync(id);
        return Ok(game);
    }

    [HttpPost]
    public async Task<ActionResult<int>> AddGenre([FromBody] GenreDto genreDto)
    {
        var addedId = await genreService.AddAsync(genreDto);
        return Ok(addedId);
    }

    [HttpPut]
    public async Task<ActionResult> EditGenre(int id, [FromBody] GenreDto genreDto)
    {
        await genreService.EditAsync(id, genreDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteGenre(int id)
    {
        await genreService.DeleteAsync(id);
        return NoContent();
    }
}