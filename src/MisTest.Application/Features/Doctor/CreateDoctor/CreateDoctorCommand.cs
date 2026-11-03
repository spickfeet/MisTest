using MediatR;
using MisTest.Application.Dtos.Doctor;
using MisTest.Common;

namespace MisTest.Application.Features.Doctor.CreateDoctor
{
    public record CreateDoctorCommand(DoctorRequestDto DoctorRequestDto) : IRequest<Result>;
}
