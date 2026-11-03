using MediatR;
using MisTest.Common;

namespace MisTest.Application.Features.DoctorSpecializations.DeleteSpecialization
{
    public record DeleteDoctorSpecializationCommand(Guid Id) : IRequest<Result>;
}
