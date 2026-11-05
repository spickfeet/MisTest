using MediatR;
using MisTest.Common;
using MisTest.Messages.Dtos.Patient;

namespace MisTest.Messages.Features.Patient
{
    public record GetPatientByCardNumberQuery(string CardNumber) : IRequest<Result<PatientResponseDto>>;
}
