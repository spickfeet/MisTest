using AutoMapper;
using MediatR;
using MisTest.Common;
using MisTest.Domain;
using MisTest.Messages.Dtos.Patient;
using MisTest.Messages.Features.Patient;

namespace MisTest.Application.Features.Patient
{
    public class GetPatientByCardNumberHandler : IRequestHandler<GetPatientByCardNumberQuery, Result<PatientResponseDto?>>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public GetPatientByCardNumberHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<PatientResponseDto?>> Handle(GetPatientByCardNumberQuery request, CancellationToken cancellationToken)
        {
            return Result<PatientResponseDto?>.Success(
                _mapper.Map<PatientResponseDto?>(
                    await _unitOfWork.PatientRepository.GetPatientAsync(request.CardNumber)));
        }
    }
}
