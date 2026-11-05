using MisTest.Common;
using MisTest.Messages.Features.Diseases;

namespace MisTest.Application.Features.Validation.Disease.CreateDiseaseValidator
{
    public interface ICreateDiseaseValidator
    {
        public Task<Result> Validate(CreateDiseaseCommand request);
    }
}
