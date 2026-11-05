using MediatR;
using MisTest.Messages.Dtos.DoctorSpecialization;
using MisTest.Common;
using MisTest.Common.Page;

namespace MisTest.Messages.Features.DoctorSpecialization
{
    public record GetDoctorSpecializationsQuery(PageParams PageParams) : IRequest<Result<PagedResult<DoctorSpecializationResponseDto>>>;
}
