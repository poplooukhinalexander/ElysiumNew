namespace Elysium.Model
{
    public class RoutePoint
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public Guid LocationId { get; set; }
        public virtual Location Location { get; set; } = default!;
        public Guid ScheduleItemId { get; set; }
        public virtual ScheduleItem ScheduleItem { get; set; } = default!;
    }
}
