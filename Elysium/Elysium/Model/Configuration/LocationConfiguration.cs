using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Globalization;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Elysium.Model.Configuration
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasIndex(_ => new { _.Name, _.Region });
            builder.HasIndex(_ => new { _.Region, _.Name });
            builder.HasIndex(_ => new { _.Longitude, _.Latitude });
            builder.Property(_ => _.Name).IsRequired().HasMaxLength(200);
            builder.Property(_ => _.Description).HasMaxLength(250);
            builder.Property(_ => _.Region).HasMaxLength(100);
            builder.Property(_ => _.Country).IsRequired().HasMaxLength(100);
            builder.Property(_ => _.City).HasMaxLength(100);
            builder.Property(_ => _.Street).HasMaxLength(100);
            builder.HasIndex(_ => new { _.Country, _.Region, _.City, _.Street, _.HouseNumber });
            builder.HasIndex(_ => _.Region);
            builder.Property(_ => _.District).HasMaxLength(100);            
        }              
    }
}
