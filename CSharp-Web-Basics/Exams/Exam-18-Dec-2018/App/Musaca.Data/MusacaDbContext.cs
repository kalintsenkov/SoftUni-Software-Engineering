namespace Musaca.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class MusacaDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<ProductOrder> ProductsOrders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(DataSettings.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>()
                .Property(p => p.Name)
                .HasMaxLength(10)
                .IsRequired();

            builder.Entity<Order>()
                .HasOne(o => o.Cashier)
                .WithMany(c => c.Orders)
                .IsRequired()
                .HasForeignKey(o => o.CashierId);

            builder.Entity<ProductOrder>(productOrder =>
            {
                productOrder
                    .HasKey(po => new { po.ProductId, po.OrderId });

                productOrder
                    .HasOne(po => po.Product)
                    .WithMany(p => p.Orders)
                    .IsRequired()
                    .HasForeignKey(po => po.ProductId);

                productOrder
                    .HasOne(po => po.Order)
                    .WithMany(p => p.Products)
                    .IsRequired()
                    .HasForeignKey(po => po.OrderId);
            });
        }
    }
}
