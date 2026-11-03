using MediatR;
using MisTest.Application.Dtos.Disease;
using MisTest.Common;

namespace MisTest.Application.Features.Diseases.CreateDisease
{
    public record CreateDiseaseCommand(DiseaseRequestDto DiseaseRequestDto) : IRequest<Result>;
}
