using MediatR;
using Microsoft.Extensions.Logging;
using MisTest.Common;
using MisTest.Domain;

namespace MisTest.Application.Features.Patient.DeletePatient
{
    public class DeletePatientHandler : IRequestHandler<DeletePatientCommand, Result>
    {
        private IUnitOfWork _unitOfWork;
        private ILogger<DeletePatientHandler> _logger;
        public DeletePatientHandler(IUnitOfWork unitOfWork, ILogger<DeletePatientHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Result> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.PatientRepository.DeletePatientAsync(request.Id);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }
    }
}
