using MisTest.Common;
using MisTest.Common.Filters;
using MisTest.Common.Page;
using MisTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MisTest.Domain.Repositories
{
    public interface IDoctorRepository
    {
        public Task CreateDoctorAsync(DoctorEntity doctorEntity);
        public Task <PagedResult<DoctorEntity>> GetDoctorsPageAsync(PageParams? pageParams, DoctorFilterParams? filter);
        public Task DeleteDoctorAsync(Guid id);
    }
}
