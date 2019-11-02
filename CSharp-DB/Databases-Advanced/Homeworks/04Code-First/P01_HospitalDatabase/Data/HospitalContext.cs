namespace P01_HospitalDatabase.Data
{
    using Microsoft.EntityFrameworkCore;

    using Models;

    public class HospitalContext : DbContext
    {
        public HospitalContext()
        {
        }

        public HospitalContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Visitation> Visitations { get; set; }

        public DbSet<Diagnose> Diagnoses { get; set; }

        public DbSet<Medicament> Medicaments { get; set; }

        public DbSet<PatientMedicament> PatientsMedicaments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.CreatePatientModel(modelBuilder);
            this.CreateVisitationModel(modelBuilder);
            this.CreateDiagnoseModel(modelBuilder);
            this.CreateMedicamentModel(modelBuilder);
            this.CreatePatientMedicamentModel(modelBuilder);
            this.CreateDoctorModel(modelBuilder);
        }

        private void CreateDoctorModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Doctor>()
                .Property(d => d.Name)
                .HasMaxLength(100)
                .IsUnicode(true)
                .IsRequired(true);

            modelBuilder
                .Entity<Doctor>()
                .Property(d => d.Specialty)
                .HasMaxLength(100)
                .IsUnicode(true)
                .IsRequired(true);

            modelBuilder
                .Entity<Doctor>()
                .HasMany(d => d.Visitations)
                .WithOne(v => v.Doctor)
                .HasForeignKey(v => v.DoctorId);
        }

        private void CreatePatientMedicamentModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<PatientMedicament>()
                .HasKey(k => new { k.PatientId, k.MedicamentId });

            modelBuilder
                .Entity<PatientMedicament>()
                .HasOne(p => p.Patient)
                .WithMany(pm => pm.Prescriptions)
                .HasForeignKey(f => f.PatientId);

            modelBuilder
                .Entity<PatientMedicament>()
                .HasOne(p => p.Medicament)
                .WithMany(pm => pm.Prescriptions)
                .HasForeignKey(f => f.MedicamentId);
        }

        private void CreateMedicamentModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Medicament>()
                .Property(n => n.Name)
                .HasMaxLength(50)
                .IsUnicode(true);
        }

        private void CreateDiagnoseModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Diagnose>()
                .Property(n => n.Name)
                .HasMaxLength(50)
                .IsUnicode(true);

            modelBuilder
                .Entity<Diagnose>()
                .Property(c => c.Comments)
                .HasMaxLength(250)
                .IsUnicode(true);

            modelBuilder
                .Entity<Diagnose>()
                .HasOne(p => p.Patient)
                .WithMany(d => d.Diagnoses)
                .HasForeignKey(f => f.PatientId);
        }

        private void CreateVisitationModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Visitation>()
                .Property(c => c.Comments)
                .HasMaxLength(250)
                .IsUnicode(true);

            modelBuilder
                .Entity<Visitation>()
                .HasOne(p => p.Patient)
                .WithMany(v => v.Visitations)
                .HasForeignKey(f => f.PatientId);

            modelBuilder
                .Entity<Visitation>()
                .HasOne(v => v.Doctor)
                .WithMany(d => d.Visitations)
                .HasForeignKey(v => v.DoctorId);
        }

        private void CreatePatientModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Patient>()
                .Property(x => x.FirstName)
                .HasMaxLength(50)
                .IsUnicode(true);

            modelBuilder
                .Entity<Patient>()
                .Property(x => x.LastName)
                .HasMaxLength(50)
                .IsUnicode(true);

            modelBuilder
               .Entity<Patient>()
               .Property(x => x.Address)
               .HasMaxLength(250)
               .IsUnicode(true);

            modelBuilder
               .Entity<Patient>()
               .Property(x => x.Email)
               .HasMaxLength(250)
               .IsUnicode(false);

            modelBuilder
                .Entity<Patient>()
                .HasMany(v => v.Visitations)
                .WithOne(p => p.Patient)
                .HasForeignKey(f => f.PatientId);

            modelBuilder
               .Entity<Patient>()
               .HasMany(v => v.Diagnoses)
               .WithOne(p => p.Patient)
               .HasForeignKey(f => f.PatientId);
        }
    }
}
