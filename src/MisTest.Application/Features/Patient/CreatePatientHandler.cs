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
                return validationResult;
            }

            await _unitOfWork.PatientRepository.CreatePatientAsync(_mapper.Map<PatientEntity>(request.PatientRequestDto));
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }
    }
}
