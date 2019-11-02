namespace P03_SalesDatabase.Data
{
    using Microsoft.EntityFrameworkCore;

    using Models;

    public class SalesContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<Sale> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.CreateProductModel(modelBuilder);
            this.CreateCustomerModel(modelBuilder);
            this.CreateStoreModel(modelBuilder);
            this.CreateSaleModel(modelBuilder);
        }

        private void CreateSaleModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Sale>()
                .Property(s => s.Date)
                .HasDefaultValueSql("getdate()");

            modelBuilder
                .Entity<Sale>()
                .HasOne(s => s.Product)
                .WithMany(p => p.Sales)
                .HasForeignKey(s => s.ProductId)
                .IsRequired(true);

            modelBuilder
                .Entity<Sale>()
                .HasOne(s => s.Customer)
                .WithMany(c => c.Sales)
                .HasForeignKey(s => s.CustomerId)
                .IsRequired(true);

            modelBuilder
                .Entity<Sale>()
                .HasOne(s => s.Store)
                .WithMany(st => st.Sales)
                .HasForeignKey(s => s.StoreId)
                .IsRequired(true);
        }

        private void CreateStoreModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Store>()
                .Property(s => s.Name)
                .HasMaxLength(80)
                .IsUnicode(true)
                .IsRequired(true);

            modelBuilder
                .Entity<Store>()
                .HasMany(st => st.Sales)
                .WithOne(s => s.Store)
                .HasForeignKey(s => s.StoreId);
        }

        private void CreateCustomerModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Customer>()
                .Property(c => c.Name)
                .HasMaxLength(100)
                .IsUnicode(true)
                .IsRequired(true);

            modelBuilder
                .Entity<Customer>()
                .Property(c => c.Email)
                .HasMaxLength(80)
                .IsUnicode(false);

            modelBuilder
                .Entity<Customer>()
                .Property(c => c.CreditCardNumber)
                .IsRequired(true);

            modelBuilder
                .Entity<Customer>()
                .HasMany(c => c.Sales)
                .WithOne(s => s.Customer)
                .HasForeignKey(s => s.CustomerId);
        }

        private void CreateProductModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Product>()
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsUnicode(true)
                .IsRequired(true);

            modelBuilder
                .Entity<Product>()
                .Property(p => p.Quantity)
                .IsRequired(true);

            modelBuilder
               .Entity<Product>()
               .Property(p => p.Price)
               .IsRequired(true);

            modelBuilder
               .Entity<Product>()
               .Property(p => p.Description)
               .HasMaxLength(250)
               .IsUnicode(true)
               .HasDefaultValue("No description");

            modelBuilder
               .Entity<Product>()
               .HasMany(p => p.Sales)
               .WithOne(s => s.Product)
               .HasForeignKey(s => s.ProductId);
        }
    }
}
