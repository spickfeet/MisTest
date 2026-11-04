using MediatR;
using Microsoft.AspNetCore.Mvc;
using MisTest.Application.Dtos.Patient;
using MisTest.Application.Features.Patient.CreatePatient;
using MisTest.Application.Features.Patient.DeletePatient;
using MisTest.Application.Features.Patient.GetPatientById;
using MisTest.Application.Features.Patient.GetPatients;
using MisTest.Common.Page;
using MisTest.Host.Api.Const;

namespace MisTest.Host.Api.Controllers
{
    public class PatientController : ControllerBase
    {
        private readonly ILogger<PatientController> _logger;
        private readonly IMediator _mediator;

        public PatientController(ILogger<PatientController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost(ServiceRoutes.Patients.Base)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Пациент уже существует")]
        [ProducesResponseType(StatusCodes.Status201Created, Description = "Пациент добавлен в систему")]
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
        public async Task<ActionResult<PagedResult<PatientResponseDto>>> GetPatients([FromQuery] PageParams pageParams)
        {
            var result = await _mediator.Send(new GetPatientsQuery(pageParams));
            return Ok(result.Value);
        }

        [HttpGet(ServiceRoutes.Patients.ByCardNumber)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Description = "Пациент не найден")]
        public async Task<ActionResult<PatientResponseDto>> GetPatient(string cardNumber)
        {
            var result = await _mediator.Send(new GetPatientByCardNumberQuery(cardNumber));
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            else
            {
                return NotFound(result.Error);
            }
        }

        [HttpDelete(ServiceRoutes.Patients.ById)]
        [ProducesResponseType(StatusCodes.Status204NoContent, Description = "Пациент отсутствует")]
        public async Task<IActionResult> DeletePatient(Guid id)
        {
            var result = await _mediator.Send(new DeletePatientCommand(id));
            return NoContent();  
        }
    }
}
