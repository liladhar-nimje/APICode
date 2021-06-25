using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PatientsApi.Models
{
    public partial class MedqbitersContext : DbContext
    {
        public MedqbitersContext()
        {
        }

        public MedqbitersContext(DbContextOptions<MedqbitersContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DefaultRate> DefaultRates { get; set; }
        public virtual DbSet<HealthDetail> HealthDetails { get; set; }
        public virtual DbSet<IndustryStandard> IndustryStandards { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<SuggestedAction> SuggestedActions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=Medqbiters;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<DefaultRate>(entity =>
            {
                entity.ToTable("DefaultRate");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<HealthDetail>(entity =>
            {
                entity.ToTable("HealthDetail");

                entity.HasIndex(e => e.HealthDetailId, "IX_HealthDetail");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.HealthDetails)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HealthDetail_Patient");
            });

            modelBuilder.Entity<IndustryStandard>(entity =>
            {
                entity.ToTable("IndustryStandard");

                entity.Property(e => e.Action)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Bits)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Scenario)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("Patient");

                entity.Property(e => e.Address).HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<SuggestedAction>(entity =>
            {
                entity.ToTable("SuggestedAction");

                entity.Property(e => e.Action)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.HealthDetail)
                    .WithMany(p => p.SuggestedActions)
                    .HasForeignKey(d => d.HealthDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SuggestedAction_HealthDetail");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
