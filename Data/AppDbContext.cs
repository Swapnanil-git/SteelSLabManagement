using Microsoft.EntityFrameworkCore;
using SteelSlabManagement.Models; // Replace with your models' namespace

namespace SteelSlabManagement.Data // Replace with your namespace
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<Production> Production { get; set; } = null!;
        public DbSet<Inventory> Inventory { get; set; } = null!;
        public DbSet<QualityCheck> QualityChecks { get; set; } = null!;
        public DbSet<Shipping> Shipping { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Set default schema to 'vax'
            modelBuilder.HasDefaultSchema("vax");
        }
    }
}
