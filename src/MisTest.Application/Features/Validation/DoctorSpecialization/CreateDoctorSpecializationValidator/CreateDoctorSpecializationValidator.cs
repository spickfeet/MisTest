using MisTest.Application.Faults;
using MisTest.Common;
using MisTest.Domain;
using MisTest.Messages.Features.DoctorSpecialization;
using System.Xml.Linq;

namespace MisTest.Application.Features.Validation.DoctorSpecialization.CreateDoctorSpecializationValidator
{
    public class CreateDoctorSpecializationValidator : ICreateDoctorSpecializationValidator
    {
        private const int NameMinLength = 2;
        private const int NameMaxLength = 100;
        private IUnitOfWork _unitOfWork;
        private const string BaseFaultMessage = "CreateDoctorSpecialization.Error";
        public CreateDoctorSpecializationValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> Validate(CreateDoctorSpecializationCommand request)
        {
            Fault fault = new(BaseFaultMessage);

            if (string.IsNullOrWhiteSpace(request.DoctorSpecializationRequestDto.Name))
            {
                fault.Details.Add(DoctorSpecializationFaults.NameEmpty());
                return Result.Failure(fault);
            }

            if (request.DoctorSpecializationRequestDto.Name.Length < NameMinLength)
            {
                fault.Details.Add(DoctorSpecializationFaults.NameTooShort(NameMinLength));
            }

            if (request.DoctorSpecializationRequestDto.Name.Length > NameMaxLength)
            {
                fault.Details.Add(DoctorSpecializationFaults.NameTooLong(NameMaxLength));
            }

            if (await _unitOfWork.DoctorSpecializationRepository.GetSpecialization(request.DoctorSpecializationRequestDto.Name) != null)
            {
                fault.Details.Add(DoctorSpecializationFaults.AlreadyExists(request.DoctorSpecializationRequestDto.Name));
            }

            return fault.Details.Count > 0 ? Result.Failure(fault) : Result.Success();
        }
    }
}
