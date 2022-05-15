using Microsoft.EntityFrameworkCore;

namespace Elysium.Model
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Category> Categories { get; set; } = default!;
        public DbSet<Currency> Currencies { get; set; } = default!;
        public DbSet<Location> Locations { get; set; } = default!;
        public DbSet<Photo> Photos { get; set; } = default!;
        public DbSet<Provider> Proviers { get; set; } = default!;
        public DbSet<Route> Routes { get; set; } = default!;
        public DbSet<TeamMember> TeamMembers { get; set; } = default!; 
        public DbSet<Tour> Tours { get; set; } = default!;
    }
}
