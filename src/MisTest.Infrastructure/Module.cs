using Microsoft.Extensions.DependencyInjection;
using MisTest.Domain;
using MisTest.Domain.Repositories;
using MisTest.Infrastructure.Repositories;

namespace MisTest.Infrastructure
{
    public static class Module
    {
        public static IServiceCollection ConfigureInfrastucture(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDiagnosisRepository, DiagnosisRepository>();
            services.AddScoped<IDiseaseRepository, DiseaseRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IDoctorSpecializationRepository, DoctorSpecializationRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();

            return services;
        }
    }
}
