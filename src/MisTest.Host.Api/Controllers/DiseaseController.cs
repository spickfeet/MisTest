using MediatR;
using Microsoft.AspNetCore.Mvc;
using MisTest.Messages.Dtos.Disease;
using MisTest.Messages.Features.Diseases;
using MisTest.Common.Page;
using MisTest.Host.Api.Const;

namespace MisTest.Host.Api.Controllers
{
    [ApiController]
    public class DiseaseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DiseaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(ServiceRoutes.Diseases.Base)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Болезнь уже существует")]
        [ProducesResponseType(StatusCodes.Status201Created, Description = "Болезнь успешно добавлена в систему")]
        public async Task<IActionResult> CreateDisease([FromBody] DiseaseRequestDto doctorSpecializationRequestDto)
        {
            var result = await _mediator.Send(new CreateDiseaseCommand(doctorSpecializationRequestDto));
            if (result.IsSuccess)
            {
                return Created();
            }
            else
            {
                return BadRequest(result.Error);
            }
        }

        [HttpGet(ServiceRoutes.Diseases.Base)]
        [ProducesResponseType(StatusCodes.Status200OK, Description = "Страница болезней получена")]
        public async Task<ActionResult<PagedResult<DiseaseResponseDto>>> GetDiseases([FromQuery] PageParams pageParams)
        {
            var result = await _mediator.Send(new GetDiseaseQuery(pageParams));
            return Ok(result.Value);
        }

        [HttpDelete(ServiceRoutes.Diseases.ById)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Не получилось удалить болезнь")]
        public async Task<IActionResult> DeleteDisease(Guid id)
        {
            var result = await _mediator.Send(new DeleteDiseaseCommand(id));
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
