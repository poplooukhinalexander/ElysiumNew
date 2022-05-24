using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Elysium.Model.Configuration
{
    public class ScheduleItemConfiguration : IEntityTypeConfiguration<ScheduleItem>
    {
        public void Configure(EntityTypeBuilder<ScheduleItem> builder)
        {
            builder.Property(_ => _.Name).IsRequired().HasMaxLength(100);
            builder.Property(_ => _.Description).IsRequired().HasMaxLength(300);
            builder.HasIndex(_ => _.DayNumber);
            builder.HasIndex(_ => _.TourId);
        }
    }
}
