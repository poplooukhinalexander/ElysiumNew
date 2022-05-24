namespace Elysium.Model
{
    public class ScheduleItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public int DayNumber { get; set; } = default!;
        public DateOnly Date { get; set; } = default!;
        public virtual List<Photo> Photos { get; set; } = new List<Photo>();
        public virtual List<RoutePoint> RoutePoints { get; set; } = new List<RoutePoint>();
        public Guid TourId { get; set; }
        public virtual Tour Tour { get; set; } = default!;
    }
}
