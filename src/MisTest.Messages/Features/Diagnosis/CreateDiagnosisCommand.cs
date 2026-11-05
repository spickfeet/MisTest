using MediatR;
using MisTest.Messages.Dtos.Diagnosis;
using MisTest.Common;

namespace MisTest.Messages.Features.Diagnosis
{
    public record CreateDiagnosisCommand(DiagnosisRequestDto DiagnosisRequestDto) : IRequest<Result>;
}
