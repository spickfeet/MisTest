using MisTest.Common;
using MisTest.Messages.Features.Diagnosis;

namespace MisTest.Application.Features.Validation.Diagnosis.CreateDiagnosisValidator
{
    public interface ICreateDiagnosisValidator
    {
        public Task<Result> Validate(CreateDiagnosisCommand request);
    }
}
