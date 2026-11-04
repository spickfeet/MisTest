using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MisTest.Domain.Entities;

namespace MisTest.Infrastructure.Configurations
{
    public class DiseaseConfiguration : IEntityTypeConfiguration<DiseaseEntity>
    {
        public void Configure(EntityTypeBuilder<DiseaseEntity> builder)
        {
            builder.HasKey(d => d.Id);

            builder.HasIndex(d => d.Name).IsUnique();

            builder
                .HasMany(d => d.DiagnosisEntities)
                .WithOne(d => d.DiseaseEntity)
                .HasForeignKey(d => d.DiseaseId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
