namespace P01_HospitalDatabase.Data
{
    using Microsoft.EntityFrameworkCore;
    using P01_HospitalDatabase.Data.Models;

    public class HospitalContext : DbContext
    {
        public DbSet<Diagnose> Diagnoses { get; set; }

        public DbSet<Medicament> Medicaments { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<PatientMedicament> PatientsMedicaments { get; set; }

        public DbSet<Visitation> Visitations { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigurationOnDiagnose(modelBuilder);
            ConfigurationOnMedicament(modelBuilder);
            ConfigurationOnPatient(modelBuilder);
            ConfigurationOnVisitation(modelBuilder);
            ConfigurationOnPatientsMedicaments(modelBuilder);
            ConfigurtionOnDoctors(modelBuilder);
        }

        private void ConfigurtionOnDoctors(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Doctor>()
                .HasKey(k => k.DoctorId);

            modelBuilder
                .Entity<Doctor>()
                .Property(p => p.Name)
                .HasMaxLength(100)
                .IsUnicode();

            modelBuilder
                .Entity<Doctor>()
                .Property(p => p.Specialty)
                .HasMaxLength(100)
                .IsUnicode();
        }

        private void ConfigurationOnPatientsMedicaments(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<PatientMedicament>()
                .HasKey(k => new { k.MedicamentId, k.PatientId });

            modelBuilder
                .Entity<PatientMedicament>()
                .HasOne(p => p.Patient)
                .WithMany(pm => pm.Prescriptions)
                .HasForeignKey(k => k.PatientId);

            modelBuilder
                .Entity<PatientMedicament>()
                .HasOne(p => p.Medicament)
                .WithMany(pm => pm.Prescriptions)
                .HasForeignKey(k => k.MedicamentId);
        }

        private void ConfigurationOnVisitation(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Visitation>()
                .HasKey(k => k.VisitationId);

            modelBuilder
               .Entity<Visitation>()
               .Property(p => p.Comments)
               .HasMaxLength(250)
               .IsUnicode();

            modelBuilder
                .Entity<Visitation>()
                .HasOne(p => p.Patient)
                .WithMany(v => v.Visitations)
                .HasForeignKey(k => k.PatientId);
        }

        private void ConfigurationOnPatient(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Patient>()
                .HasKey(k => k.PatientId);

            modelBuilder
                .Entity<Patient>()
                .Property(p => p.FirstName)
                .HasMaxLength(50)
                .IsUnicode();

            modelBuilder
               .Entity<Patient>()
               .Property(p => p.LastName)
               .HasMaxLength(50)
               .IsUnicode();

            modelBuilder
               .Entity<Patient>()
               .Property(p => p.Address)
               .HasMaxLength(250)
               .IsUnicode();

            modelBuilder
               .Entity<Patient>()
               .Property(p => p.Email)
               .HasMaxLength(80);

            modelBuilder
               .Entity<Patient>()
               .Property(p => p.HasInsurance);

            modelBuilder
                .Entity<Patient>()
                .HasMany(p => p.Prescriptions)
                .WithOne(p => p.Patient)
                .HasForeignKey(k => k.PatientId);

            modelBuilder
                .Entity<Patient>()
                .HasMany(p => p.Diagnoses)
                .WithOne(p => p.Patient)
                .HasForeignKey(k => k.DiagnoseId);

            modelBuilder
                .Entity<Patient>()
                .HasMany(p => p.Visitations)
                .WithOne(p => p.Patient)
                .HasForeignKey(k => k.VisitationId);
        }

        private void ConfigurationOnMedicament(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Medicament>()
                .HasKey(k => k.MedicamentId);

            modelBuilder
                .Entity<Medicament>()
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsUnicode();

            modelBuilder
                .Entity<Medicament>()
                .HasMany(p => p.Prescriptions)
                .WithOne(m => m.Medicament)
                .HasForeignKey(k => k.MedicamentId);
        }

        private static void ConfigurationOnDiagnose(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Diagnose>()
                .HasKey(k => k.DiagnoseId);

            modelBuilder
                .Entity<Diagnose>()
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsUnicode();

            modelBuilder
               .Entity<Diagnose>()
               .Property(p => p.Comments)
               .HasMaxLength(250)
               .IsUnicode();

            modelBuilder
                .Entity<Diagnose>()
                .HasOne(p => p.Patient)
                .WithMany(d => d.Diagnoses)
                .HasForeignKey(k => k.PatientId);
        }
    }
}