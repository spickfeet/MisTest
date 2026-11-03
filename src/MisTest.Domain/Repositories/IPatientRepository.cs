using MisTest.Common;
using MisTest.Common.Page;
using MisTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MisTest.Domain.Repositories
{
    public interface IPatientRepository
    {
        public Task CreatePatientAsync(PatientEntity patientEntity);
        public Task<PagedResult<PatientEntity>> GetPatientsPageAsync(PageParams? pageParams);
        public Task DeletePatientAsync(Guid id);
    }
}
