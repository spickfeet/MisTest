using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MisTest.Application.Dtos.Patient;
using MisTest.Application.Faults;
using MisTest.Common;
using MisTest.Domain;

namespace MisTest.Application.Features.Patient.GetPatientById
{
    public class GetPatientByCardNumberHandler : IRequestHandler<GetPatientByCardNumberQuery, Result<PatientResponseDto>>
    {
        private IUnitOfWork _unitOfWork;
        private ILogger<GetPatientByCardNumberHandler> _logger;
        private IMapper _mapper;
        public GetPatientByCardNumberHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<GetPatientByCardNumberHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Result<PatientResponseDto>> Handle(GetPatientByCardNumberQuery request, CancellationToken cancellationToken)
        {
            var patientDto = _mapper.Map<PatientResponseDto>(await _unitOfWork.PatientRepository.GetPatientAsync(request.CardNumber));
            return patientDto == null ? 
                Result<PatientResponseDto>.Failure(PatientFaults.NotExists(request.CardNumber)) : 
                Result<PatientResponseDto>.Success(patientDto);
        }
    }
}
