using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MisTest.Domain;
using MisTest.Common;
using MisTest.Domain.Entities;

namespace MisTest.Application.Features.DoctorSpecializations.CreateSpecializations
{
    public class CreateSpecializationHandler : IRequestHandler<CreateDoctorSpecializationCommand, Result>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private ILogger<CreateSpecializationHandler> _logger;
        public CreateSpecializationHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateSpecializationHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Result> Handle(CreateDoctorSpecializationCommand request, CancellationToken cancellationToken)
        {
            if(await _unitOfWork.DoctorSpecializationRepository.GetSpecialization(request.DoctorSpecializationRequestDto.Name) != null)
            {
                return Result.Failure(new("SpecializationIsExist", [new($"Специализация ({request.DoctorSpecializationRequestDto.Name}) уже существует!")]));
            }
            await _unitOfWork.DoctorSpecializationRepository.CreateSpecializationAsync(_mapper.Map<DoctorSpecializationEntity>(request.DoctorSpecializationRequestDto));
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }
    }
}
