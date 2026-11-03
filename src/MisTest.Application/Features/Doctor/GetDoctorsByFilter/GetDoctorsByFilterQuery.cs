using MediatR;
using MisTest.Application.Dtos.Doctor;
using MisTest.Common;
using MisTest.Common.Filters;
using MisTest.Common.Page;

namespace MisTest.Application.Features.Doctor.GetDoctorsByFilter
{
    public record GetDoctorsByFilterQuery(DoctorFilterParams Filter,PageParams PageParams) : IRequest<Result<PagedResult<DoctorResponseDto>>>;
}
