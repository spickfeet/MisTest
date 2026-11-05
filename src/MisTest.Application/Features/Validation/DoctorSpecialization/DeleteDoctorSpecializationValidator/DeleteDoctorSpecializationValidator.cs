using MisTest.Application.Faults;
using MisTest.Common;
using MisTest.Common.Filters;
using MisTest.Domain;
using MisTest.Messages.Features.DoctorSpecialization;

namespace MisTest.Application.Features.Validation.DoctorSpecialization.DeleteDoctorSpecializationValidator
{
    public class DeleteDoctorSpecializationValidator : IDeleteDoctorSpecializationValidator
    {
        private IUnitOfWork _unitOfWork;
        private const string BaseFaultMessage = "DeleteDoctorSpecialization.Error";
        public DeleteDoctorSpecializationValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> Validate(DeleteDoctorSpecializationCommand request)
        {
            Fault fault = new(BaseFaultMessage);

            if (request.Id == Guid.Empty)
            {
                fault.Details.Add(DoctorSpecializationFaults.IdEmpty());
                return Result.Failure(fault);
            }

            var page = await _unitOfWork.DoctorRepository.GetDoctorsPageAsync(filter: new DoctorFilterParams { SpecializationId = request.Id });
            if (page.TotalCount > 0)
            {
                fault.Details.Add(DoctorSpecializationFaults.InUseByDoctors());
            }

            return fault.Details.Count > 0 ? Result.Failure(fault) : Result.Success();
        }
    }
}
