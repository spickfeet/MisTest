using Microsoft.EntityFrameworkCore;
using MisTest.Common;
using MisTest.Common.Page;
using MisTest.Domain.Entities;
using MisTest.Domain.Repositories;
using MisTest.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MisTest.Infrastructure.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private MisTestDbContext _context;

        public PatientRepository(MisTestDbContext context)
        {
            _context = context;
        }

        public Task CreatePatientAsync(PatientEntity patientEntity)
        {
            _context.Patients.Add(patientEntity);
            return Task.CompletedTask;
        }

        public async Task DeletePatientAsync(Guid id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
            }
        }

        public async Task<PagedResult<PatientEntity>> GetPatientsPageAsync(PageParams? pageParams)
        {
            return await _context.Patients
                .AsNoTracking().ToPageAsync(pageParams);
        }
    }
}
