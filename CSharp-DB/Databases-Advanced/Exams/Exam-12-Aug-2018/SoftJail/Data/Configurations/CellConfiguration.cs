namespace SoftJail.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    public class CellConfiguration : IEntityTypeConfiguration<Cell>
    {
        public void Configure(EntityTypeBuilder<Cell> cell)
        {
            cell
                .HasOne(c => c.Department)
                .WithMany(d => d.Cells)
                .HasForeignKey(c => c.DepartmentId);
        }
    }
}
