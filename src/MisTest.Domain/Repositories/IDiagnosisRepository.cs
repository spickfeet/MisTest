using MisTest.Domain.Entities;
using MisTest.Common.Filters;
using MisTest.Common;
using MisTest.Common.Page;

namespace MisTest.Domain.Repositories
{
    public interface IDiagnosisRepository
    {
        public Task CreateDiagnosisAsync(DiagnosisEntity diagnosisEntity);
        public Task<PagedResult<DiagnosisEntity>> GetDiagnosesPageAsync(PageParams? pageParams, DiagnosisFilterParams? filter);
        public Task DeleteDiagnosisAsync(Guid id);
    }
}
