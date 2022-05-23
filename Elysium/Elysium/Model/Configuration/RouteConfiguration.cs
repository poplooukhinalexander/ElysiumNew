using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Elysium.Model.Configuration
{
    public class RouteConfiguration : IEntityTypeConfiguration<Route>
    {
        public void Configure(EntityTypeBuilder<Route> builder)
        {
            builder.HasIndex(_ => _.Name);
            builder.Property(_ => _.Name).IsRequired().HasMaxLength(100);
            builder.Property(_ => _.Description).HasMaxLength(300);
            builder.Property(_ => _.Difficulty).IsRequired().HasDefaultValue(RouteDifficulty.Medium);
            builder.HasIndex(_ => _.Difficulty);
            builder.HasIndex(_ => _.LocationId);
            builder.HasIndex(_ => _.ProviderId);
            builder.Property(_ => _.VisaMandatory).IsRequired().HasDefaultValue(false);
            builder.Property(_ => _.VisaDetails).HasMaxLength(200);
            builder.Property(_ => _.MainPhotoLink).IsRequired().HasMaxLength(512);
            builder.Property(_ => _.MainPhotoTitle).IsRequired().HasMaxLength(200);
            builder.Property(_ => _.Rate).IsRequired().HasDefaultValue(0);
            builder.HasIndex(_ => _.Rate);
        }
    }
}
