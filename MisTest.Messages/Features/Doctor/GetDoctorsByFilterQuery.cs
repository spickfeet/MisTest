using MediatR;
using MisTest.Messages.Dtos.Doctor;
using MisTest.Common;
using MisTest.Common.Filters;
using MisTest.Common.Page;

namespace MisTest.Messages.Features.Doctor
{
    public record GetDoctorsByFilterQuery(DoctorFilterParams Filter, PageParams PageParams) : IRequest<Result<PagedResult<DoctorResponseDto>>>;
}
