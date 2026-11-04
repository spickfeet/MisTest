using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MisTest.Common;
using MisTest.Domain;
using MisTest.Domain.Entities;

namespace MisTest.Application.Features.Diagnosis.CreateDiagnosis
{
    public class CreateDiagnosisHandler : IRequestHandler<CreateDiagnosisCommand, Result>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private ILogger<CreateDiagnosisHandler> _logger;
        public CreateDiagnosisHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateDiagnosisHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Result> Handle(CreateDiagnosisCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.DiagnosisRepository.CreateDiagnosisAsync(_mapper.Map<DiagnosisEntity>(request.DiagnosisRequestDto));
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }
    }
}
