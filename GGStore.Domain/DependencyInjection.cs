using GGStore.Domain.GameDomain;
using GGStore.Domain.GameDomain.Interfaces;
using GGStore.Domain.GenreDomain;
using GGStore.Domain.GenreDomain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GGStore.Domain;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<IGameService, GameService>();
        services.AddTransient<IGenreService, GenreService>();

        return services;
    }
}
