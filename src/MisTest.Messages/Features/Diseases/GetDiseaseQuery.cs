using MediatR;
using MisTest.Messages.Dtos.Disease;
using MisTest.Common;
using MisTest.Common.Page;

namespace MisTest.Messages.Features.Diseases
{
    public record GetDiseaseQuery(PageParams PageParams) : IRequest<Result<PagedResult<DiseaseResponseDto>>>;
}
