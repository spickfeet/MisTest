using MediatR;
using Microsoft.Extensions.Logging;
using MisTest.Application.Features.Validation.Disease.DeleteDiseaseValidator;
using MisTest.Common;
using MisTest.Domain;
using MisTest.Messages.Features.Diseases;

namespace MisTest.Application.Features.Diseases
{
    public class DeleteDiseaseHandler : IRequestHandler<DeleteDiseaseCommand, Result>
    {
        private IUnitOfWork _unitOfWork;
        private IDeleteDiseaseValidator _validator;
        private ILogger<DeleteDiseaseHandler> _logger;
        public DeleteDiseaseHandler(IUnitOfWork unitOfWork, IDeleteDiseaseValidator validator, ILogger<DeleteDiseaseHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
            _logger = logger;
        }

        public async Task<Result> Handle(DeleteDiseaseCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.Validate(request);
            if (validationResult.IsFailure)
            {
                return validationResult;
            }

            await _unitOfWork.DiseaseRepository.DeleteDiseaseAsync(request.Id);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }
    }
}
