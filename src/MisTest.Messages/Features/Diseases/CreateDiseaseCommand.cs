using MediatR;
using MisTest.Messages.Dtos.Disease;
using MisTest.Common;

namespace MisTest.Messages.Features.Diseases
{
    public record CreateDiseaseCommand(DiseaseRequestDto DiseaseRequestDto) : IRequest<Result>;
}
