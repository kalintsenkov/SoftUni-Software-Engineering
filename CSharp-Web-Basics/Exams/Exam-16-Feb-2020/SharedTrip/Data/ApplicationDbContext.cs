namespace SharedTrip.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Trip> Trips { get; set; }

        public DbSet<UserTrip> UsersTrips { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);

            builder.UseSqlServer(DatabaseConfiguration.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Trip>(trip =>
            {
                trip
                    .Property(t => t.StartPoint)
                    .IsRequired();

                trip
                    .Property(t => t.EndPoint)
                    .IsRequired();

                trip
                    .Property(t => t.Description)
                    .HasMaxLength(80)
                    .IsRequired();
            });

            builder.Entity<UserTrip>(userTrip =>
            {
                userTrip
                    .HasKey(ut => new { ut.UserId, ut.TripId });

                userTrip
                    .HasOne(ut => ut.User)
                    .WithMany(u => u.Trips)
                    .IsRequired()
                    .HasForeignKey(ut => ut.UserId);

                userTrip
                    .HasOne(ut => ut.Trip)
                    .WithMany(t => t.Users)
                    .IsRequired()
                    .HasForeignKey(ut => ut.TripId);
            });
        }
    }
}
