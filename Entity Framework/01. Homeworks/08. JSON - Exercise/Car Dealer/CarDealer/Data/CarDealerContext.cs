using CarDealer.Models;
using Microsoft.EntityFrameworkCore;

namespace CarDealer.Data
{
    public class CarDealerContext : DbContext
    {
        public CarDealerContext(DbContextOptions options)
            : base(options)
        {
        }

        public CarDealerContext()
        {
        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Part> Parts { get; set; }

        public DbSet<PartCar> PartCars { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=DESKTOP-40U9D0R\\SQLEXPRESS;Database=CarDealer;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PartCar>(e =>
            {
                e.HasKey(k => new { k.CarId, k.PartId });

                e.HasOne(c => c.Car)
                .WithMany(pc => pc.PartCars)
                .HasForeignKey(k => k.CarId);

                e.HasOne(p => p.Part)
                .WithMany(pc => pc.PartCars)
                .HasForeignKey(k => k.PartId);
            });
        }
    }
}