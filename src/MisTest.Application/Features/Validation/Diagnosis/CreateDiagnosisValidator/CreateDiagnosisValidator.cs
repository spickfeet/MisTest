using AutoMapper;
using Microsoft.Extensions.Logging;
using MisTest.Application.Faults;
using MisTest.Application.Features.Diagnosis;
using MisTest.Common;
using MisTest.Domain;
using MisTest.Messages.Features.Diagnosis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MisTest.Application.Features.Validation.Diagnosis.CreateDiagnosisValidator
{
    public class CreateDiagnosisValidator : ICreateDiagnosisValidator
    {
        private IUnitOfWork _unitOfWork;
        public CreateDiagnosisValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> Validate(CreateDiagnosisCommand request)
        {
            Fault fault = new("CreateDiagnosis.Error");
            var diseaseEntity = await _unitOfWork.DiseaseRepository.GetDisease(request.DiagnosisRequestDto.DiseaseId);
            if (diseaseEntity == null)
            {
                fault.Details.Add(DiseaseFaults.NotExists(request.DiagnosisRequestDto.DiseaseId));
            }

            var doctorEntity = await _unitOfWork.DoctorRepository.GetDoctor(request.DiagnosisRequestDto.DoctorId);
            if (doctorEntity == null)
            {
                fault.Details.Add(DoctorFaults.NotExists(request.DiagnosisRequestDto.DoctorId));
            }

            var patientEntity = await _unitOfWork.PatientRepository.GetPatient(request.DiagnosisRequestDto.PatientId);
            if (patientEntity == null)
            {
                fault.Details.Add(PatientFaults.NotExists(request.DiagnosisRequestDto.PatientId));
            }

            if (fault.Details.Count > 0) return Result.Failure(fault);
            else return Result.Success();
        }
    }
}
