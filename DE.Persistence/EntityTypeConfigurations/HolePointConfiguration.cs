using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DE.Domain.Models;

namespace DE.Persistence.EntityTypeConfigurations;

internal class HolePointConfiguration : IEntityTypeConfiguration<HolePoint>
{
    public void Configure(EntityTypeBuilder<HolePoint> builder)
    {
        builder.HasKey(hp => hp.Id);

        builder.Property(hp => hp.X)
            .IsRequired();

        builder.Property(hp => hp.Y)
            .IsRequired();

        builder.Property(hp => hp.Z)
            .IsRequired();

        builder.HasOne(hp => hp.Hole)
            .WithOne(h => h.HolePoint)
            .HasForeignKey<Hole>(h => h.HolePointId);
    }
}
