using Application.Interfaces;
using Common;
using Common.Constants;
using Common.Interfaces;
using Domain.OpenWeather;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Brew.Commands;

public class BrewCoffeeQueryHandler : IRequestHandler<BrewCoffeeQuery, BrewCoffeeQueryResponse>
{
    private readonly ILogger<BrewCoffeeQueryHandler> _logger;
    private readonly IDateTimeSnapshot _dateTimeSnapshot;
    private readonly ICoffeeCounter _coffeesCounter;
    private readonly IWeatherDataEngine _weatherDataEngine;
    private readonly IBrewCoffeeOperationException _brewCoffeeOperationException;

    public BrewCoffeeQueryHandler(
        ILogger<BrewCoffeeQueryHandler> logger,  
        ICoffeeCounter coffeeCounter, 
        IDateTimeSnapshot dateTimeSnapshot,
        IWeatherDataEngine weatherDataEngine,
        IBrewCoffeeOperationException brewCoffeeOperationException
         )
    { 
        _logger = logger;
        _coffeesCounter = coffeeCounter;
        _weatherDataEngine = weatherDataEngine;
        _brewCoffeeOperationException = brewCoffeeOperationException;
        _dateTimeSnapshot = dateTimeSnapshot;
    }

    public async Task<BrewCoffeeQueryResponse> Handle(BrewCoffeeQuery brewCoffeeQuery, CancellationToken cancellationToken)
    {
        BrewCoffeeQueryResponse brewCoffeeQueryResponse = null;

        try
        {
            _brewCoffeeOperationException.Execute();


            brewCoffeeQueryResponse = await  _buildBbrewCoffeeQueryResponse();

        }
        catch (Exception ex) 
        {
            _logger.LogError(ex.Message);
            throw;
        }

        return brewCoffeeQueryResponse;
    }

    private async Task<BrewCoffeeQueryResponse> _buildBbrewCoffeeQueryResponse()
    {
        OpenWeather openWeather = await _weatherDataEngine.GetWeatherAsync();

        _coffeesCounter.Execute();

        if (openWeather != null && openWeather?.Main?.Temp > 30)
        {
            return new BrewCoffeeQueryResponse
            {
                StatusMessage = StatusMessageConstants.GetByTemperature(openWeather.Main.Temp),
                PreparedDate = _dateTimeSnapshot.GetDateTimeFormattedIso(),
            };
        }
        return  new BrewCoffeeQueryResponse
        {
            StatusMessage = StatusMessageConstants.Get(200),
            PreparedDate = _dateTimeSnapshot.GetDateTimeFormattedIso(),
        };

    }
}
