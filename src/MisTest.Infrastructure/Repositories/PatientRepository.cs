using Microsoft.EntityFrameworkCore;
using MisTest.Common.Page;
using MisTest.Domain.Entities;
using MisTest.Domain.Repositories;
using MisTest.Infrastructure.Extensions;

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

        public async Task<PatientEntity?> GetPatient(Guid id)
        {
            return await _context.Patients.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<PatientEntity?> GetPatientAsync(string cardNumber)
        {
            return await _context.Patients.AsNoTracking().FirstOrDefaultAsync(p => p.CardNumber == cardNumber);
        }

        public async Task<PagedResult<PatientEntity>> GetPatientsPageAsync(PageParams? pageParams = null)
        {
            return await _context.Patients
                .AsNoTracking().ToPageAsync(pageParams);
        }
    }
}
