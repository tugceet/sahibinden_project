using Microsoft.EntityFrameworkCore;

namespace sahibinden_project;

public class SahibindenDbContext : DbContext
{
    public SahibindenDbContext(DbContextOptions<SahibindenDbContext> options) : base(options){ }

    public DbSet<User> Users => Set<User>();
    public DbSet<Listing> Listings => Set<Listing>();
    public DbSet<Ikinci_ElListing> Ikinci_ElListings => Set<Ikinci_ElListing>();
    public DbSet<CarListing> CarListings => Set<CarListing>();
    public DbSet<PropertyListing> PropertyListings => Set<PropertyListing>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=sahibinden.db");
            }
        }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(u => u.Id);
        modelBuilder.Entity<Listing>().HasKey(q => q.Id);
    }
}
