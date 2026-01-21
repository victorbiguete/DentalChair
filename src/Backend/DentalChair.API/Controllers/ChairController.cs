using DentalChair.Application.UseCases.DentalChairs.Delete;
using DentalChair.Application.UseCases.DentalChairs.GetAll;
using DentalChair.Application.UseCases.DentalChairs.GetById;
using DentalChair.Application.UseCases.DentalChairs.GetChairByChairNumber;
using DentalChair.Application.UseCases.DentalChairs.Register;
using DentalChair.Application.UseCases.DentalChairs.Update;
using DentalChair.Communication.Request;
using DentalChair.Communication.Response;
using DentalChair.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace DentalChair.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ChairController : DentalChairControllerBase
    {
        [HttpPost("register")]
        [ProducesResponseType(typeof(ResponseRegisteredChairJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterChair([FromServices]IRegisterDentalChairUseCase useCase, [FromBody] RequestRegisterChairJson request)
        {
            var result = await useCase.Execute(request);

            return Created(string.Empty, result);
        }

        [HttpGet("getall")]
        [ProducesResponseType(typeof(ResponseListDentalChairJson), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllDentalChairs([FromServices]IGetAllDentalChairUseCase useCase)
        {
            var result = await useCase.Execute();

            return Ok(result);
        }

        [HttpGet("GetById/{id}")]
        [ProducesResponseType(typeof(ResponseDentalChairJson), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById([FromServices] IGetByIdDentalChairUseCase useCase , [FromRoute] long id)
        {
            var result = await useCase.Execute(id);

            return Ok(result);
        }

        [HttpGet("GetByChairNumber/{chairNumber}")]
        [ProducesResponseType(typeof(ResponseDentalChairJson), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById([FromServices] IGetByChairNumberUseCase useCase , [FromRoute] string chairNumber)
        {
            var result = await useCase.Execute(chairNumber);

            return Ok(result);
        }

        [HttpPut("update/{id}")]
        [ProducesResponseType(typeof(RequestUpdateChairJson), StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update([FromServices] IUpdateDentalChairUseCase useCase, [FromRoute]long id, [FromBody] RequestUpdateChairJson request)
        {
            await useCase.Execute(request,id);

            return NoContent();
        }

        [HttpPut("updateMaintenance/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update([FromServices] IUpdateDentalChairUseCase useCase, [FromRoute]long id, [FromBody] DateTime maintenance)
        {
            await useCase.UpdateMaintenance(id,maintenance);

            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete([FromServices] IDeleteDentalChairUseCase useCase, long id)
        {
            await useCase.Execute(id);

            return NoContent();
        }
    }
}
