using DentalChair.Application.UseCases.Allocations.Register;
using DentalChair.Application.UseCases.Allocations.Update.Status;
using DentalChair.Communication.Request;
using DentalChair.Communication.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DentalChair.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AllocationController : DentalChairControllerBase
    {
        [HttpPost("register")]
        [ProducesResponseType(typeof(ResponseAllocationJson),StatusCodes.Status201Created)]
        public async Task<IActionResult> Register([FromServices]IRegisterAllocationUseCase useCase, [FromBody] RequestRegisterAllocationJson request)
        {
            var result = await useCase.Execute(request);

            return Created(string.Empty, result);
        }

        [HttpPut("updateStatus/{id}")]
        [ProducesResponseType(typeof(ResponseAllocationJson),StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateStatus([FromServices]IUpdateStatusAllocationUseCase useCase, [FromBody]RequestUpdateStatusAllocationJson request, [FromRoute]long id)
        {
            await useCase.Execute(id, request);
            return Ok();
        }

        
    }
}
