using MediatR;
using MisTest.Application.Dtos.DoctorSpecialization;
using MisTest.Common;

namespace MisTest.Application.Features.DoctorSpecialization.CreateSpecialization
{
    public record CreateDoctorSpecializationCommand(DoctorSpecializationRequestDto DoctorSpecializationRequestDto) : IRequest<Result>;
}
