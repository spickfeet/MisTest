using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MisTest.Application.Features.Validation.Doctor.CreateDoctorValidator;
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
        private ICreateDoctorValidator _validator;
        private ILogger<CreateDoctorHandler> _logger;
        public CreateDoctorHandler(IUnitOfWork unitOfWork, IMapper mapper, ICreateDoctorValidator validator, ILogger<CreateDoctorHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
            _logger = logger;
        }

        public async Task<Result> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.Validate(request);
            if (validationResult.IsFailure)
            {
                _logger.LogWarning(
                    "Doctor creation validation failed. Errors: {Errors}",
                    string.Join("; ", validationResult.Error!.Details.Select(d => d.Message)));

                return validationResult;
            }

            var entity = _mapper.Map<DoctorEntity>(request.DoctorRequestDto);

            await _unitOfWork.DoctorRepository.CreateDoctorAsync(entity);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            _logger.LogInformation("Doctor created: Id = {Id}", entity.Id);

            return Result.Success();
        }
    }
}
