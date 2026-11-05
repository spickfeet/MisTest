using MisTest.Common.Filters;
using MisTest.Common.Page;
using MisTest.Domain.Entities;

namespace MisTest.Domain.Repositories
{
    public interface IDoctorRepository
    {
        public Task CreateDoctorAsync(DoctorEntity doctorEntity);
        public Task <PagedResult<DoctorEntity>> GetDoctorsPageAsync(PageParams? pageParams = null, DoctorFilterParams? filter = null);
        public Task DeleteDoctorAsync(Guid id);
    }
}
