namespace SULS.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class SULSContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Problem> Problems { get; set; }

        public DbSet<Submission> Submissions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(DataSettings.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Problem>()
                .Property(p => p.Name)
                .HasMaxLength(20)
                .IsRequired();

            builder.Entity<Submission>(submission =>
            {
                submission
                    .Property(s => s.Code)
                    .HasMaxLength(800)
                    .IsRequired();

                submission
                    .HasOne(s => s.Problem)
                    .WithMany(p => p.Submissions)
                    .IsRequired()
                    .HasForeignKey(s => s.ProblemId);

                submission
                    .HasOne(s => s.User)
                    .WithMany(u => u.Submissions)
                    .IsRequired()
                    .HasForeignKey(s => s.UserId);
            });
        }
    }
}