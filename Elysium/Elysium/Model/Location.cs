namespace Elysium.Model
{
    public class Location
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Region { get; set; } = default!;
        public string Country { get; set; } = default!;
        public string? District { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public int? HouseNumber { get; set; }
        public string? Description { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
        public virtual IEnumerable<Photo> Photos { get; set; } = new List<Photo>();
        public virtual IEnumerable<RoutePoint> Points { get; set; } = new List<RoutePoint>();
    }
}
