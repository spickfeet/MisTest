using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MisTest.Application.Dtos.Diagnosis;
using MisTest.Common;
using MisTest.Common.Page;
using MisTest.Domain;

namespace MisTest.Application.Features.Diagnosis.GetDiagnosesByFilter
{
    internal class GetDiagnosesByFilterHandler : IRequestHandler<GetDiagnosesByFilterQuery, Result<PagedResult<DiagnosisResponseDto>>>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private ILogger<GetDiagnosesByFilterHandler> _logger;
        public GetDiagnosesByFilterHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<GetDiagnosesByFilterHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Result<PagedResult<DiagnosisResponseDto>>> Handle(GetDiagnosesByFilterQuery request, CancellationToken cancellationToken)
        {
            return Result<PagedResult<DiagnosisResponseDto>>.Success(
                _mapper.Map<PagedResult<DiagnosisResponseDto>>(
                    await _unitOfWork.DiagnosisRepository.GetDiagnosesPageAsync(request.PageParams, request.Filter)));
        }
    }
}
