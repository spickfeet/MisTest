using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MisTest.Application.Features.Validation.Disease.CreateDiseaseValidator;
using MisTest.Common;
using MisTest.Domain;
using MisTest.Domain.Entities;
using MisTest.Messages.Features.Diseases;

namespace MisTest.Application.Features.Diseases
{
    public class CreateDiseaseHandler : IRequestHandler<CreateDiseaseCommand, Result>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private ICreateDiseaseValidator _validator;
        private ILogger<CreateDiseaseHandler> _logger;
        public CreateDiseaseHandler(IUnitOfWork unitOfWork, IMapper mapper, ICreateDiseaseValidator validator, ILogger<CreateDiseaseHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _validator = validator;
        }

        public async Task<Result> Handle(CreateDiseaseCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.Validate(request);
            if (validationResult.IsFailure)
            {
                _logger.LogWarning(
                    "Disease creation validation failed. Errors: {Errors}",
                    string.Join("; ", validationResult.Error!.Details.Select(d => d.Message)));

                return validationResult;
            }

            var entity = _mapper.Map<DiseaseEntity>(request.DiseaseRequestDto);

            await _unitOfWork.DiseaseRepository.CreateDiseaseAsync(entity);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            _logger.LogInformation("Disease created: Id = {Id}", entity.Id);

            return Result.Success();
        }
    }
}
