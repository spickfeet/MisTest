using Microsoft.EntityFrameworkCore;
using MisTest.Domain.Entities;
using MisTest.Infrastructure.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

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
            modelBuilder.ApplyConfiguration(new DoctorConfuguration());
            modelBuilder.ApplyConfiguration(new DoctorSpecializationConfiguration());
            modelBuilder.ApplyConfiguration(new PatientConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
