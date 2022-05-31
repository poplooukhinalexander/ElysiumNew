using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Elysium.Model.Configuration
{
    public class TourConfiguration : IEntityTypeConfiguration<Tour>
    {
        public void Configure(EntityTypeBuilder<Tour> builder)
        {
            builder.HasIndex(_ => _.Name);
            builder.Property(_ => _.Name).IsRequired().HasMaxLength(100);
            builder.Property(_ => _.ShortDescription).IsRequired().HasMaxLength(200);
            builder.Property(_ => _.DetailedDescription).IsRequired().HasMaxLength(500);            
            builder.HasIndex(_ => _.Difficulty);
            builder.HasIndex(_ => _.DirectionId);
            builder.HasIndex(_ => _.MeetPointId);
            builder.HasIndex(_ => _.ProviderId);
            builder.Property(_ => _.VisaMandatory).IsRequired().HasDefaultValue(false);
            builder.Property(_ => _.VisaDetails).HasMaxLength(200);
            builder.Property(_ => _.MainPhotoLink).IsRequired().HasMaxLength(512);
            builder.Property(_ => _.MainPhotoTitle).IsRequired().HasMaxLength(200);
            builder.Property(_ => _.Popularity).IsRequired().HasDefaultValue(0);
            builder.HasIndex(_ => _.Popularity);
            builder.HasIndex(_ => _.IsActive);
            builder.Property(_ => _.TransferDetails).IsRequired().HasMaxLength(300);
            builder.Property(_ => _.ParticipateTerms).IsRequired().HasMaxLength(200);
        }
    }
}
