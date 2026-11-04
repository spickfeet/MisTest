using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MisTest.Application.Dtos.Doctor;
using MisTest.Common;
using MisTest.Common.Page;
using MisTest.Domain;

namespace MisTest.Application.Features.Doctor.GetDoctorsByFilter
{
    public class GetDoctorsByFilterHandler : IRequestHandler<GetDoctorsByFilterQuery, Result<PagedResult<DoctorResponseDto>>>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private ILogger<GetDoctorsByFilterHandler> _logger;
        public GetDoctorsByFilterHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<GetDoctorsByFilterHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Result<PagedResult<DoctorResponseDto>>> Handle(GetDoctorsByFilterQuery request, CancellationToken cancellationToken)
        {
            return Result<PagedResult<DoctorResponseDto>>.Success(
                _mapper.Map<PagedResult<DoctorResponseDto>>(
                    await _unitOfWork.DoctorRepository.GetDoctorsPageAsync(request.PageParams, request.Filter)));
        }
    }
}
