using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DE.Domain.Models;

namespace DE.Persistence.EntityTypeConfigurations;

public class DrillBlockConfiguration : IEntityTypeConfiguration<DrillBlock>
{
    public void Configure(EntityTypeBuilder<DrillBlock> builder)
    {
        builder.HasKey(d => d.Id);

        builder.HasIndex(d => d.Id)
            .IsUnique();

        builder.Property(d => d.Name)
            .IsRequired();

        builder.HasMany(d => d.Holes)
            .WithOne(h => h.DrillBlock)
            .HasForeignKey(h => h.DrillBlockId);

        builder.HasMany(d => d.DrillBlockPoints)
            .WithOne(p => p.DrillBlock)
            .HasForeignKey(p => p.DrillBlockId);
    }
}

