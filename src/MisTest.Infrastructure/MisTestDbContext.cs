using Microsoft.EntityFrameworkCore;
using MisTest.Domain.Entities;
using MisTest.Infrastructure.Configurations;

namespace MisTest.Infrastructure
{
    public class MisTestDbContext : DbContext
    {
        public DbSet<DiagnosisEntity> Diagnoses { get; set; }
        public DbSet<DiseaseEntity> Diseases { get; set; }
        public DbSet<DoctorEntity> Doctors { get; set; }
        public DbSet<DoctorSpecializationEntity> DoctorSpecialization { get; set; }
        public DbSet<PatientEntity> Patients { get; set; }

        public MisTestDbContext(DbContextOptions<MisTestDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DiagnosisConfiguration());
            modelBuilder.ApplyConfiguration(new DiseaseConfiguration());
            modelBuilder.ApplyConfiguration(new DoctorConfiguration());
            modelBuilder.ApplyConfiguration(new DoctorSpecializationConfiguration());
            modelBuilder.ApplyConfiguration(new PatientConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
