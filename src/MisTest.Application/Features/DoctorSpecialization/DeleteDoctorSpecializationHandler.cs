using MediatR;
using Microsoft.Extensions.Logging;
using MisTest.Application.Features.Validation.DoctorSpecialization.DeleteDoctorSpecializationValidator;
using MisTest.Common;
using MisTest.Domain;
using MisTest.Messages.Features.DoctorSpecialization;

namespace MisTest.Application.Features.DoctorSpecialization
{
    public class DeleteDoctorSpecializationHandler : IRequestHandler<DeleteDoctorSpecializationCommand, Result>
    {
        private IUnitOfWork _unitOfWork;
        private IDeleteDoctorSpecializationValidator _validator;
        private ILogger<DeleteDoctorSpecializationHandler> _logger;
        public DeleteDoctorSpecializationHandler(
            IUnitOfWork unitOfWork,
            IDeleteDoctorSpecializationValidator validator,
            ILogger<DeleteDoctorSpecializationHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
            _logger = logger;
        }

        public async Task<Result> Handle(DeleteDoctorSpecializationCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.Validate(request);
            if (validationResult.IsFailure)
            {
                _logger.LogWarning(
                    "DoctorSpecialization removal validation failed. Errors: {Errors}",
                    string.Join("; ", validationResult.Error!.Details.Select(d => d.Message)));

                return validationResult;
            }

            await _unitOfWork.DoctorSpecializationRepository.DeleteSpecializationAsync(request.Id);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            _logger.LogInformation("DoctorSpecialization deleted: Id = {Id}", request.Id);

            return Result.Success();
        }
    }
}
