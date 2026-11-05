using MisTest.Common;
using MisTest.Messages.Features.DoctorSpecialization;

namespace MisTest.Application.Features.Validation.DoctorSpecialization.DeleteDoctorSpecializationValidator
{
    public interface IDeleteDoctorSpecializationValidator
    {
        public Task<Result> Validate(DeleteDoctorSpecializationCommand request);
    }
}
