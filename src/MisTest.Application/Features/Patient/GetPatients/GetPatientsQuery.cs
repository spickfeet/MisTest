using MediatR;
using MisTest.Application.Dtos.Patient;
using MisTest.Common;
using MisTest.Common.Page;

namespace MisTest.Application.Features.Patient.GetPatients
{
    public record  GetPatientsQuery(PageParams PageParams) : IRequest<Result<PagedResult<PatientResponseDto>>>;
}
