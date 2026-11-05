using MediatR;
using Microsoft.Extensions.Logging;
using MisTest.Common;
using MisTest.Domain;
using MisTest.Messages.Features.Diagnosis;

namespace MisTest.Application.Features.Diagnosis
{
    public class DeleteDiagnosisHandler : IRequestHandler<DeleteDiagnosisCommand, Result>
    {
        private IUnitOfWork _unitOfWork;
        private ILogger<DeleteDiagnosisHandler> _logger;
        public DeleteDiagnosisHandler(IUnitOfWork unitOfWork, ILogger<DeleteDiagnosisHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Result> Handle(DeleteDiagnosisCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.DiagnosisRepository.DeleteDiagnosisAsync(request.Id);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            _logger.LogInformation("Diagnosis deleted: Id = {Id}", request.Id);

            return Result.Success();
        }
    }
}
