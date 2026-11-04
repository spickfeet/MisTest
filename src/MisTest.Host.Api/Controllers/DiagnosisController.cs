using MediatR;
using Microsoft.AspNetCore.Mvc;
using MisTest.Application.Dtos.Diagnosis;
using MisTest.Application.Dtos.Doctor;
using MisTest.Application.Features.Diagnosis.CreateDiagnosis;
using MisTest.Application.Features.Diagnosis.DeleteDiagnosis;
using MisTest.Application.Features.Diagnosis.GetDiagnosesByFilter;
using MisTest.Common.Filters;
using MisTest.Common.Page;
using MisTest.Host.Api.Const;

namespace MisTest.Host.Api.Controllers
{
    [ApiController]
    public class DiagnosisController : ControllerBase
    {
        private readonly ILogger<DiagnosisController> _logger;
        private readonly IMediator _mediator;

        public DiagnosisController(ILogger<DiagnosisController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost(ServiceRoutes.Diagnosis.Base)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created, Description = "Диагноз успешно добавлен в систему")]
        public async Task<IActionResult> CreateDiagnosis([FromBody] DiagnosisRequestDto diagnosisRequestDto)
        {
            var result = await _mediator.Send(new CreateDiagnosisCommand(diagnosisRequestDto));
            if (result.IsSuccess)
            {
                return Created();
            }
            else
            {
                return BadRequest(result.Error);
            }
        }

        [HttpGet(ServiceRoutes.Diagnosis.Base)]
        [ProducesResponseType(StatusCodes.Status200OK, Description = "Страница диагнозов получена")]
        public async Task<ActionResult<PagedResult<DoctorResponseDto>>> GetDiagnosesByFilter([FromQuery] DiagnosisFilterParams filter, [FromQuery] PageParams pageParams)
        {
            var result = await _mediator.Send(new GetDiagnosesByFilterQuery(filter, pageParams));
            return Ok(result.Value);
        }

        [HttpDelete(ServiceRoutes.Diagnosis.ById)]
        [ProducesResponseType(StatusCodes.Status204NoContent, Description = "Диагноз отсутствует")]
        public async Task<IActionResult> DeleteDiagnosis(Guid id)
        {
            var result = await _mediator.Send(new DeleteDiagnosisCommand(id));
            return NoContent();
        }
    }
}
