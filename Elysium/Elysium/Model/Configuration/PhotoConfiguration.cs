using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Elysium.Model.Configuration
{
    public class PhotoConfiguration : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.Property(_ => _.Link).IsRequired().HasMaxLength(512);
            builder.Property(_ => _.Title).IsRequired().HasMaxLength(200);
            builder.HasIndex(_ => _.ScheduleItemId);
        }
    }
}
