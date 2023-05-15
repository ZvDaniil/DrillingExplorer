using Microsoft.EntityFrameworkCore;
using DE.Domain.Models;

namespace DE.Application.Interfaces;

public interface IApplicationDbContext
{
    public DbSet<DrillBlock> DrillBlocks { get; set; }
    public DbSet<DrillBlockPoint> DrillBlockPoints { get; set; }

    public DbSet<Hole> Holes { get; set; }
    public DbSet<HolePoint> HolePoints { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}