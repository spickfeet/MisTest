using MediatR;
using MisTest.Common;

namespace MisTest.Application.Features.Diseases.DeleteDisease
{
    public record DeleteDiseaseCommand(Guid Id) : IRequest<Result>;
}
