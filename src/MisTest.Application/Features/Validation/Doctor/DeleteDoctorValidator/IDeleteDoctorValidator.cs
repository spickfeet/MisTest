using MisTest.Common;
using MisTest.Messages.Features.Doctor;

namespace MisTest.Application.Features.Validation.Doctor.DeleteDoctorValidator
{
    public interface IDeleteDoctorValidator
    {
        public Task<Result> Validate(DeleteDoctorCommand request);
    }
}
