namespace Elysium.Model
{
    public class Route
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public virtual List<Category> Categories { get; set; } = new List<Category>();
        public RouteDifficulty Difficulty { get; set; } = RouteDifficulty.Medium;
        public Guid LocationId { get; set; }
        public virtual Location Location { get; set; } = default!;
        public virtual List<RoutePoint> Points { get; set; } = new List<RoutePoint>();
        public Guid ProviderId { get; set; }
        public virtual Provider Provider { get; set; } = default!;
        public virtual List<Tour> Tours { get; set; } = new List<Tour>();
        public bool VisaMandatory { get; set; } = false;
        public string? VisaDetails { get; set;}
        public DateOnly? ArchivedAt { get; set; }
        public string MainPhotoLink { get; set; } = default!;
        public string MainPhotoTitle { get; set; } = default!;
        public int Rate { get; set; } = 0;
    }
}
