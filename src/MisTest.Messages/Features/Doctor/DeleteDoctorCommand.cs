using MediatR;
using MisTest.Common;

namespace MisTest.Messages.Features.Doctor
{
    public record DeleteDoctorCommand(Guid Id) : IRequest<Result>;
}
