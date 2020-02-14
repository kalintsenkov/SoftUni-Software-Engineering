namespace IRunes.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class RunesDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Track> Tracks { get; set; }

        public DbSet<Album> Albums { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(DataSettings.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Track>(track =>
            {
                track
                    .Property(t => t.Name)
                    .HasMaxLength(20)
                    .IsRequired();

                track
                    .Property(t => t.Link)
                    .IsRequired();

                track
                    .HasOne(t => t.Album)
                    .WithMany(a => a.Tracks)
                    .IsRequired()
                    .HasForeignKey(t => t.AlbumId);
            });

            builder.Entity<Album>(album =>
            {
                album
                    .Property(a => a.Name)
                    .HasMaxLength(20)
                    .IsRequired();

                album
                    .Property(a => a.Cover)
                    .IsRequired();
            });
        }
    }
}
