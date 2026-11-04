using MediatR;
using Microsoft.AspNetCore.Mvc;
using MisTest.Application.Dtos.Disease;
using MisTest.Application.Features.Diseases.CreateDisease;
using MisTest.Application.Features.Diseases.DeleteDisease;
using MisTest.Application.Features.Diseases.GetDiseases;
using MisTest.Common.Page;
using MisTest.Host.Api.Const;

namespace MisTest.Host.Api.Controllers
{
    [ApiController]
    public class DiseaseController : ControllerBase
    {
        private readonly ILogger<DiseaseController> _logger;
        private readonly IMediator _mediator;

        public DiseaseController(ILogger<DiseaseController> logger, IMediator mediator)
        {
            _logger = logger;
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
        public async Task<IActionResult> GetDiseases([FromQuery] PageParams pageParams)
        {
            var result = await _mediator.Send(new GetDiseaseQuery(pageParams));
            return Ok(result.Value);
        }

        [HttpDelete(ServiceRoutes.Diseases.ById)]
        [ProducesResponseType(StatusCodes.Status204NoContent, Description = "Болезнь отсутствует")]
        public async Task<IActionResult> DeleteDisease(Guid id)
        {
            var result = await _mediator.Send(new DeleteDiseaseCommand(id));
            return NoContent();
        }
    }
}
