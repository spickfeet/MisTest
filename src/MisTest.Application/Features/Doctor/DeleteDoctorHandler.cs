using MediatR;
using Microsoft.Extensions.Logging;
using MisTest.Application.Faults;
using MisTest.Common;
using MisTest.Common.Filters;
using MisTest.Domain;
using MisTest.Messages.Features.Doctor;

namespace MisTest.Application.Features.Doctor
{
    public class DeleteDoctorHandler : IRequestHandler<DeleteDoctorCommand, Result>
    {
        private IUnitOfWork _unitOfWork;
        private ILogger<DeleteDoctorHandler> _logger;
        public DeleteDoctorHandler(IUnitOfWork unitOfWork, ILogger<DeleteDoctorHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Result> Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
        {
            var page = await _unitOfWork.DiagnosisRepository.GetDiagnosesPageAsync(filter: new DiagnosisFilterParams { DoctorId = request.Id });
            if (page.TotalCount > 0)
            {
                return Result.Failure(DoctorFaults.InUseByDiagnoses());
            }
            await _unitOfWork.DoctorRepository.DeleteDoctorAsync(request.Id);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }
    }
}
