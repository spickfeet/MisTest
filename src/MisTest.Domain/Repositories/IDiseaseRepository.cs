using MisTest.Common.Page;
using MisTest.Domain.Entities;

namespace MisTest.Domain.Repositories
{
    public interface IDiseaseRepository
    {
        public Task CreateDiseaseAsync(DiseaseEntity diseaseEntity);
        public Task<PagedResult<DiseaseEntity>> GetDiseasesPageAsync(PageParams? pageParams = null);
        public Task<DiseaseEntity?> GetDisease(string name);
        public Task DeleteDiseaseAsync(Guid id);
    }
}
