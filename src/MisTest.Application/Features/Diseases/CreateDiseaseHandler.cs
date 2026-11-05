using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MisTest.Application.Faults;
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
                return validationResult;
            }

            await _unitOfWork.DiseaseRepository.CreateDiseaseAsync(_mapper.Map<DiseaseEntity>(request.DiseaseRequestDto));
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }
    }
}
