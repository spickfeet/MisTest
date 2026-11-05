using MediatR;
using MisTest.Common;

namespace MisTest.Messages.Features.Patient
{
    public record DeletePatientCommand(Guid Id) : IRequest<Result>;
}
