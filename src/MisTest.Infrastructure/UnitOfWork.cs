using System;
using System.Collections.Generic;
using System.Text;
using MisTest.Domain;
using MisTest.Domain.Repositories;

namespace MisTest.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDiseaseRepository _diseaseRepository;
        private IDoctorRepository _doctorRepository;
        private IPatientRepository _patientRepository;
        private IDiagnosisRepository _diagnosisRepository;
        private IDoctorSpecializationRepository _doctorSpecializationRepository;
        private MisTestDbContext _context;

        public IDiseaseRepository DiseaseRepository => _diseaseRepository;
        public IDoctorRepository DoctorRepository => _doctorRepository;
        public IPatientRepository PatientRepository => _patientRepository;
        public IDiagnosisRepository DiagnosisRepository => _diagnosisRepository;
        public IDoctorSpecializationRepository DoctorSpecializationRepository => _doctorSpecializationRepository;

        public UnitOfWork(
            MisTestDbContext context,
            IDiseaseRepository diseaseRepository,
            IDoctorRepository doctorRepository, 
            IPatientRepository patientRepository,
            IDiagnosisRepository diagnosisRepository,
            IDoctorSpecializationRepository doctorSpecializationRepository)
        {
            _context = context;
            _diseaseRepository = diseaseRepository;
            _doctorRepository = doctorRepository;
            _patientRepository = patientRepository;
            _diagnosisRepository = diagnosisRepository;
            _doctorSpecializationRepository = doctorSpecializationRepository;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
