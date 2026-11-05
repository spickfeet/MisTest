using MisTest.Common.Filters;
using MisTest.Domain.Entities;

namespace MisTest.Infrastructure.Extensions
{
    public static class DiagnosisEntityExtensions
    {
        public static IQueryable<DiagnosisEntity> FilterByPatient(this IQueryable<DiagnosisEntity> query, DiagnosisFilterParams? filter)
        {
            if (filter == null) return query;
            if (filter.PatientId != null) query = query.Where(d => d.PatientId == filter.PatientId);
            if (filter.DoctorId != null) query = query.Where(d => d.DoctorId == filter.DoctorId);
            if (filter.DiseaseId != null) query = query.Where(d => d.DiseaseId == filter.DiseaseId);
            return query;
        }
    }
}
