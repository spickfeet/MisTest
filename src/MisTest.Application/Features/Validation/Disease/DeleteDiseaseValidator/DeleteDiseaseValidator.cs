using MisTest.Application.Faults;
using MisTest.Common;
using MisTest.Common.Filters;
using MisTest.Domain;
using MisTest.Messages.Features.Diseases;

namespace MisTest.Application.Features.Validation.Disease.DeleteDiseaseValidator
{
    internal class DeleteDiseaseValidator : IDeleteDiseaseValidator
    {
        private IUnitOfWork _unitOfWork;
        private const string BaseFaultMessage = "DeleteDisease.Error";
        public DeleteDiseaseValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> Validate(DeleteDiseaseCommand request)
        {
            Fault fault = new(BaseFaultMessage);

            if (request.Id == Guid.Empty)
            {
                fault.Details.Add(DiseaseFaults.IdEmpty());
                return Result.Failure(fault);
            }

            var page = await _unitOfWork.DiagnosisRepository.GetDiagnosesPageAsync(filter: new DiagnosisFilterParams { DiseaseId = request.Id });
            if (page.TotalCount > 0)
            {
                fault.Details.Add(DiseaseFaults.InUseByDiagnoses());
            }

            return fault.Details.Count > 0 ? Result.Failure(fault) : Result.Success();
        }
    }
}
