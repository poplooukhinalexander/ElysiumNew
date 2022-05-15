namespace Elysium.Model
{
    public class Tour
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public DateOnly StartedAt { get; set; } = default!;
        public DateOnly EndedAt { get; set; } = default!;
        public DateTime? ArchivedAt { get; set; }     
        public string MeetPoint { get; set; } = default!;
        public Guid RouteId { get; set; }
        public virtual Route Route { get; set; } = default!;        
        public virtual List<TeamMember> TeamMembers { get; set; } = new List<TeamMember>();  
        public double Price { get; set; } = default!;
        public Guid CurrencyId { get; set; }
        public virtual Currency Currency { get; set; } = default!;
    }
}
