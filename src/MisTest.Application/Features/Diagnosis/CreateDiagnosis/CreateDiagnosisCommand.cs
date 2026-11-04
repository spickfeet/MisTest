using MediatR;
using MisTest.Application.Dtos.Diagnosis;
using MisTest.Common;

namespace MisTest.Application.Features.Diagnosis.CreateDiagnosis
{
    public record CreateDiagnosisCommand(DiagnosisRequestDto DiagnosisRequestDto) : IRequest<Result>;
}
