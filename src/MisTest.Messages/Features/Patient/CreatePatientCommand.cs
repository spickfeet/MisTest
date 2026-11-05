using MediatR;
using MisTest.Messages.Dtos.Patient;
using MisTest.Common;

namespace MisTest.Messages.Features.Patient
{
    public record CreatePatientCommand(PatientRequestDto PatientRequestDto) : IRequest<Result>;
}
