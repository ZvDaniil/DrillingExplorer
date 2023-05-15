using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DE.Domain.Models;

namespace DE.Persistence.EntityTypeConfigurations;

public class DrillBlockPointConfiguration : IEntityTypeConfiguration<DrillBlockPoint>
{
    public void Configure(EntityTypeBuilder<DrillBlockPoint> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Sequence)
            .IsRequired();

        builder.Property(p => p.X)
            .IsRequired();

        builder.Property(p => p.Y)
            .IsRequired();

        builder.Property(p => p.Z)
            .IsRequired();

        builder.HasOne(p => p.DrillBlock)
            .WithMany(b => b.DrillBlockPoints)
            .HasForeignKey(p => p.DrillBlockId);
    }
}

