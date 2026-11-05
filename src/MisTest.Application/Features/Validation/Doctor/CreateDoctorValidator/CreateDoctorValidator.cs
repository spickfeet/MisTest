using MisTest.Application.Faults;
using MisTest.Common;
using MisTest.Domain;
using MisTest.Messages.Features.Doctor;

namespace MisTest.Application.Features.Validation.Doctor.CreateDoctorValidator
{
    internal class CreateDoctorValidator : ICreateDoctorValidator
    {
        private IUnitOfWork _unitOfWork;
        private const string BaseFaultMessage = "CreateDoctor.Error";
        public CreateDoctorValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Validate(CreateDoctorCommand request)
        {
            Fault fault = new(BaseFaultMessage);
            var specialization = await _unitOfWork.DoctorSpecializationRepository.GetSpecialization(request.DoctorRequestDto.SpecializationId);
            if (specialization == null)
            {
                fault.Details.Add(DoctorSpecializationFaults.NotExists(request.DoctorRequestDto.SpecializationId));
            }

            if (fault.Details.Count > 0) return Result.Failure(fault);
            else return Result.Success();
        }
    }
}
