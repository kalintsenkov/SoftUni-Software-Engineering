namespace SoftJail.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    public class PrisonerConfiguration : IEntityTypeConfiguration<Prisoner>
    {
        public void Configure(EntityTypeBuilder<Prisoner> prisoner)
        {
            prisoner
                .HasOne(p => p.Cell)
                .WithMany(c => c.Prisoners)
                .HasForeignKey(p => p.CellId);
        }
    }
}
