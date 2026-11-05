using MediatR;
using MisTest.Messages.Dtos.Patient;
using MisTest.Common;
using MisTest.Common.Page;

namespace MisTest.Messages.Features.Patient
{
    public record  GetPatientsQuery(PageParams PageParams) : IRequest<Result<PagedResult<PatientResponseDto>>>;
}
