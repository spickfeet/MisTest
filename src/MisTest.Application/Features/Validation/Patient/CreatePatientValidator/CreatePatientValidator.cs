using MisTest.Application.Faults;
using MisTest.Common;
using MisTest.Domain;
using MisTest.Messages.Features.Patient;

namespace MisTest.Application.Features.Validation.Patient.CreatePatientValidator
{
    public class CreatePatientValidator : ICreatePatientValidator
    {
        private IUnitOfWork _unitOfWork;
        private const string BaseFaultMessage = "CreatePatient.Error";
        public CreatePatientValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> Validate(CreatePatientCommand request)
        {
            Fault fault = new(BaseFaultMessage);
            if (await _unitOfWork.PatientRepository.GetPatientAsync(request.PatientRequestDto.CardNumber) != null)
            {
                return Result.Failure(PatientFaults.AlreadyExists(request.PatientRequestDto.CardNumber));
            }


            if (fault.Details.Count > 0) return Result.Failure(fault);
            else return Result.Success();
        }
    }
}
