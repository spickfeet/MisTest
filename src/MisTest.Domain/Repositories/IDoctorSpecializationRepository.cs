using MisTest.Common;
using MisTest.Common.Filters;
using MisTest.Common.Page;
using MisTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MisTest.Domain.Repositories
{
    public interface IDoctorSpecializationRepository
    {
        public Task CreateSpecializationAsync(DoctorSpecializationEntity specializationEntity);
        public Task<PagedResult<DoctorSpecializationEntity>> GetSpecializationsPageAsync(PageParams? pageParams);
        public Task<DoctorSpecializationEntity?> GetSpecialization(string name);
        public Task DeleteSpecializationAsync(Guid id);
    }
}
