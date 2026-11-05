using MediatR;
using MisTest.Messages.Dtos.Diagnosis;
using MisTest.Common;
using MisTest.Common.Filters;
using MisTest.Common.Page;

namespace MisTest.Messages.Features.Diagnosis
{
    public record GetDiagnosesByFilterQuery(DiagnosisFilterParams Filter, PageParams PageParams) : IRequest<Result<PagedResult<DiagnosisResponseDto>>>;
}
