using MisTest.Common.Filters;
using MisTest.Domain.Entities;

namespace MisTest.Infrastructure.Extensions
{
    public static class DoctorEntityExtensions
    {
        public static IQueryable<DoctorEntity> FilterBySpecialization(this IQueryable<DoctorEntity> query, DoctorFilterParams? filter)
        {
            if (filter == null) return query;
            if (filter.SpecializationId != null) query = query.Where(d => d.SpecializationId == filter.SpecializationId);
            return query;
        }
    }
}
