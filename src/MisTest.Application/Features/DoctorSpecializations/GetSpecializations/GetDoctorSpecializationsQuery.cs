using MediatR;
using MisTest.Application.Dtos.DoctorSpecialization;
using MisTest.Common;
using MisTest.Common.Page;

namespace MisTest.Application.Features.DoctorSpecializations.GetSpecializations
{
    public record GetDoctorSpecializationsQuery(PageParams PageParams) : IRequest<Result<PagedResult<DoctorSpecializationResponseDto>>>;
}
