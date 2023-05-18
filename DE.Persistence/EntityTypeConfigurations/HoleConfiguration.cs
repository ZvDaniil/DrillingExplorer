using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DE.Domain.Models;
using System.Reflection.Emit;

namespace DE.Persistence.EntityTypeConfigurations;

internal class HoleConfiguration : IEntityTypeConfiguration<Hole>
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

        builder.Property(h => h.HolePointId)
            .IsRequired(false);

        builder.HasOne(h => h.DrillBlock)
            .WithMany(b => b.Holes)
            .HasForeignKey(h => h.DrillBlockId);

        builder.HasOne(h => h.HolePoint)
            .WithOne(hp => hp.Hole)
            .HasForeignKey<HolePoint>(hp => hp.HoleId);

        builder.Navigation(h => h.HolePoint)
            .AutoInclude();
    }
}

