using Application.Interfaces;
using Common;
using Common.Constants;
using Common.Exceptions;
using Common.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Brew.Commands
{
    public class BrewCoffeeQueryHandler : IRequestHandler<BrewCoffeeQuery, BrewCoffeeQueryResponse>
    {
        private readonly ILogger<BrewCoffeeQueryHandler> _logger;
        private readonly IDateTimeSnapshot _dateTimeSnapshot;
        private readonly ICoffeeCounter _coffeesCounter;

        private const int MaxCoffee = 5;

        public BrewCoffeeQueryHandler(ILogger<BrewCoffeeQueryHandler> logger, IDateTimeSnapshot dateTimeSnapshot, ICoffeeCounter coffeeCounter)
        { 
            _logger = logger;
            _dateTimeSnapshot = dateTimeSnapshot;
            _coffeesCounter = coffeeCounter;

        }

        public Task<BrewCoffeeQueryResponse> Handle(BrewCoffeeQuery brewCoffeeQuery, CancellationToken cancellationToken)
        {
            BrewCoffeeQueryResponse brewCoffeeQueryResponse = null;

            try
            {
                if (_coffeesCounter.Counter == MaxCoffee)
                {
                    
                    throw new OutOfCoffeeException();
         
                }
                else if (_dateTimeSnapshot.GetDate is { Day:01, Month:04 })
                {
                    throw new AprilFoolException();
                }

                brewCoffeeQueryResponse = new BrewCoffeeQueryResponse
                {
                    StatusMessage = StatusMessageConstants.Get(200),
                    PreparedDate = _dateTimeSnapshot.GetDateTimeFormattedIso(),
                };


                _coffeesCounter.Execute();
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex.Message);
                throw;
            }

            return Task.FromResult(brewCoffeeQueryResponse);
        }


    }
}
