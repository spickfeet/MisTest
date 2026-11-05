using MediatR;
using MisTest.Common;

namespace MisTest.Messages.Features.DoctorSpecialization
{
    public record DeleteDoctorSpecializationCommand(Guid Id) : IRequest<Result>;
}
