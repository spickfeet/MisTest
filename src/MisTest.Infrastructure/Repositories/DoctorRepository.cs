using Microsoft.EntityFrameworkCore;
using MisTest.Common.Filters;
using MisTest.Common.Page;
using MisTest.Domain.Entities;
using MisTest.Domain.Repositories;
using MisTest.Infrastructure.Extensions;

namespace MisTest.Infrastructure.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private MisTestDbContext _context;

        public DoctorRepository(MisTestDbContext context)
        {
            _context = context;
        }

        public Task CreateDoctorAsync(DoctorEntity doctorEntity)
        {
            _context.Doctors.Add(doctorEntity);
            return Task.CompletedTask;
        }

        public async Task DeleteDoctorAsync(Guid id)
        {
            var doctor = await _context.Doctors.FindAsync(id); 
            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
            }
        }

        public async Task<PagedResult<DoctorEntity>> GetDoctorsPageAsync(PageParams? pageParams, DoctorFilterParams? filter)
        {
            return await _context.Doctors
                .Include(d => d.SpecializationEntity)
                .FilterBySpecialization(filter)
                .AsNoTracking()
                .ToPageAsync(pageParams);
        }
    }
}
