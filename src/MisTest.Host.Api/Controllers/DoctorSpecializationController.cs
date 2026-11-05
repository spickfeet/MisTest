using MediatR;
using Microsoft.AspNetCore.Mvc;
using MisTest.Messages.Dtos.DoctorSpecialization;
using MisTest.Messages.Features.DoctorSpecialization;
using MisTest.Common.Page;
using MisTest.Host.Api.Const;

namespace MisTest.Host.Api.Controllers
{
    [ApiController]
    public class DoctorSpecializationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DoctorSpecializationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(ServiceRoutes.DoctorSpecializations.Base)]
        [ProducesResponseType(StatusCodes.Status201Created, Description = "Специализация успешно создана")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Специализация уже существует")]
        public async Task<IActionResult> CreateDoctorSpecialization([FromBody] DoctorSpecializationRequestDto doctorSpecializationRequestDto)
        {
            var result = await _mediator.Send(new CreateDoctorSpecializationCommand(doctorSpecializationRequestDto));
            if (result.IsSuccess)
            {
                return Created();
            }
            else
            {
                return BadRequest(result.Error);
            }
        }

        [HttpGet(ServiceRoutes.DoctorSpecializations.Base)]
        [ProducesResponseType(StatusCodes.Status200OK, Description = "Страница специализаций получена")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PagedResult<DoctorSpecializationResponseDto>>> GetDoctorSpecializations([FromQuery] PageParams pageParams)
        {
            var result = await _mediator.Send(new GetDoctorSpecializationsQuery(pageParams));
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            else
            {
                return BadRequest(result.Error);
            }
        }

        [HttpDelete(ServiceRoutes.DoctorSpecializations.ById)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Не получилось удалить специализацию")]
        public async Task<IActionResult> DeleteDoctorSpecialization(Guid id)
        {
            var result = await _mediator.Send(new DeleteDoctorSpecializationCommand(id));
            if (result.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.Error);
            }
        }
    }
}
