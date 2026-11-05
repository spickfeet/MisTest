using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MisTest.Common;
using MisTest.Common.Page;
using MisTest.Domain;
using MisTest.Messages.Dtos.Patient;
using MisTest.Messages.Features.Patient;

namespace MisTest.Application.Features.Patient
{
    public class GetPatientsHandler : IRequestHandler<GetPatientsQuery, Result<PagedResult<PatientResponseDto>>>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private ILogger<GetPatientsHandler> _logger;
        public GetPatientsHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<GetPatientsHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Result<PagedResult<PatientResponseDto>>> Handle(GetPatientsQuery request, CancellationToken cancellationToken)
        {
            return Result<PagedResult<PatientResponseDto>>.Success(
                _mapper.Map<PagedResult<PatientResponseDto>>(
                    await _unitOfWork.PatientRepository.GetPatientsPageAsync(request.PageParams)));
        }
    }
}
