using Microsoft.EntityFrameworkCore;
using DE.Domain.Models;
using DE.Application.Interfaces;
using DE.Persistence.EntityTypeConfigurations;

namespace DE.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public DbSet<DrillBlock> DrillBlocks { get; set; }
    public DbSet<DrillBlockPoint> DrillBlockPoints { get; set; }

    public DbSet<Hole> Holes { get; set; }
    public DbSet<HolePoint> HolePoints { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder
            .ApplyConfiguration(new DrillBlockConfiguration())
            .ApplyConfiguration(new DrillBlockPointConfiguration())
            .ApplyConfiguration(new HoleConfiguration())
            .ApplyConfiguration(new HolePointConfiguration());

        base.OnModelCreating(builder);
    }
}
