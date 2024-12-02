using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WattHappens.Infrastructure.Data.Configurations;

public class ApplianceConfiguration : IEntityTypeConfiguration<Appliance>
{
    public void Configure(EntityTypeBuilder<Appliance> builder)
    {
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.Category)
            .IsRequired();
        
        builder.Property(e => e.WattPowerConsumption)
            .IsRequired();
        
        builder.Property(e => e.Note)
            .HasMaxLength(255);
    }
}