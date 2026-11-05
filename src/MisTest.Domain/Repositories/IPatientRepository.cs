using MisTest.Common.Page;
using MisTest.Domain.Entities;

namespace MisTest.Domain.Repositories
{
    public interface IPatientRepository
    {
        public Task CreatePatientAsync(PatientEntity patientEntity);
        public Task<PagedResult<PatientEntity>> GetPatientsPageAsync(PageParams? pageParams = null);
        public Task<PatientEntity?> GetPatientAsync(string cardNumber);
        public Task DeletePatientAsync(Guid id);
    }
}
