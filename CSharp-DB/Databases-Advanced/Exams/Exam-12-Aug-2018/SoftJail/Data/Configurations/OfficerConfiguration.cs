namespace SoftJail.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    public class OfficerConfiguration : IEntityTypeConfiguration<Officer>
    {
        public void Configure(EntityTypeBuilder<Officer> officer)
        {
            officer
                .HasOne(o => o.Department)
                .WithMany(d => d.Officers)
                .HasForeignKey(o => o.DepartmentId);
        }
    }
}
