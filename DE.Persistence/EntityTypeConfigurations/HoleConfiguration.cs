using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DE.Domain.Models;

namespace DE.Persistence.EntityTypeConfigurations;

public class HoleConfiguration : IEntityTypeConfiguration<Hole>
{
    public void Configure(EntityTypeBuilder<Hole> builder)
    {
        builder.HasKey(h => h.Id);

        builder.HasIndex(h => h.Id)
            .IsUnique();

        builder.Property(h => h.Name)
            .IsRequired();

        builder.Property(h => h.Depth)
            .IsRequired();

        builder.HasOne(h => h.DrillBlock)
            .WithMany(b => b.Holes)
            .HasForeignKey(h => h.DrillBlockId);

        builder.HasMany(h => h.HolePoints)
            .WithOne(hp => hp.Hole)
            .HasForeignKey(hp => hp.HoleId);
    }
}

