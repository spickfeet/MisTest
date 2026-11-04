using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MisTest.Common;
using MisTest.Domain;
using MisTest.Domain.Entities;

namespace MisTest.Application.Features.Doctor.CreateDoctor
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
            await _unitOfWork.DoctorRepository.CreateDoctorAsync(_mapper.Map<DoctorEntity>(request.DoctorRequestDto));
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }
    }
}
