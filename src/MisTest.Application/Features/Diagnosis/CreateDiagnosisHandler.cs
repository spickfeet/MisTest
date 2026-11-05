using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MisTest.Application.Faults;
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
        private ICreateDiagnosisValidator _createDiagnosisValidator;
        private ILogger<CreateDiagnosisHandler> _logger;
        public CreateDiagnosisHandler(IUnitOfWork unitOfWork, IMapper mapper, ICreateDiagnosisValidator createDiagnosisValidator, ILogger<CreateDiagnosisHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _createDiagnosisValidator = createDiagnosisValidator;
            _logger = logger;
        }

        public async Task<Result> Handle(CreateDiagnosisCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _createDiagnosisValidator.Validate(request);
            if (validationResult.IsFailure)
            {
                return validationResult;
            }
            await _unitOfWork.DiagnosisRepository.CreateDiagnosisAsync(_mapper.Map<DiagnosisEntity>(request.DiagnosisRequestDto));
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }
    }
}
