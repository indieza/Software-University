namespace P03_SalesDatabase.Data
{
    using Microsoft.EntityFrameworkCore;
    using P03_SalesDatabase.Data.Models;

    public class SalesContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<Store> Stores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigurationOnCustomer(modelBuilder);
            ConfigurationOnStore(modelBuilder);
            ConfigurationOnProduct(modelBuilder);
            ConfigurationOnSale(modelBuilder);
        }

        private void ConfigurationOnSale(ModelBuilder modelBuilder)
        {
            modelBuilder
               .Entity<Sale>()
               .HasKey(k => k.SaleId);

            modelBuilder
                .Entity<Sale>()
                .Property(p => p.Date)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder
                .Entity<Sale>()
                .HasOne(p => p.Product)
                .WithMany(s => s.Sales)
                .HasForeignKey(p => p.ProductId);

            modelBuilder
                .Entity<Sale>()
                .HasOne(p => p.Customer)
                .WithMany(s => s.Sales)
                .HasForeignKey(p => p.CustomerId);

            modelBuilder
                .Entity<Sale>()
                .HasOne(p => p.Store)
                .WithMany(s => s.Sales)
                .HasForeignKey(p => p.StoreId);
        }

        private void ConfigurationOnProduct(ModelBuilder modelBuilder)
        {
            modelBuilder
               .Entity<Product>()
               .HasKey(k => k.ProductId);

            modelBuilder
                .Entity<Product>()
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsUnicode();

            modelBuilder
                .Entity<Product>()
                .Property(p => p.Description)
                .HasMaxLength(250)
                .IsUnicode();

            modelBuilder
                .Entity<Product>()
                .Property(p => p.Quantity);

            modelBuilder
                .Entity<Product>()
                .Property(p => p.Price);

            modelBuilder
               .Entity<Product>()
               .HasMany(p => p.Sales)
               .WithOne(s => s.Product)
               .HasForeignKey(k => k.ProductId);
        }

        private void ConfigurationOnStore(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Store>()
                .HasKey(k => k.StoreId);

            modelBuilder
                .Entity<Customer>()
                .Property(p => p.Name)
                .HasMaxLength(80)
                .IsUnicode();

            modelBuilder
                .Entity<Store>()
                .HasMany(p => p.Sales)
                .WithOne(s => s.Store)
                .HasForeignKey(k => k.StoreId);
        }

        private void ConfigurationOnCustomer(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Customer>()
                .HasKey(k => k.CustomerId);

            modelBuilder
                .Entity<Customer>()
                .Property(p => p.Name)
                .HasMaxLength(100)
                .IsUnicode();

            modelBuilder
                .Entity<Customer>()
                .Property(p => p.Name)
                .HasMaxLength(80);

            modelBuilder
                .Entity<Customer>()
                .Property(p => p.CreditCardNumber);

            modelBuilder
                .Entity<Customer>()
                .HasMany(p => p.Sales)
                .WithOne(s => s.Customer)
                .HasForeignKey(k => k.CustomerId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.ConnectionString);
        }
    }
}