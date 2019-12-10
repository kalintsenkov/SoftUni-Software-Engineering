namespace TeisterMask.Data
{
    using Microsoft.EntityFrameworkCore;

    using Models;

    public class TeisterMaskContext : DbContext
    {
        public TeisterMaskContext()
        {
        }

        public TeisterMaskContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Task> Tasks { get; set; }

        public DbSet<EmployeeTask> EmployeesTasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
            => builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }
}