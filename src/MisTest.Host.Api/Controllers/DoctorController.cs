using MediatR;
using Microsoft.AspNetCore.Mvc;
using MisTest.Application.Dtos.Doctor;
using MisTest.Application.Dtos.DoctorSpecialization;
using MisTest.Application.Features.Doctor.CreateDoctor;
using MisTest.Application.Features.Doctor.DeleteDoctor;
using MisTest.Application.Features.Doctor.GetDoctorsByFilter;
using MisTest.Application.Features.DoctorSpecializations.CreateSpecializations;
using MisTest.Application.Features.DoctorSpecializations.DeleteSpecialization;
using MisTest.Application.Features.DoctorSpecializations.GetSpecializations;
using MisTest.Common.Filters;
using MisTest.Common.Page;
using MisTest.Host.Api.Const;

namespace MisTest.Host.Api.Controllers
{
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly ILogger<DoctorController> _logger;
        private readonly IMediator _mediator;

        public DoctorController(ILogger<DoctorController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost(ServiceRoutes.Doctor.Base)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created, Description = "Доктор успешно добавлен в систему")]
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

        [HttpGet(ServiceRoutes.Doctor.Base)]
        [ProducesResponseType(StatusCodes.Status200OK, Description = "Страница докторов получена")]
        public async Task<IActionResult> GetDoctorsByFilter([FromQuery] DoctorFilterParams filter, [FromQuery] PageParams pageParams)
        {
            var result = await _mediator.Send(new GetDoctorsByFilterQuery(filter, pageParams));
            return Ok(result.Value);
        }

        [HttpDelete(ServiceRoutes.Doctor.ById)]
        [ProducesResponseType(StatusCodes.Status204NoContent, Description = "Доктор отсутствует")]
        public async Task<IActionResult> DeleteDoctor(Guid id)
        {
            var result = await _mediator.Send(new DeleteDoctorCommand(id));
            return NoContent();
        }
    }
}
