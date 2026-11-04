using MediatR;
using MisTest.Application.Dtos.Patient;
using MisTest.Common;

namespace MisTest.Application.Features.Patient.CreatePatient
{
    public record CreatePatientCommand(PatientRequestDto PatientRequestDto) : IRequest<Result>;
}
