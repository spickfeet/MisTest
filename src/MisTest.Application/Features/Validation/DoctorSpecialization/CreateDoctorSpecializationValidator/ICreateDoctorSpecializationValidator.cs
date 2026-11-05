using MisTest.Common;
using MisTest.Messages.Features.DoctorSpecialization;

namespace MisTest.Application.Features.Validation.DoctorSpecialization.CreateDoctorSpecializationValidator
{
    public interface ICreateDoctorSpecializationValidator
    {
        public Task<Result> Validate(CreateDoctorSpecializationCommand request);
    }
}
