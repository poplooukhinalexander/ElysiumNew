using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Elysium.Model.Configuration
{
    public class TourConfiguration : IEntityTypeConfiguration<Tour>
    {
        public void Configure(EntityTypeBuilder<Tour> builder)
        {
           builder.HasIndex(_ => new { _.Price, _.CurrencyId });
           builder.Property(_ => _.Price).IsRequired();
           builder.HasIndex(_ => _.MeetPointId);
           builder.HasIndex(_ => _.RouteId);
           builder.HasIndex(_ => _.CurrencyId);
           builder.HasIndex(_ => _.AvailableTicketNumber);
        }
    }
}
