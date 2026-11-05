using AutoMapper;
using MediatR;
using MisTest.Common;
using MisTest.Common.Page;
using MisTest.Domain;
using MisTest.Messages.Dtos.DoctorSpecialization;
using MisTest.Messages.Features.DoctorSpecialization;

namespace MisTest.Application.Features.DoctorSpecialization
{
    internal class GetDoctorSpecializationsHandler : IRequestHandler<GetDoctorSpecializationsQuery, Result<PagedResult<DoctorSpecializationResponseDto>>>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public GetDoctorSpecializationsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<PagedResult<DoctorSpecializationResponseDto>>> Handle(GetDoctorSpecializationsQuery request, CancellationToken cancellationToken)
        {
            return Result<PagedResult<DoctorSpecializationResponseDto>>.Success(
                _mapper.Map<PagedResult<DoctorSpecializationResponseDto>>(
                    await _unitOfWork.DoctorSpecializationRepository.GetSpecializationsPageAsync(request.PageParams)));
        }
    }
}
