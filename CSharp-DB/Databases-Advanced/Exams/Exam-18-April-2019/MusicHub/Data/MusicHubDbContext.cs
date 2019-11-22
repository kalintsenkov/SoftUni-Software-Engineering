namespace MusicHub.Data
{
    using Microsoft.EntityFrameworkCore;

    using Models;

    public class MusicHubDbContext : DbContext
    {
        public MusicHubDbContext()
        {
        }

        public MusicHubDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Writer> Writers { get; set; }

        public DbSet<Producer> Producers { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Song> Songs { get; set; }

        public DbSet<Performer> Performers { get; set; }

        public DbSet<SongPerformer> SongsPerformers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Song>(song =>
            {
                song
                    .HasOne(s => s.Album)
                    .WithMany(a => a.Songs)
                    .HasForeignKey(s => s.AlbumId);

                song
                    .HasOne(s => s.Writer)
                    .WithMany(w => w.Songs)
                    .HasForeignKey(s => s.WriterId);
            });

            builder.Entity<Album>(album =>
            {
                album
                    .HasOne(a => a.Producer)
                    .WithMany(p => p.Albums)
                    .HasForeignKey(a => a.ProducerId);
            });

            builder.Entity<SongPerformer>(songPerformer =>
            {
                songPerformer
                    .HasKey(sp => new { sp.SongId, sp.PerformerId });

                songPerformer
                    .HasOne(sp => sp.Song)
                    .WithMany(s => s.SongPerformers)
                    .HasForeignKey(sp => sp.SongId);

                songPerformer
                    .HasOne(sp => sp.Performer)
                    .WithMany(p => p.PerformerSongs)
                    .HasForeignKey(sp => sp.PerformerId);
            });
        }
    }
}
