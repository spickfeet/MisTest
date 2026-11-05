using MediatR;
using Microsoft.AspNetCore.Mvc;
using MisTest.Messages.Dtos.Patient;
using MisTest.Messages.Features.Patient;
using MisTest.Common.Page;
using MisTest.Host.Api.Const;

namespace MisTest.Host.Api.Controllers
{
    public class PatientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PatientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(ServiceRoutes.Patients.Base)]
        [ProducesResponseType(StatusCodes.Status201Created, Description = "Пациент добавлен в систему")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Пациент уже существует")]
        public async Task<IActionResult> CreatePatient([FromBody] PatientRequestDto patientRequestDto)
        {
            var result = await _mediator.Send(new CreatePatientCommand(patientRequestDto));
            if (result.IsSuccess)
            {
                return Created();
            }
            else
            {
                return BadRequest(result.Error);
            }
        }

        [HttpGet(ServiceRoutes.Patients.Base)]
        [ProducesResponseType(StatusCodes.Status200OK, Description = "Страница пациентов получена")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PagedResult<PatientResponseDto>>> GetPatients([FromQuery] PageParams pageParams)
        {
            var result = await _mediator.Send(new GetPatientsQuery(pageParams));
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            else
            {
                return BadRequest(result.Error);
            }
        }

        [HttpGet(ServiceRoutes.Patients.ByCardNumber)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Description = "Пациент не найден")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PatientResponseDto>> GetPatient(string cardNumber)
        {
            var result = await _mediator.Send(new GetPatientByCardNumberQuery(cardNumber));
            if (result.IsSuccess)
            {
                if(result.Value != null) return Ok(result.Value);
                else return NotFound();
            }
            else
            {
                return BadRequest(result.Error);
            }
        }

        [HttpDelete(ServiceRoutes.Patients.ById)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Не получилось удалить пациента")]
        public async Task<IActionResult> DeletePatient(Guid id)
        {
            var result = await _mediator.Send(new DeletePatientCommand(id));
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
