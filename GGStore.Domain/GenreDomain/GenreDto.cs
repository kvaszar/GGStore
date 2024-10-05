using GGStore.Domain.GameDomain;

namespace GGStore.Domain.GenreDomain;

public class GenreDto
{
    public required string Title { get; set; }
    public required List<int> GameIds { get; set; }
}