using MisTest.Application.Faults;
using MisTest.Common;
using MisTest.Domain;
using MisTest.Messages.Features.Diseases;

namespace MisTest.Application.Features.Validation.Disease.CreateDiseaseValidator
{
    internal class CreateDiseaseValidator : ICreateDiseaseValidator
    {
        private IUnitOfWork _unitOfWork;
        private const string BaseFaultMessage = "CreateDisease.Error";
        public CreateDiseaseValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> Validate(CreateDiseaseCommand request)
        {
            Fault fault = new(BaseFaultMessage);
            if (await _unitOfWork.DiseaseRepository.GetDisease(request.DiseaseRequestDto.Name) != null)
            {
                fault.Details.Add(DiseaseFaults.AlreadyExists(request.DiseaseRequestDto.Name));
            }

            if (fault.Details.Count > 0) return Result.Failure(fault);
            else return Result.Success();
        }
    }
}
