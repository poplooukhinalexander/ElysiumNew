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
        public DbSet<Tour> Tours { get; set; } = default!;
        public DbSet<TeamMember> TeamMembers { get; set; } = default!; 
        public DbSet<Ride> Rides { get; set; } = default!;
        public DbSet<ScheduleItem> ScheduleItems { get; set; } = default!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=elysium;Username=postgres;Password=flame2005");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }
        
    }
}
