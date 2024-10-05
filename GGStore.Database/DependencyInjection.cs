using GGStore.Domain.GameDomain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using GGStore.Database.Repositories;
using GGStore.Domain.GenreDomain;
using GGStore.Domain.GenreDomain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace GGStore.Database;

public static class DependencyInjection
{
    public static IServiceCollection AddDbDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<GGStoreDbContext>(options =>
          options.UseSqlite(configuration.GetConnectionString("GGStoreDbConnection")));

        services.AddTransient<IGameRepository, GameRepository>();
        services.AddTransient<IGenreRepository, GenreRepository>();

        return services;
    }
}