namespace Elysium.Model
{
    public class Location
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public double? Longitide { get; set; }
        public double? Latitude { get; set; }
        public virtual IEnumerable<Photo> Photos { get; set; } = new List<Photo>();
        public Guid RouteId { get; set; }
        public virtual Route Route { get; set; } = default!;
    }
}
