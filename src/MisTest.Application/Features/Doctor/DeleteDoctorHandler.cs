using MediatR;
using Microsoft.Extensions.Logging;
using MisTest.Application.Features.Validation.Doctor.DeleteDoctorValidator;
using MisTest.Common;
using MisTest.Domain;
using MisTest.Messages.Features.Doctor;

namespace MisTest.Application.Features.Doctor
{
    public class DeleteDoctorHandler : IRequestHandler<DeleteDoctorCommand, Result>
    {
        private IUnitOfWork _unitOfWork;
        private IDeleteDoctorValidator _validator;
        private ILogger<DeleteDoctorHandler> _logger;
        public DeleteDoctorHandler(IUnitOfWork unitOfWork, IDeleteDoctorValidator validator,  ILogger<DeleteDoctorHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
            _logger = logger;
        }

        public async Task<Result> Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.Validate(request);
            if (validationResult.IsFailure)
            {
                _logger.LogWarning(
                    "Doctor removal validation failed. Errors: {Errors}",
                    string.Join("; ", validationResult.Error!.Details.Select(d => d.Message)));

                return validationResult;
            }

            await _unitOfWork.DoctorRepository.DeleteDoctorAsync(request.Id);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            _logger.LogInformation("Doctor deleted: Id = {Id}", request.Id);

            return Result.Success();
        }
    }
}
