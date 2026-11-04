using MediatR;
using MisTest.Application.Dtos.Diagnosis;
using MisTest.Common;
using MisTest.Common.Filters;
using MisTest.Common.Page;

namespace MisTest.Application.Features.Diagnosis.GetDiagnosesByFilter
{
    public record GetDiagnosesByFilterQuery(DiagnosisFilterParams Filter, PageParams PageParams) : IRequest<Result<PagedResult<DiagnosisResponseDto>>>;
}
