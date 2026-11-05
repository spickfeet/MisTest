using AutoMapper;
using MediatR;
using MisTest.Common;
using MisTest.Common.Page;
using MisTest.Domain;
using MisTest.Messages.Dtos.Diagnosis;
using MisTest.Messages.Features.Diagnosis;

namespace MisTest.Application.Features.Diagnosis
{
    internal class GetDiagnosesByFilterHandler : IRequestHandler<GetDiagnosesByFilterQuery, Result<PagedResult<DiagnosisResponseDto>>>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public GetDiagnosesByFilterHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<PagedResult<DiagnosisResponseDto>>> Handle(GetDiagnosesByFilterQuery request, CancellationToken cancellationToken)
        {
            return Result<PagedResult<DiagnosisResponseDto>>.Success(
                _mapper.Map<PagedResult<DiagnosisResponseDto>>(
                    await _unitOfWork.DiagnosisRepository.GetDiagnosesPageAsync(request.PageParams, request.Filter)));
        }
    }
}
