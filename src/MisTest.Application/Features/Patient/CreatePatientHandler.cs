using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MisTest.Application.Faults;
using MisTest.Common;
using MisTest.Domain;
using MisTest.Domain.Entities;
using MisTest.Messages.Features.Patient;

namespace MisTest.Application.Features.Patient
{
    public class CreatePatientHandler : IRequestHandler<CreatePatientCommand, Result>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private ILogger<CreatePatientHandler> _logger;
        public CreatePatientHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreatePatientHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Result> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.PatientRepository.GetPatientAsync(request.PatientRequestDto.CardNumber) != null)
            {
                return Result.Failure(PatientFaults.AlreadyExists(request.PatientRequestDto.CardNumber));
            }

            await _unitOfWork.PatientRepository.CreatePatientAsync(_mapper.Map<PatientEntity>(request.PatientRequestDto));
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }
    }
}
