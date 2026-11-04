using MediatR;
using MisTest.Common;

namespace MisTest.Application.Features.Patient.DeletePatient
{
    public record DeletePatientCommand(Guid Id) : IRequest<Result>;
}
