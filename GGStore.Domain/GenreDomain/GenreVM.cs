using AutoMapper;
using GGStore.Domain.GameDomain;

namespace GGStore.Domain.GenreDomain;

public class GenreVM
{
    public int Id { get; set; }
    public required string Title { get; set; }
}