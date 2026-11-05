using MisTest.Common;
using MisTest.Messages.Features.Diseases;

namespace MisTest.Application.Features.Validation.Disease.DeleteDiseaseValidator
{
    public interface IDeleteDiseaseValidator
    {
        public Task<Result> Validate(DeleteDiseaseCommand request);
    }
}
