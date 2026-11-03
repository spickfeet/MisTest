using MisTest.Common.Filters;
using MisTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MisTest.Infrastructure.Extensions
{
    public static class DiagnosisEntityExtensions
    {
        public static IQueryable<DiagnosisEntity> FilterByPatient(this IQueryable<DiagnosisEntity> query, DiagnosisFilterParams? filter)
        {
            if (filter == null) return query;
            if (filter.PatientId != null) query = query.Where(d => d.PatientId == filter.PatientId);
            return query;
        }
    }
}
