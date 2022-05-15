namespace Elysium.Model
{
    public class Photo
    {
        public Guid Id { get; set; }
        public string Link { get; set; } = default!;
        public string Title { get; set; } = default!;
        public Guid LocationId { get; set; }
        public virtual Location Location { get; set; } = default!;
        public DateTime? ArchivedAt { get; set; }
    }
}
