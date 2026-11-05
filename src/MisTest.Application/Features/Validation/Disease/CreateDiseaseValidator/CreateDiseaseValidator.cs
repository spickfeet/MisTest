using MisTest.Application.Faults;
using MisTest.Common;
using MisTest.Domain;
using MisTest.Messages.Dtos.Diagnosis;
using MisTest.Messages.Features.Diseases;
using System.Xml.Linq;

namespace MisTest.Application.Features.Validation.Disease.CreateDiseaseValidator
{
    internal class CreateDiseaseValidator : ICreateDiseaseValidator
    {
                private const int NameMinLength = 2;
        private const int NameMaxLength = 200;
        private IUnitOfWork _unitOfWork;
        private const string BaseFaultMessage = "CreateDisease.Error";
        public CreateDiseaseValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> Validate(CreateDiseaseCommand request)
        {
            Fault fault = new(BaseFaultMessage);

            if (string.IsNullOrWhiteSpace(request.DiseaseRequestDto.Name))
            {
                fault.Details.Add(DiseaseFaults.NameEmpty());
                return Result.Failure(fault);
            }

            if (request.DiseaseRequestDto.Name.Length < NameMinLength)
            {
                fault.Details.Add(DiseaseFaults.NameTooShort(NameMinLength));
            }

            if (request.DiseaseRequestDto.Name.Length > NameMaxLength)
            {
                fault.Details.Add(DiseaseFaults.NameTooLong(NameMaxLength));
            }

            if (await _unitOfWork.DiseaseRepository.GetDisease(request.DiseaseRequestDto.Name) != null)
            {
                fault.Details.Add(DiseaseFaults.AlreadyExists(request.DiseaseRequestDto.Name));
            }

            return fault.Details.Count > 0 ? Result.Failure(fault) : Result.Success();
        }
    }
}
