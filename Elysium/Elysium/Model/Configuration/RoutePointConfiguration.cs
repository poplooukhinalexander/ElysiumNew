using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Elysium.Model.Configuration
{
    public class RoutePointConfiguration : IEntityTypeConfiguration<RoutePoint>
    {
        public void Configure(EntityTypeBuilder<RoutePoint> builder)
        {
            builder.Property(_ => _.Description).HasMaxLength(300);
            builder.HasIndex(_ => _.LocationId);
            builder.HasIndex(_ => _.ScheduleItemId);
        }
    }
}
