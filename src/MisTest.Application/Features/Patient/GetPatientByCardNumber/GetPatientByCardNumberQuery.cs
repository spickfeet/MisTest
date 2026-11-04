using MediatR;
using MisTest.Application.Dtos.Patient;
using MisTest.Common;

namespace MisTest.Application.Features.Patient.GetPatientByCardNumber
{
    public record GetPatientByCardNumberQuery(string CardNumber) : IRequest<Result<PatientResponseDto>>;
}
