namespace P03_FootballBetting.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> team)
        {
            team
                .Property(t => t.Name)
                .HasMaxLength(20)
                .IsUnicode()
                .IsRequired();

            team
                .HasIndex(t => t.LogoUrl)
                .IsUnique();

            team
                .Property(t => t.LogoUrl)
                .IsUnicode(false)
                .IsRequired();

            team
                .Property(t => t.Initials)
                .HasColumnType("char(3)")
                .IsUnicode()
                .IsRequired();

            team
                .HasOne(t => t.Town)
                .WithMany(t => t.Teams)
                .HasForeignKey(t => t.TownId);

            team
                .HasOne(t => t.PrimaryKitColor)
                .WithMany(c => c.PrimaryKitTeams)
                .HasForeignKey(t => t.PrimaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

            team
                .HasOne(t => t.SecondaryKitColor)
                .WithMany(c => c.SecondaryKitTeams)
                .HasForeignKey(t => t.SecondaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
