namespace VaporStore.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> game)
        {
            game
                .HasOne(g => g.Developer)
                .WithMany(d => d.Games)
                .HasForeignKey(g => g.DeveloperId);

            game
                .HasOne(g => g.Genre)
                .WithMany(g => g.Games)
                .HasForeignKey(g => g.GenreId);
        }
    }
}
