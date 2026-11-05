using MisTest.Application.Faults;
using MisTest.Common;
using MisTest.Domain;
using MisTest.Messages.Features.DoctorSpecialization;

namespace MisTest.Application.Features.Validation.DoctorSpecialization.CreateDoctorSpecializationValidator
{
    public class CreateDoctorSpecializationValidator : ICreateDoctorSpecializationValidator
    {
        private IUnitOfWork _unitOfWork;
        private const string BaseFaultMessage = "CreateDoctorSpecialization.Error";
        public CreateDoctorSpecializationValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> Validate(CreateDoctorSpecializationCommand request)
        {
            Fault fault = new(BaseFaultMessage);
            if (await _unitOfWork.DoctorSpecializationRepository.GetSpecialization(request.DoctorSpecializationRequestDto.Name) != null)
            {
                fault.Details.Add(DoctorSpecializationFaults.AlreadyExists(request.DoctorSpecializationRequestDto.Name));
            }

            if (fault.Details.Count > 0) return Result.Failure(fault);
            else return Result.Success();
        }
    }
}
