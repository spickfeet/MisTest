using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MisTest.Application.Faults;
using MisTest.Common;
using MisTest.Domain;
using MisTest.Domain.Entities;
using MisTest.Messages.Features.Doctor;

namespace MisTest.Application.Features.Doctor
{
    public class CreateDoctorHandler : IRequestHandler<CreateDoctorCommand, Result>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private ILogger<CreateDoctorHandler> _logger;
        public CreateDoctorHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateDoctorHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Result> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
        {
            var specialization = await _unitOfWork.DoctorSpecializationRepository.GetSpecialization(request.DoctorRequestDto.SpecializationId);
            if(specialization == null)
            {
                return Result.Failure(DoctorSpecializationFaults.NotExists(request.DoctorRequestDto.SpecializationId));
            }

            await _unitOfWork.DoctorRepository.CreateDoctorAsync(_mapper.Map<DoctorEntity>(request.DoctorRequestDto));
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }
    }
}
