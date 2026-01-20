using DentalChair.Application.UseCases.DentalChairs.Register;
using DentalChair.Communication.Request;
using DentalChair.Communication.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DentalChair.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ChairController : DentalChairControllerBase
    {
        [HttpPost("register")]
        [ProducesResponseType(typeof(ResponseRegisteredChairJson), StatusCodes.Status201Created)]
        public async Task<IActionResult> RegisterChair([FromServices]IRegisterDentalChairUseCase useCase, [FromBody] RequestRegisterChairJson request)
        {
            var result = await useCase.Execute(request);

            return Created(string.Empty, result);
        }

        
    }
}
