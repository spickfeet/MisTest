using MisTest.Common.Page;
using MisTest.Domain.Entities;

namespace MisTest.Domain.Repositories
{
    public interface IPatientRepository
    {
        public Task CreatePatientAsync(PatientEntity patientEntity);
        public Task<PagedResult<PatientEntity>> GetPatientsPageAsync(PageParams? pageParams);
        public Task<PatientEntity?> GetPatientAsync(string сardNumber);
        public Task DeletePatientAsync(Guid id);
    }
}
