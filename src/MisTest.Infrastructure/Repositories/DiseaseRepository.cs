using Microsoft.EntityFrameworkCore;
using MisTest.Common.Page;
using MisTest.Domain.Entities;
using MisTest.Domain.Repositories;
using MisTest.Infrastructure.Extensions;

namespace MisTest.Infrastructure.Repositories
{
    public class DiseaseRepository : IDiseaseRepository
    {
        private MisTestDbContext _context;

        public DiseaseRepository(MisTestDbContext context)
        {
            _context = context;
        }

        public Task CreateDiseaseAsync(DiseaseEntity diseaseEntity)
        {
            _context.Diseases.Add(diseaseEntity);
            return Task.CompletedTask;
        }

        public async Task DeleteDiseaseAsync(Guid id)
        {
            var disease = await _context.Diseases.FindAsync(id);
            if (disease != null)
            {
                _context.Diseases.Remove(disease);
            }
        }

        public async Task<DiseaseEntity?> GetDisease(string name)
        {
            return await _context.Diseases.AsNoTracking().FirstOrDefaultAsync(s => s.Name == name);
        }

        public async Task<PagedResult<DiseaseEntity>> GetDiseasesPageAsync(PageParams? pageParams = null)
        {
            return await _context.Diseases
                .AsNoTracking()
                .ToPageAsync(pageParams);
        }
    }
}
