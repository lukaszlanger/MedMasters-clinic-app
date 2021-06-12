using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Klinika.Models
{
    public partial class masterContext : DbContext
    {
        public masterContext()
        {
        }

        public masterContext(DbContextOptions<masterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DoctorSpecializations> DoctorSpecializations { get; set; }
        public virtual DbSet<DoctorsReferals> DoctorsReferals { get; set; }
        public virtual DbSet<MedicalSpecializations> MedicalSpecializations { get; set; }
        public virtual DbSet<Medicines> Medicines { get; set; }
        public virtual DbSet<Patients> Patients { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Visits> Visits { get; set; }
        public virtual DbSet<Workers> Workers { get; set; }
        public virtual DbSet<WorkingDays> WorkingDays { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MEDMasters;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DoctorSpecializations>(entity =>
            {
                entity.HasKey(e => e.IdDoctorSpecialization);

                entity.ToTable("Doctor_specializations");

                entity.HasIndex(e => e.DoctorId);

                entity.HasIndex(e => e.SpecializationId);

                entity.Property(e => e.IdDoctorSpecialization).HasColumnName("IdDoctor_specialization");

                entity.Property(e => e.DoctorId).HasColumnName("Doctor_id");

                entity.Property(e => e.SpecializationId).HasColumnName("Specialization_id");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.DoctorSpecializations)
                    .HasForeignKey(d => d.DoctorId);

                entity.HasOne(d => d.Specialization)
                    .WithMany(p => p.DoctorSpecializations)
                    .HasForeignKey(d => d.SpecializationId);
            });

            modelBuilder.Entity<DoctorsReferals>(entity =>
            {
                entity.HasKey(e => e.IdReferal);

                entity.ToTable("Doctors_referals");

                entity.HasIndex(e => e.VisitId);

                entity.Property(e => e.DateOfIssue).HasColumnName("Date_of_issue");

                entity.Property(e => e.ExpirationDay).HasColumnName("Expiration_day");

                entity.Property(e => e.VisitId).HasColumnName("Visit_id");

                entity.HasOne(d => d.Visit)
                    .WithMany(p => p.DoctorsReferals)
                    .HasForeignKey(d => d.VisitId);
            });

            modelBuilder.Entity<MedicalSpecializations>(entity =>
            {
                entity.HasKey(e => e.IdSpecialization);

                entity.ToTable("Medical_specializations");

                entity.Property(e => e.SpecializationName).HasColumnName("Specialization_name");
            });

            modelBuilder.Entity<Medicines>(entity =>
            {
                entity.HasKey(e => e.IdMedicine);

                entity.HasIndex(e => e.VisitId);

                entity.Property(e => e.DateOfIssue).HasColumnName("Date_of_issue");

                entity.Property(e => e.ExpirationDay).HasColumnName("Expiration_day");

                entity.Property(e => e.MedicineName).HasColumnName("Medicine_name");

                entity.Property(e => e.VisitId).HasColumnName("Visit_id");

                entity.HasOne(d => d.Visit)
                    .WithMany(p => p.Medicines)
                    .HasForeignKey(d => d.VisitId);
            });

            modelBuilder.Entity<Patients>(entity =>
            {
                entity.HasKey(e => e.Pesel);

                entity.Property(e => e.BuildingNumber).HasColumnName("Building_number");

                entity.Property(e => e.CityOfBirth).HasColumnName("City_of_birth");

                entity.Property(e => e.DateOfBirth).HasColumnName("Date_of_birth");

                entity.Property(e => e.DateOfDeath).HasColumnName("Date_of_death");

                entity.Property(e => e.FlatNumber).HasColumnName("Flat_number");

                entity.Property(e => e.MaidenName).HasColumnName("Maiden_name");

                entity.Property(e => e.PhoneNumber).HasColumnName("Phone_number");

                entity.Property(e => e.SecondForename).HasColumnName("Second_forename");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.IdRole);

                entity.Property(e => e.RoleName).HasColumnName("Role_name");
            });

            modelBuilder.Entity<Visits>(entity =>
            {
                entity.HasKey(e => e.IdVisit);

                entity.HasIndex(e => e.DoctorId);

                entity.HasIndex(e => e.PatientId);

                entity.Property(e => e.DoctorId).HasColumnName("Doctor_id");

                entity.Property(e => e.PatientId).HasColumnName("Patient_id");

                entity.Property(e => e.VisitsDescription).HasColumnName("Visits_description");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Visits)
                    .HasForeignKey(d => d.DoctorId);

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Visits)
                    .HasForeignKey(d => d.PatientId);
            });

            modelBuilder.Entity<Workers>(entity =>
            {
                entity.HasKey(e => e.IdWorker);

                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).HasColumnName("Role_id");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Workers)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<WorkingDays>(entity =>
            {
                entity.HasKey(e => e.IdWorkingDay);

                entity.ToTable("Working_days");

                entity.HasIndex(e => e.WorkerId);

                entity.Property(e => e.TimeEnd).HasColumnName("Time_end");

                entity.Property(e => e.TimeStart).HasColumnName("Time_start");

                entity.Property(e => e.WorkerId).HasColumnName("Worker_id");

                entity.HasOne(d => d.Worker)
                    .WithMany(p => p.WorkingDays)
                    .HasForeignKey(d => d.WorkerId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
