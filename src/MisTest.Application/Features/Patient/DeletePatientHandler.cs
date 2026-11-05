using MediatR;
using Microsoft.Extensions.Logging;
using MisTest.Application.Features.Validation.Patient.DeletePatientValidator;
using MisTest.Common;
using MisTest.Domain;
using MisTest.Messages.Features.Patient;

namespace MisTest.Application.Features.Patient
{
    public class DeletePatientHandler : IRequestHandler<DeletePatientCommand, Result>
    {
        private IUnitOfWork _unitOfWork;
        private IDeletePatientValidator _validator;
        private ILogger<DeletePatientHandler> _logger;
        public DeletePatientHandler(IUnitOfWork unitOfWork, IDeletePatientValidator validator, ILogger<DeletePatientHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
            _logger = logger;
        }

        public async Task<Result> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.Validate(request);
            if (validationResult.IsFailure)
            {
                _logger.LogWarning(
                    "Patient removal validation failed. Errors: {Errors}",
                    string.Join("; ", validationResult.Error!.Details.Select(d => d.Message)));

                return validationResult;
            }

            await _unitOfWork.PatientRepository.DeletePatientAsync(request.Id);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            _logger.LogInformation("Patient deleted: Id = {Id}", request.Id);

            return Result.Success();
        }
    }
}
