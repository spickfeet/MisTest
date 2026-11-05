using AutoMapper;
using MediatR;
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
        public GetPatientsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<PagedResult<PatientResponseDto>>> Handle(GetPatientsQuery request, CancellationToken cancellationToken)
        {
            return Result<PagedResult<PatientResponseDto>>.Success(
                _mapper.Map<PagedResult<PatientResponseDto>>(
                    await _unitOfWork.PatientRepository.GetPatientsPageAsync(request.PageParams)));
        }
    }
}
