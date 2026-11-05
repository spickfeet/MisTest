using MediatR;
using MisTest.Application.Faults;
using MisTest.Common;
using MisTest.Domain;
using MisTest.Messages.Dtos.Diagnosis;
using MisTest.Messages.Features.Diagnosis;

namespace MisTest.Application.Features.Validation.Diagnosis.CreateDiagnosisValidator
{
    public class CreateDiagnosisValidator : ICreateDiagnosisValidator
    {
        private const int TherapyMaxLength = 2000;
        private const int CommentMaxLength = 5000;
        private IUnitOfWork _unitOfWork;
        public CreateDiagnosisValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> Validate(CreateDiagnosisCommand request)
        {
            var fault = new Fault("CreateDiagnosis.ValidationFailed");

            ValidateIds(request.DiagnosisRequestDto, fault);
            ValidateDate(request.DiagnosisRequestDto.Date, fault);
            ValidateTherapy(request.DiagnosisRequestDto.Therapy, fault);
            ValidateComment(request.DiagnosisRequestDto.Comment, fault);
            await ValidateRelatedEntitiesAsync(request.DiagnosisRequestDto, fault);

            return fault.Details.Count > 0 ? Result.Failure(fault) : Result.Success();
        }

        private void ValidateIds(DiagnosisRequestDto dto, Fault fault)
        {
            if (dto.DoctorId == Guid.Empty)
                fault.Details.Add(DoctorFaults.IdEmpty());

            if (dto.PatientId == Guid.Empty)
                fault.Details.Add(PatientFaults.IdEmpty());

            if (dto.DiseaseId == Guid.Empty)
                fault.Details.Add(DiseaseFaults.IdEmpty());
        }

        private void ValidateDate(DateTime date, Fault fault)
        {
            if (date == default)
            {
                fault.Details.Add(DiagnosisFaults.DateEmpty());
                return;
            }

            if (date > DateTime.UtcNow)
            {
                fault.Details.Add(DiagnosisFaults.DateInFuture(date));
            }
        }

        private void ValidateTherapy(string therapy, Fault fault)
        {
            if (string.IsNullOrWhiteSpace(therapy))
            {
                fault.Details.Add(DiagnosisFaults.TherapyEmpty());
                return;
            }

            if (therapy.Length > TherapyMaxLength)
            {
                fault.Details.Add(DiagnosisFaults.TherapyTooLong(TherapyMaxLength));
            }
        }

        private void ValidateComment(string comment, Fault fault)
        {
            if (comment.Length > CommentMaxLength)
            {
                fault.Details.Add(DiagnosisFaults.CommentTooLong(CommentMaxLength));
            }
        }

        private async Task ValidateRelatedEntitiesAsync(DiagnosisRequestDto dto, Fault fault)
        {
            var diseaseEntity = await _unitOfWork.DiseaseRepository.GetDisease(dto.DiseaseId);
            if (diseaseEntity == null)
            {
                fault.Details.Add(DiseaseFaults.NotExists(dto.DiseaseId));
            }

            var doctorEntity = await _unitOfWork.DoctorRepository.GetDoctor(dto.DoctorId);
            if (doctorEntity == null)
            {
                fault.Details.Add(DoctorFaults.NotExists(dto.DoctorId));
            }

            var patientEntity = await _unitOfWork.PatientRepository.GetPatient(dto.PatientId);
            if (patientEntity == null)
            {
                fault.Details.Add(PatientFaults.NotExists(dto.PatientId));
            }
        }
    }
}
