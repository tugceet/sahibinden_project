using Microsoft.EntityFrameworkCore;

namespace sahibinden_project;

public class SahibindenDbContext : DbContext
{
    public SahibindenDbContext(DbContextOptions<SahibindenDbContext> options) : base(options){ }

    public DbSet<User>? Users => Set<User>();
    public DbSet<Listing>? Listings => Set<Listing>();

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
