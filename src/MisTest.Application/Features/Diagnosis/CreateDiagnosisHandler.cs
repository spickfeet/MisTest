using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MisTest.Application.Features.Validation.Diagnosis.CreateDiagnosisValidator;
using MisTest.Common;
using MisTest.Domain;
using MisTest.Domain.Entities;
using MisTest.Messages.Features.Diagnosis;

namespace MisTest.Application.Features.Diagnosis
{
    public class CreateDiagnosisHandler : IRequestHandler<CreateDiagnosisCommand, Result>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private ICreateDiagnosisValidator _validator;
        private ILogger<CreateDiagnosisHandler> _logger;
        public CreateDiagnosisHandler(IUnitOfWork unitOfWork, IMapper mapper, ICreateDiagnosisValidator validator, ILogger<CreateDiagnosisHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
            _logger = logger;
        }

        public async Task<Result> Handle(CreateDiagnosisCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.Validate(request);
            if (validationResult.IsFailure)
            {
                _logger.LogWarning(
                    "Diagnosis creation validation failed. Errors: {Errors}", 
                    string.Join("; ", validationResult.Error!.Details.Select(d => d.Message)));

                return validationResult;
            }

            var entity = _mapper.Map<DiagnosisEntity>(request.DiagnosisRequestDto);

            await _unitOfWork.DiagnosisRepository.CreateDiagnosisAsync(entity);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            _logger.LogInformation("Diagnosis created: Id = {Id}", entity.Id);

            return Result.Success();
        }
    }
}
