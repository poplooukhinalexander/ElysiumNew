using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Elysium.Model.Configuration
{
    public class RideConfiguration : IEntityTypeConfiguration<Ride>
    {
        public void Configure(EntityTypeBuilder<Ride> builder)
        {
           builder.HasIndex(_ => new { _.Price, _.CurrencyId });
           builder.Property(_ => _.Price).IsRequired();          
           builder.HasIndex(_ => _.TourId);
           builder.HasIndex(_ => _.CurrencyId);
           builder.HasIndex(_ => _.AvailableTicketNumber);
        }
    }
}
