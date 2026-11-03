using Microsoft.EntityFrameworkCore;
using MisTest.Common;
using MisTest.Common.Filters;
using MisTest.Common.Page;
using MisTest.Domain.Entities;
using MisTest.Domain.Repositories;
using MisTest.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MisTest.Infrastructure.Repositories
{
    public class DiagnosisRepository : IDiagnosisRepository
    {
        private MisTestDbContext _context;

        public DiagnosisRepository(MisTestDbContext context)
        {
            _context = context;
        }

        public Task CreateDiagnosisAsync(DiagnosisEntity diagnosisEntity)
        {
            _context.Diagnoses.Add(diagnosisEntity);
            return Task.CompletedTask;
        }

        public async Task DeleteDiagnosisAsync(Guid id)
        {
            var diagnosis = await _context.Diagnoses.FindAsync(id);
            if(diagnosis != null)
            {
                _context.Diagnoses.Remove(diagnosis);
            }
        }

        public async Task<PagedResult<DiagnosisEntity>> GetDiagnosesPageAsync(PageParams? pageParams, DiagnosisFilterParams? filter)
        {
            return await _context.Diagnoses
                .Include(d => d.DiseaseEntity)
                .Include(d => d.PatientEntity)
                .Include(d => d.DoctorEntity).ThenInclude(d => d.SpecializationEntity)
                .FilterByPatient(filter)
                .AsNoTracking()
                .ToPageAsync(pageParams);
        }
    }
}
