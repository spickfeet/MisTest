using MisTest.Domain.Repositories;

namespace MisTest.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        IDoctorRepository DoctorRepository { get; }
        IPatientRepository PatientRepository { get; }
        IDiagnosisRepository DiagnosisRepository { get; }
        IDoctorSpecializationRepository DoctorSpecializationRepository { get; }
        IDiseaseRepository DiseaseRepository { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
