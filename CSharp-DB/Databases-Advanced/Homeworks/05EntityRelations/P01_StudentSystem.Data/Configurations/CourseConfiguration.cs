namespace P01_StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Data.Models;

    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> course)
        {
            course
                .Property(c => c.Name)
                .HasMaxLength(80)
                .IsUnicode()
                .IsRequired();

            course
                .Property(c => c.Description)
                .IsUnicode()
                .IsRequired(false);
        }
    }
}
