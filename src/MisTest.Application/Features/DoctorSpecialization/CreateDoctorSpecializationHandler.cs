using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MisTest.Application.Faults;
using MisTest.Application.Features.Validation.DoctorSpecialization.CreateDoctorSpecializationValidator;
using MisTest.Common;
using MisTest.Domain;
using MisTest.Domain.Entities;
using MisTest.Messages.Features.DoctorSpecialization;

namespace MisTest.Application.Features.DoctorSpecialization
{
    public class CreateSpecializationHandler : IRequestHandler<CreateDoctorSpecializationCommand, Result>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private ICreateDoctorSpecializationValidator _validator;
        private ILogger<CreateSpecializationHandler> _logger;
        public CreateSpecializationHandler(
            IUnitOfWork unitOfWork, 
            IMapper mapper, 
            ICreateDoctorSpecializationValidator validator, 
            ILogger<CreateSpecializationHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
            _logger = logger;
        }

        public async Task<Result> Handle(CreateDoctorSpecializationCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.Validate(request);
            if (validationResult.IsFailure)
            {
                return validationResult;
            }

            await _unitOfWork.DoctorSpecializationRepository.CreateSpecializationAsync(_mapper.Map<DoctorSpecializationEntity>(request.DoctorSpecializationRequestDto));
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }
    }
}
