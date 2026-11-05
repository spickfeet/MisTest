using MisTest.Common;
using MisTest.Messages.Features.Patient;

namespace MisTest.Application.Features.Validation.Patient.DeletePatientValidator
{
    public interface IDeletePatientValidator
    {
        public Task<Result> Validate(DeletePatientCommand request);
    }
}
