using MisTest.Common.Page;
using MisTest.Domain.Entities;

namespace MisTest.Domain.Repositories
{
    public interface IDoctorSpecializationRepository
    {
        public Task CreateSpecializationAsync(DoctorSpecializationEntity specializationEntity);
        public Task<PagedResult<DoctorSpecializationEntity>> GetSpecializationsPageAsync(PageParams? pageParams = null);
        public Task<DoctorSpecializationEntity?> GetSpecialization(string name);
        public Task<DoctorSpecializationEntity?> GetSpecialization(Guid id);
        public Task DeleteSpecializationAsync(Guid id);
    }
}
