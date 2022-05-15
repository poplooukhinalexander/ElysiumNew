namespace Elysium.Model
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public DateTime? ArchivedAt { get; set; }
        public virtual List<Route> Routes { get; set; } = new List<Route>();
    }
}
