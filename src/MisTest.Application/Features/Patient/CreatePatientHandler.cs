using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MisTest.Application.Features.Validation.Patient.CreatePatientValidator;
using MisTest.Common;
using MisTest.Domain;
using MisTest.Domain.Entities;
using MisTest.Messages.Features.Patient;

namespace MisTest.Application.Features.Patient
{
    public class CreatePatientHandler : IRequestHandler<CreatePatientCommand, Result>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private ICreatePatientValidator _validator;
        private ILogger<CreatePatientHandler> _logger;
        public CreatePatientHandler(IUnitOfWork unitOfWork, IMapper mapper, ICreatePatientValidator validator, ILogger<CreatePatientHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
            _logger = logger;
        }

        public async Task<Result> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.Validate(request);
            if (validationResult.IsFailure)
            {
                _logger.LogWarning(
                    "Patient creation validation failed. Errors: {Errors}",
                    string.Join("; ", validationResult.Error!.Details.Select(d => d.Message)));

                return validationResult;
            }

            var entity = _mapper.Map<PatientEntity>(request.PatientRequestDto);

            await _unitOfWork.PatientRepository.CreatePatientAsync(entity);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            _logger.LogInformation("Patient created: Id = {Id}", entity.Id);

            return Result.Success();
        }
    }
}
