using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MisTest.Common;
using MisTest.Common.Page;
using MisTest.Domain;
using MisTest.Messages.Dtos.Disease;
using MisTest.Messages.Features.Diseases;

namespace MisTest.Application.Features.Diseases
{
    public class GetDiseaseHandler : IRequestHandler<GetDiseaseQuery, Result<PagedResult<DiseaseResponseDto>>>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private ILogger<GetDiseaseHandler> _logger;
        public GetDiseaseHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<GetDiseaseHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Result<PagedResult<DiseaseResponseDto>>> Handle(GetDiseaseQuery request, CancellationToken cancellationToken)
        {
            return Result<PagedResult<DiseaseResponseDto>>.Success(
                _mapper.Map<PagedResult<DiseaseResponseDto>>(
                    await _unitOfWork.DiseaseRepository.GetDiseasesPageAsync(request.PageParams)));
        }
    }
}
