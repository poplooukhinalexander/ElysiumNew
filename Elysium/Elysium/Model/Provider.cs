namespace Elysium.Model
{
    public class Provider
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Phone { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string? FBId { get; set; }
        public string? VKId { get; set; }
        public string? InstagramId { get; set; }
        public int Rate { get; set; } = 0;
        public virtual List<Ride> Tours { get; set; } = new List<Ride>();
    }
}
