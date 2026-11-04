using MediatR;
using MisTest.Common;

namespace MisTest.Application.Features.DoctorSpecialization.DeleteSpecialization
{
    public record DeleteDoctorSpecializationCommand(Guid Id) : IRequest<Result>;
}
