using AutoMapper;
using MediatR;
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
        public GetDiseaseHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<PagedResult<DiseaseResponseDto>>> Handle(GetDiseaseQuery request, CancellationToken cancellationToken)
        {
            return Result<PagedResult<DiseaseResponseDto>>.Success(
                _mapper.Map<PagedResult<DiseaseResponseDto>>(
                    await _unitOfWork.DiseaseRepository.GetDiseasesPageAsync(request.PageParams)));
        }
    }
}
