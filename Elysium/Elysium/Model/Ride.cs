namespace Elysium.Model
{
    public class Ride
    {
        public Guid Id { get; set; }        
        public DateOnly StartedAt { get; set; } = default!;
        public DateOnly EndedAt { get; set; } = default!;
        public DateTime? ArchivedAt { get; set; }             
        public Guid TourId { get; set; }
        public virtual Tour Tour { get; set; } = default!;       
        public double Price { get; set; } = default!;
        public Guid CurrencyId { get; set; }
        public virtual Currency Currency { get; set; } = default!;
        public int TicketNumber { get; set; } = default!;
        public int AvailableTicketNumber { get; set; } = default!;
    }
}
