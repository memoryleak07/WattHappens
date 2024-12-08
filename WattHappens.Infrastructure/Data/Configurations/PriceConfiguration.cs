using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WattHappens.Infrastructure.Data.Configurations;

public class PriceConfiguration : IEntityTypeConfiguration<Price>
{
    public void Configure(EntityTypeBuilder<Price> builder)
    {
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.ElectricityCost)
            .IsRequired();
    }
}