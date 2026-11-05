using Microsoft.Extensions.DependencyInjection;
using MisTest.Application.Features.Validation.Diagnosis.CreateDiagnosisValidator;
using MisTest.Application.Features.Validation.Disease.CreateDiseaseValidator;
using MisTest.Application.Features.Validation.Disease.DeleteDiseaseValidator;
using MisTest.Application.Features.Validation.Doctor.CreateDoctorValidator;
using MisTest.Application.Features.Validation.Doctor.DeleteDoctorValidator;
using MisTest.Application.Features.Validation.DoctorSpecialization.CreateDoctorSpecializationValidator;
using MisTest.Application.Features.Validation.DoctorSpecialization.DeleteDoctorSpecializationValidator;
using MisTest.Application.Features.Validation.Patient.CreatePatientValidator;
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

            services.AddScoped<ICreateDiagnosisValidator, CreateDiagnosisValidator>();
            services.AddScoped<ICreateDiseaseValidator, CreateDiseaseValidator>();
            services.AddScoped<IDeleteDiseaseValidator, DeleteDiseaseValidator>();
            services.AddScoped<ICreateDoctorValidator, CreateDoctorValidator>();
            services.AddScoped<IDeleteDoctorValidator, DeleteDoctorValidator>();
            services.AddScoped<ICreateDoctorSpecializationValidator, CreateDoctorSpecializationValidator>();
            services.AddScoped<IDeleteDoctorSpecializationValidator, DeleteDoctorSpecializationValidator>();
            services.AddScoped<ICreatePatientValidator, CreatePatientValidator>();

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
