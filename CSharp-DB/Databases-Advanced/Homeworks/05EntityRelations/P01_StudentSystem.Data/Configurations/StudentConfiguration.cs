namespace P01_StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Data.Models;

    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> student)
        {
            student
                .Property(s => s.Name)
                .HasMaxLength(100)
                .IsUnicode()
                .IsRequired();

            student
                .Property(s => s.PhoneNumber)
                .HasColumnType("char(10)")
                .IsUnicode(false)
                .IsRequired(false);
        }
    }
}
