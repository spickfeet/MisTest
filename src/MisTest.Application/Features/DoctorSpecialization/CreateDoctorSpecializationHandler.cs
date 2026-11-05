using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
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
                _logger.LogWarning(
                    "DoctorSpecialization creation validation failed. Errors: {Errors}",
                    string.Join("; ", validationResult.Error!.Details.Select(d => d.Message)));

                return validationResult;
            }

            var entity = _mapper.Map<DoctorSpecializationEntity>(request.DoctorSpecializationRequestDto);

            await _unitOfWork.DoctorSpecializationRepository.CreateSpecializationAsync(entity);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            _logger.LogInformation("DoctorSpecialization created: Id = {Id}", entity.Id);

            return Result.Success();
        }
    }
}
