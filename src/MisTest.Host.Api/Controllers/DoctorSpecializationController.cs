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
        private readonly ILogger<DoctorSpecializationController> _logger;
        private readonly IMediator _mediator;

        public DoctorSpecializationController(ILogger<DoctorSpecializationController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost(ServiceRoutes.DoctorSpecializations.Base)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Специализация уже существует")]
        [ProducesResponseType(StatusCodes.Status201Created, Description = "Специализация успешно создана")]
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
        public async Task<ActionResult<PagedResult<DoctorSpecializationResponseDto>>> GetDoctorSpecializations([FromQuery] PageParams pageParams)
        {
            var result = await _mediator.Send(new GetDoctorSpecializationsQuery(pageParams));
            return Ok(result.Value);
        }

        [HttpDelete(ServiceRoutes.DoctorSpecializations.ById)]
        [ProducesResponseType(StatusCodes.Status204NoContent, Description = "Специализация отсутствует")]
        public async Task<IActionResult> DeleteDoctorSpecialization(Guid id)
        {
            var result = await _mediator.Send(new DeleteDoctorSpecializationCommand(id));
            return NoContent();
        }
    }
}
