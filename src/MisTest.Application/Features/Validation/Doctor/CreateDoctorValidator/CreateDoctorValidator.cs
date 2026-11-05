using MediatR;
using MisTest.Application.Faults;
using MisTest.Common;
using MisTest.Domain;
using MisTest.Messages.Features.Doctor;

namespace MisTest.Application.Features.Validation.Doctor.CreateDoctorValidator
{
    internal class CreateDoctorValidator : ICreateDoctorValidator
    {
        private const int NameMaxLength = 100;
        private const int SurnameMaxLength = 100;
        private const int MiddleNameMaxLength = 100;
        private IUnitOfWork _unitOfWork;
        private const string BaseFaultMessage = "CreateDoctor.Error";
        public CreateDoctorValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Validate(CreateDoctorCommand request)
        {
            Fault fault = new(BaseFaultMessage);

            ValidateName(request.DoctorRequestDto.Name, fault);
            ValidateSurname(request.DoctorRequestDto.Surname, fault);
            ValidateMiddleName(request.DoctorRequestDto.MiddleName, fault);
            ValidateSpecializationId(request.DoctorRequestDto.SpecializationId, fault);

            return fault.Details.Count > 0 ? Result.Failure(fault) : Result.Success();
        }
        private static void ValidateName(string name, Fault fault)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                fault.Details.Add(DoctorFaults.NameEmpty());
                return;
            }

            if (name.Length > NameMaxLength)
                fault.Details.Add(DoctorFaults.NameTooLong(NameMaxLength));
        }

        private static void ValidateSurname(string surname, Fault fault)
        {
            if (string.IsNullOrWhiteSpace(surname))
            {
                fault.Details.Add(DoctorFaults.SurnameEmpty());
                return;
            }

            if (surname.Length > SurnameMaxLength)
                fault.Details.Add(DoctorFaults.SurnameTooLong(SurnameMaxLength));
        }

        private static void ValidateMiddleName(string? middleName, Fault fault)
        {
            if (!string.IsNullOrWhiteSpace(middleName) && middleName.Length > MiddleNameMaxLength)
            {
                fault.Details.Add(DoctorFaults.MiddleNameTooLong(MiddleNameMaxLength));
            }
        }

        private void ValidateSpecializationId(Guid specializationId, Fault fault)
        {
            if (specializationId == Guid.Empty)
            {
                fault.Details.Add(DoctorSpecializationFaults.IdEmpty());
            }
        }

        private async Task ValidateSpecializationExistsAsync(Guid specializationId, Fault fault)
        {
            var specialization = await _unitOfWork.DoctorSpecializationRepository.GetSpecialization(specializationId);
            if (specialization == null)
            {
                fault.Details.Add(DoctorSpecializationFaults.NotExists(specializationId));
            }
        }
    }
}
