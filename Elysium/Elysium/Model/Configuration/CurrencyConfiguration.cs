using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Elysium.Model.Configuration
{
    public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.HasKey(_ => _.Code);
            builder.Property(_ => _.Code).IsRequired().HasMaxLength(5);
            builder.Property(_ => _.Name).IsRequired().HasMaxLength(50);
        }
    }
}
