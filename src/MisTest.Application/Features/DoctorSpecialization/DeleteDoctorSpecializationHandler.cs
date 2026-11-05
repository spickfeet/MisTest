using MediatR;
using Microsoft.Extensions.Logging;
using MisTest.Common;
using MisTest.Domain;
using MisTest.Messages.Features.DoctorSpecialization;

namespace MisTest.Application.Features.DoctorSpecialization
{
    public class DeleteDoctorSpecializationHandler : IRequestHandler<DeleteDoctorSpecializationCommand, Result>
    {
        private IUnitOfWork _unitOfWork;
        private ILogger<DeleteDoctorSpecializationHandler> _logger;
        public DeleteDoctorSpecializationHandler(IUnitOfWork unitOfWork, ILogger<DeleteDoctorSpecializationHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Result> Handle(DeleteDoctorSpecializationCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.DoctorSpecializationRepository.DeleteSpecializationAsync(request.Id);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }
    }
}
