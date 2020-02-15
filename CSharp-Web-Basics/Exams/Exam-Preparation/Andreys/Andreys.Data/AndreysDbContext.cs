namespace Andreys.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class AndreysDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(DataSettings.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>(product =>
            {
                product
                    .Property(p => p.Name)
                    .HasMaxLength(20)
                    .IsRequired();

                product
                    .Property(p => p.Description)
                    .HasMaxLength(10);
            });
        }
    }
}