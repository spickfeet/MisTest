using Microsoft.Extensions.DependencyInjection;
using MisTest.Application.MappingProfiles;
using System.Reflection;

namespace MisTest.Application
{
    public static class Module
    {
        public static IServiceCollection ConfigureApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            return services;
        }

        public static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<DiagnosisMappingProfile>();
                cfg.AddProfile<DiseaseMappingProfile>();
                cfg.AddProfile<DoctorMappingProfile>();
                cfg.AddProfile<DoctorSpecializationMappingProfile>();
                cfg.AddProfile<PatientMappingProfile>();
            });

            return services;
        }
    }
}
