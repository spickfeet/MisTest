using MediatR;
using Microsoft.AspNetCore.Mvc;
using MisTest.Messages.Dtos.Diagnosis;
using MisTest.Messages.Features.Diagnosis;
using MisTest.Common.Filters;
using MisTest.Common.Page;
using MisTest.Host.Api.Const;

namespace MisTest.Host.Api.Controllers
{
    [ApiController]
    public class DiagnosisController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DiagnosisController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(ServiceRoutes.Diagnosis.Base)]
        [ProducesResponseType(StatusCodes.Status201Created, Description = "Диагноз успешно добавлен в систему")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PagedResult<DiagnosisResponseDto>>> GetDiagnosesByFilter([FromQuery] DiagnosisFilterParams filter, [FromQuery] PageParams pageParams)
        {
            var result = await _mediator.Send(new GetDiagnosesByFilterQuery(filter, pageParams));
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            else
            {
                return BadRequest(result.Error);
            }
        }

        [HttpDelete(ServiceRoutes.Diagnosis.ById)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Не получилось удалить диагноз")]
        public async Task<IActionResult> DeleteDiagnosis(Guid id)
        {
            var result = await _mediator.Send(new DeleteDiagnosisCommand(id));
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
