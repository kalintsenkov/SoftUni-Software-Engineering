namespace P01_StudentSystem.Data
{
    using System;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Data.Models;

    public class HomeworkConfiguration : IEntityTypeConfiguration<Homework>
    {
        public void Configure(EntityTypeBuilder<Homework> homework)
        {
            homework
                .Property(h => h.Content)
                .IsUnicode(false)
                .IsRequired();

            homework
                .Property(h => h.SubmissionTime)
                .HasDefaultValue(DateTime.UtcNow);

            homework
                .HasOne(h => h.Student)
                .WithMany(s => s.HomeworkSubmissions)
                .HasForeignKey(h => h.StudentId);

            homework
                .HasOne(h => h.Course)
                .WithMany(c => c.HomeworkSubmissions)
                .HasForeignKey(h => h.CourseId);
        }
    }
}
