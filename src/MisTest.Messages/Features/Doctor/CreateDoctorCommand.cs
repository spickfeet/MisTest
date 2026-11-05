using MediatR;
using MisTest.Messages.Dtos.Doctor;
using MisTest.Common;

namespace MisTest.Messages.Features.Doctor
{
    public record CreateDoctorCommand(DoctorRequestDto DoctorRequestDto) : IRequest<Result>;
}
