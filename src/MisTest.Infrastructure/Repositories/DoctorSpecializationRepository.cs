using Microsoft.EntityFrameworkCore;
using MisTest.Common.Page;
using MisTest.Domain.Entities;
using MisTest.Domain.Repositories;
using MisTest.Infrastructure.Extensions;

namespace MisTest.Infrastructure.Repositories
{
    public class DoctorSpecializationRepository : IDoctorSpecializationRepository
    {
        private MisTestDbContext _context;

        public DoctorSpecializationRepository(MisTestDbContext context)
        {
            _context = context;
        }

        public Task CreateSpecializationAsync(DoctorSpecializationEntity diseaseEntity)
        {
            _context.DoctorSpecialization.Add(diseaseEntity);
            return Task.CompletedTask;
        }

        public async Task DeleteSpecializationAsync(Guid id)
        {
            var specialization = await _context.DoctorSpecialization.FindAsync(id);
            if (specialization != null)
            {
                _context.DoctorSpecialization.Remove(specialization);
            }
        }

        public async Task<PagedResult<DoctorSpecializationEntity>> GetSpecializationsPageAsync(PageParams? pageParams = null)
        {
            return await _context.DoctorSpecialization
                .AsNoTracking().ToPageAsync(pageParams);
        }

        public async Task<DoctorSpecializationEntity?> GetSpecialization(string name)
        {
            return await _context.DoctorSpecialization.AsNoTracking().FirstOrDefaultAsync(s => s.Name == name);
        }
    }
}
