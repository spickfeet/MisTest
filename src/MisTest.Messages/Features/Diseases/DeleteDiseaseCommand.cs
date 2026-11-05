using MediatR;
using MisTest.Common;

namespace MisTest.Messages.Features.Diseases
{
    public record DeleteDiseaseCommand(Guid Id) : IRequest<Result>;
}
