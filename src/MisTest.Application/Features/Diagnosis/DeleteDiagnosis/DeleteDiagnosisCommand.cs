using MediatR;
using MisTest.Common;

namespace MisTest.Application.Features.Diagnosis.DeleteDiagnosis
{
    public record DeleteDiagnosisCommand(Guid Id) : IRequest<Result>;
}
