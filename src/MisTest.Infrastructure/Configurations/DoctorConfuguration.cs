using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MisTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MisTest.Infrastructure.Configurations
{
    public class DoctorConfuguration : IEntityTypeConfiguration<DoctorEntity>
    {
        public void Configure(EntityTypeBuilder<DoctorEntity> builder)
        {
            builder.HasKey(d => d.Id);

            builder
                .HasMany(d => d.DiagnosisEntities)
                .WithOne(d => d.DoctorEntity)
                .HasForeignKey(d => d.DiseaseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(d => d.SpecializationEntity)
                .WithMany(d => d.DoctorEntities)
                .HasForeignKey(d => d.SpecializationId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
