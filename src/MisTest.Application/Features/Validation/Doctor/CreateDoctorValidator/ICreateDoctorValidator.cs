using MisTest.Common;
using MisTest.Messages.Features.Doctor;

namespace MisTest.Application.Features.Validation.Doctor.CreateDoctorValidator
{
    public interface ICreateDoctorValidator
    {
        public Task<Result> Validate(CreateDoctorCommand request);
    }
}
