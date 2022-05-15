namespace Elysium.Model
{
    public class Currency
    {
        public string Code { get; set; } = default!;
        public string Name { get; set; } = default!;     
        public virtual List<Tour> Tours { get; set; } = new List<Tour>();
    }
}
