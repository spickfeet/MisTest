using MediatR;
using MisTest.Common;

namespace MisTest.Messages.Features.Diagnosis
{
    public record DeleteDiagnosisCommand(Guid Id) : IRequest<Result>;
}
