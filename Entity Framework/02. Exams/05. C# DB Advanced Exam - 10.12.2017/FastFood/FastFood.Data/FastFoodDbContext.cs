using FastFood.Models;
using FastFood.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace FastFood.Data
{
    public class FastFoodDbContext : DbContext
    {
        public FastFoodDbContext()
        {
        }

        public FastFoodDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Position> Positions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Position>()
                .HasIndex(p => p.Name)
                .IsUnique();

            builder.Entity<Item>()
                .HasIndex(p => p.Name)
                .IsUnique();

            builder.Entity<Order>()
                .Property(p => p.Type)
                .HasDefaultValue(OrderType.ForHere);

            builder.Entity<OrderItem>()
                .HasKey(k => new { k.ItemId, k.OrderId });
        }
    }
}