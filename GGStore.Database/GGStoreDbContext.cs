using GGStore.Domain;
using GGStore.Database.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;
using GGStore.Domain.GameDomain;
using GGStore.Domain.GenreDomain;

namespace GGStore.Database;

public class GGStoreDbContext(DbContextOptions<GGStoreDbContext> options) : DbContext(options)
{
    public DbSet<Game> Games { get; set; }
    public DbSet<Genre> Genres { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new GameConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}