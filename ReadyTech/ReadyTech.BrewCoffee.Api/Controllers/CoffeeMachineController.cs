using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Brew.Commands;
using Common.Exceptions;

namespace ReadyTech.BrewCoffee.Api.Controllers
{
    [ApiController]
    public class CoffeeMachineController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CoffeeMachineController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("brew-coffee")]
        public async Task<ActionResult<BrewCoffeeQueryResponse>> Brew()
        {
            BrewCoffeeQueryResponse brewCoffeeQueryResponse = null;

            try
            { 
                brewCoffeeQueryResponse= await _mediator.Send(new BrewCoffeeQuery());
         
            }
            catch (OutOfCoffeeException ex)
            {
                return StatusCode(503, string.Empty);
            }
            catch (AprilFoolException ex)
            {
                return StatusCode(418, string.Empty);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return Ok(brewCoffeeQueryResponse);
        }
    }
}
