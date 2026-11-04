using MediatR;
using MisTest.Common;

namespace MisTest.Application.Features.Doctor.DeleteDoctor
{
    public record DeleteDoctorCommand(Guid Id) : IRequest<Result>;
}
