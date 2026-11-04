using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MisTest.Domain.Entities;

namespace MisTest.Infrastructure.Configurations
{
    public class DoctorSpecializationConfiguration : IEntityTypeConfiguration<DoctorSpecializationEntity>
    {
        public void Configure(EntityTypeBuilder<DoctorSpecializationEntity> builder)
        {
            builder.HasKey(s => s.Id);
            builder.HasIndex(s => s.Name).IsUnique();

            builder
                .HasMany(s => s.DoctorEntities)
                .WithOne(d => d.SpecializationEntity)
                .HasForeignKey(d => d.SpecializationId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
