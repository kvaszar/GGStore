using AutoMapper;
using GGStore.Domain.GameDomain;
using GGStore.Domain.GenreDomain;

namespace GGStore;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Game, GameVM>()
            .ForMember(x => x.Title, y => y.MapFrom(x => x.Title))
            .ForMember(x => x.Description, y => y.MapFrom(x => x.Description))
            .ForMember(x => x.Genres, y => y.MapFrom(x => x.Genres))
            .ForMember(x => x.Publisher, y => y.MapFrom(x => x.Publisher))
            .ForMember(x => x.DateRelease, y => y.MapFrom(x => x.DateRelease));

        CreateMap<Genre, GenreVM>();
    }
}