namespace Elysium.Model
{
    public class TeamMember
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string? PhotoLink { get; set; }
        public string Profession { get; set; } = default!; 
        public string? Description { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public virtual List<Tour> Tours { get; set; } = new List<Tour>();
    }
}
