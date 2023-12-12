using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Brew.Commands;
using Common.Exceptions;

namespace ReadyTech.BrewCoffee.Api.Controllers;

[ApiController]
public class CoffeeMachineController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<CoffeeMachineController> _logger;
    public CoffeeMachineController(IMediator mediator, ILogger<CoffeeMachineController> logger)
    {
        _mediator = mediator;
        _logger = logger;
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
            _logger.LogWarning(ex.Message);
            return StatusCode(503, string.Empty);
        }
        catch (AprilFoolException ex)
        {
            _logger.LogWarning(ex.Message);
            return StatusCode(418, string.Empty);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex.Message);
            return StatusCode(500, ex.Message);
        }

        return Ok(brewCoffeeQueryResponse);
    }
}
