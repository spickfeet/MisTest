using MediatR;
using Microsoft.Extensions.Logging;
using MisTest.Application.Faults;
using MisTest.Common;
using MisTest.Common.Filters;
using MisTest.Domain;
using MisTest.Messages.Features.DoctorSpecialization;

namespace MisTest.Application.Features.DoctorSpecialization
{
    public class DeleteDoctorSpecializationHandler : IRequestHandler<DeleteDoctorSpecializationCommand, Result>
    {
        private IUnitOfWork _unitOfWork;
        private ILogger<DeleteDoctorSpecializationHandler> _logger;
        public DeleteDoctorSpecializationHandler(IUnitOfWork unitOfWork,  ILogger<DeleteDoctorSpecializationHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Result> Handle(DeleteDoctorSpecializationCommand request, CancellationToken cancellationToken)
        {
            var page = await _unitOfWork.DoctorRepository.GetDoctorsPageAsync(filter: new DoctorFilterParams { SpecializationId = request.Id });
            if(page.TotalCount > 0)
            {
                return Result.Failure(DoctorSpecializationFaults.InUseByDoctors());
            }
            await _unitOfWork.DoctorSpecializationRepository.DeleteSpecializationAsync(request.Id);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }
    }
}
