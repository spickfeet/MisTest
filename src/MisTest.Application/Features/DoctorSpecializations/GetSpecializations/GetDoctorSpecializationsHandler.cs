using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MisTest.Application.Dtos.DoctorSpecialization;
using MisTest.Common;
using MisTest.Common.Page;
using MisTest.Domain;

namespace MisTest.Application.Features.DoctorSpecializations.GetSpecializations
{
    internal class GetDoctorSpecializationsHandler : IRequestHandler<GetDoctorSpecializationsQuery, Result<PagedResult<DoctorSpecializationResponseDto>>>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private ILogger<GetDoctorSpecializationsHandler> _logger;
        public GetDoctorSpecializationsHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<GetDoctorSpecializationsHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Result<PagedResult<DoctorSpecializationResponseDto>>> Handle(GetDoctorSpecializationsQuery request, CancellationToken cancellationToken)
        {
            return Result<PagedResult<DoctorSpecializationResponseDto>>.Success(
                _mapper.Map<PagedResult<DoctorSpecializationResponseDto>>(
                    await _unitOfWork.DoctorSpecializationRepository.GetSpecializationsPageAsync(request.PageParams)));
        }
    }
}
