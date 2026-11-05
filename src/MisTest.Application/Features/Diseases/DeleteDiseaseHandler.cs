using MediatR;
using Microsoft.Extensions.Logging;
using MisTest.Application.Faults;
using MisTest.Common;
using MisTest.Common.Filters;
using MisTest.Domain;
using MisTest.Messages.Features.Diseases;

namespace MisTest.Application.Features.Diseases
{
    public class DeleteDiseaseHandler : IRequestHandler<DeleteDiseaseCommand, Result>
    {
        private IUnitOfWork _unitOfWork;
        private ILogger<DeleteDiseaseHandler> _logger;
        public DeleteDiseaseHandler(IUnitOfWork unitOfWork, ILogger<DeleteDiseaseHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Result> Handle(DeleteDiseaseCommand request, CancellationToken cancellationToken)
        {
            var page = await _unitOfWork.DiagnosisRepository.GetDiagnosesPageAsync(filter: new DiagnosisFilterParams { DiseaseId = request.Id });
            if (page.TotalCount > 0)
            {
                return Result.Failure(DiseaseFaults.InUseByDiagnoses());
            }
            await _unitOfWork.DiseaseRepository.DeleteDiseaseAsync(request.Id);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }
    }
}
