using MisTest.Application.Faults;
using MisTest.Common;
using MisTest.Common.Filters;
using MisTest.Domain;
using MisTest.Messages.Features.Doctor;

namespace MisTest.Application.Features.Validation.Doctor.DeleteDoctorValidator
{
    internal class DeleteDoctorValidator : IDeleteDoctorValidator
    {
        private IUnitOfWork _unitOfWork;
        private const string BaseFaultMessage = "DeleteDoctor.Error";
        public DeleteDoctorValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> Validate(DeleteDoctorCommand request)
        {
            Fault fault = new(BaseFaultMessage);
            var page = await _unitOfWork.DiagnosisRepository.GetDiagnosesPageAsync(filter: new DiagnosisFilterParams { DoctorId = request.Id });
            if (page.TotalCount > 0)
            {
                fault.Details.Add(DoctorFaults.InUseByDiagnoses());
            }

            if (fault.Details.Count > 0) return Result.Failure(fault);
            else return Result.Success();
        }
    }
}
