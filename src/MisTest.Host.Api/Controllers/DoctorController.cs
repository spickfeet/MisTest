using MediatR;
using Microsoft.AspNetCore.Mvc;
using MisTest.Messages.Dtos.Doctor;
using MisTest.Messages.Features.Doctor;
using MisTest.Common.Filters;
using MisTest.Common.Page;
using MisTest.Host.Api.Const;

namespace MisTest.Host.Api.Controllers
{
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DoctorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(ServiceRoutes.Doctors.Base)]
        [ProducesResponseType(StatusCodes.Status201Created, Description = "Доктор успешно добавлен в систему")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Не получилось добавить доктора")]
        public async Task<IActionResult> CreateDoctor([FromBody] DoctorRequestDto doctorRequestDto)
        {
            var result = await _mediator.Send(new CreateDoctorCommand(doctorRequestDto));
            if (result.IsSuccess)
            {
                return Created();
            }
            else
            {
                return BadRequest(result.Error);
            }
        }

        [HttpGet(ServiceRoutes.Doctors.Base)]
        [ProducesResponseType(StatusCodes.Status200OK, Description = "Страница докторов получена")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PagedResult<DoctorResponseDto>>> GetDoctorsByFilter([FromQuery] DoctorFilterParams filter, [FromQuery] PageParams pageParams)
        {
            var result = await _mediator.Send(new GetDoctorsByFilterQuery(filter, pageParams));
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            else
            {
                return BadRequest(result.Error);
            }
        }

        [HttpDelete(ServiceRoutes.Doctors.ById)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Не получилось удалить доктора")]
        public async Task<IActionResult> DeleteDoctor(Guid id)
        {
            var result = await _mediator.Send(new DeleteDoctorCommand(id));
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
