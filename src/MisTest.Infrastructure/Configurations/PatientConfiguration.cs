using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MisTest.Domain.Entities;

namespace MisTest.Infrastructure.Configurations
{
    public class PatientConfiguration : IEntityTypeConfiguration<PatientEntity>
    {
        public void Configure(EntityTypeBuilder<PatientEntity> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasIndex(p => p.CardNumber).IsUnique();

            builder
                .HasMany(p => p.DiagnosisEntities)
                .WithOne(d => d.PatientEntity)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
