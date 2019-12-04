namespace Cinema.Data
{
    using Microsoft.EntityFrameworkCore;

    using Models;

    public class CinemaContext : DbContext
    {
        public CinemaContext()  
        { 
        }

        public CinemaContext(DbContextOptions options)
            : base(options)   
        { 
        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Hall> Halls { get; set; }

        public DbSet<Seat> Seats { get; set; }

        public DbSet<Projection> Projections { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
            => builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }
}