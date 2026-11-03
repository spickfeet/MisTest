using MediatR;
using MisTest.Application.Dtos.Disease;
using MisTest.Common;
using MisTest.Common.Page;

namespace MisTest.Application.Features.Diseases.GetDiseases
{
    public record GetDiseaseQuery(PageParams PageParams) : IRequest<Result<PagedResult<DiseaseResponseDto>>>;
}
