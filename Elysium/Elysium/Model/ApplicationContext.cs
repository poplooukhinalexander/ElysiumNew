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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=elysium;Username=elysium;Password=elysium12345");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasIndex(_ => _.Name).IsUnique();
            modelBuilder.Entity<Category>().Property(_ => _.Name).IsRequired().HasMaxLength(50);

            modelBuilder.Entity<Currency>().HasKey(_ => _.Code);
            modelBuilder.Entity<Currency>().Property(_ => _.Code).IsRequired().HasMaxLength(5);
            modelBuilder.Entity<Currency>().Property(_ => _.Name).IsRequired().HasMaxLength(50);

            modelBuilder.Entity<Location>().HasIndex(_ => _.Name);
            modelBuilder.Entity<Location>().HasIndex(_ => new { _.Longitide, _.Latitude })
                .HasFilter("NOT Longitude IS NULL AND NOT Latitude IS NULL");
            modelBuilder.Entity<Location>().Property(_ => _.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Location>().HasIndex(_ => _.RouteId);          
            modelBuilder.Entity<Location>().Property(_ => _.Description).HasMaxLength(250);

            modelBuilder.Entity<Photo>().Property(_ => _.Link).IsRequired().HasMaxLength(512);
            modelBuilder.Entity<Photo>().Property(_ => _.Title).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<Photo>().HasIndex(_ => _.LocationId);     

            modelBuilder.Entity<Provider>().HasIndex(_ => _.Name).IsUnique();
            modelBuilder.Entity<Provider>().Property(_ => _.Name).IsRequired().HasMaxLength(100);            
            modelBuilder.Entity<Provider>().Property(_ => _.Phone).IsRequired().HasMaxLength(15);
            modelBuilder.Entity<Provider>().Property(_ => _.Email).IsRequired().HasMaxLength(256);
            modelBuilder.Entity<Provider>().Property(_ => _.FBId).HasMaxLength(512);
            modelBuilder.Entity<Provider>().Property(_ => _.VKId).HasMaxLength(512);
            modelBuilder.Entity<Provider>().Property(_ => _.InstagramId).HasMaxLength(512);
            modelBuilder.Entity<Provider>().Property(_ => _.Rate).IsRequired().HasDefaultValue(0);
            modelBuilder.Entity<Provider>().HasIndex(_ => _.Rate);

            modelBuilder.Entity<Route>().HasIndex(_ => _.Name);
            modelBuilder.Entity<Route>().Property(_ => _.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Route>().Property(_ => _.Description).HasMaxLength(300);
            modelBuilder.Entity<Route>().Property(_ => _.Difficulty).IsRequired().HasDefaultValue(RouteDifficulty.Medium);
            modelBuilder.Entity<Route>().HasIndex(_ => _.Difficulty);       
            modelBuilder.Entity<Route>().HasIndex(_ => _.DirectionId);            
            modelBuilder.Entity<Route>().HasIndex(_ => _.ProviderId);
            modelBuilder.Entity<Route>().Property(_ => _.VisaMandatory).IsRequired().HasDefaultValue(false);
            modelBuilder.Entity<Route>().Property(_ => _.VisaDetails).HasMaxLength(200);
            modelBuilder.Entity<Route>().Property(_ => _.MainPhotoLink).IsRequired().HasMaxLength(512);
            modelBuilder.Entity<Route>().Property(_ => _.MainPhotoTitle).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<Route>().Property(_ => _.Rate).IsRequired().HasDefaultValue(0);
            modelBuilder.Entity<Route>().HasIndex(_ => _.Rate);

            modelBuilder.Entity<TeamMember>().Property(_ => _.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<TeamMember>().Property(_ => _.PhotoLink).HasMaxLength(512);
            modelBuilder.Entity<TeamMember>().Property(_ => _.Profession).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<TeamMember>().Property(_ => _.Description).HasMaxLength(200);
            modelBuilder.Entity<TeamMember>().Property(_ => _.Email).HasMaxLength(256);
            modelBuilder.Entity<TeamMember>().Property(_ => _.Phone).HasMaxLength(15);

            modelBuilder.Entity<Tour>().HasIndex(_ => new { _.Price, _.CurrencyId });
            modelBuilder.Entity<Tour>().Property(_ => _.Price).IsRequired();
        }
    }
}
