namespace P01_StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Data.Models;

    public class ResourceConfiguration : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> resource)
        {
            resource
                .Property(r => r.Name)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

            resource
                .HasIndex(r => r.Url)
                .IsUnique(true);

            resource
                .Property(r => r.Url)
                .IsUnicode(false)
                .IsRequired();

            resource
                .HasOne(r => r.Course)
                .WithMany(c => c.Resources)
                .HasForeignKey(r => r.CourseId);
        }
    }
}
