namespace TeisterMask.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    public class EmployeeTaskConfiguration : IEntityTypeConfiguration<EmployeeTask>
    {
        public void Configure(EntityTypeBuilder<EmployeeTask> employeeTask)
        {
            employeeTask
                .HasKey(et => new { et.EmployeeId, et.TaskId });

            employeeTask
                .HasOne(et => et.Employee)
                .WithMany(e => e.EmployeesTasks)
                .HasForeignKey(et => et.EmployeeId);

            employeeTask
                .HasOne(et => et.Task)
                .WithMany(t => t.EmployeesTasks)
                .HasForeignKey(et => et.TaskId);
        }
    }
}
