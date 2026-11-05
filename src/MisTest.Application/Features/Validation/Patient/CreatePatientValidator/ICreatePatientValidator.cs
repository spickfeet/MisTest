using MisTest.Common;
using MisTest.Messages.Features.Patient;

namespace MisTest.Application.Features.Validation.Patient.CreatePatientValidator
{
    public interface ICreatePatientValidator
    {
        public Task<Result> Validate(CreatePatientCommand request);
    }
}
