using MediatR;
using MisTest.Messages.Dtos.DoctorSpecialization;
using MisTest.Common;

namespace MisTest.Messages.Features.DoctorSpecialization
{
    public record CreateDoctorSpecializationCommand(DoctorSpecializationRequestDto DoctorSpecializationRequestDto) : IRequest<Result>;
}
