using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MisTest.Domain.Entities;

namespace MisTest.Infrastructure.Configurations
{
    public class DiagnosisConfiguration : IEntityTypeConfiguration<DiagnosisEntity>
    {
        public void Configure(EntityTypeBuilder<DiagnosisEntity> builder)
        {
            builder.HasKey(d => d.Id);

            builder
                .HasOne(d => d.DiseaseEntity)
                .WithMany(d => d.DiagnosisEntities)
                .HasForeignKey(d => d.DiseaseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(d => d.PatientEntity)
                .WithMany(d => d.DiagnosisEntities)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(d => d.DoctorEntity)
                .WithMany(d => d.DiagnosisEntities)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
