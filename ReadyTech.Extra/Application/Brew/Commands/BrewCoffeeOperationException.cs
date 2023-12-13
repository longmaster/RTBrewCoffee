using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Common.Exceptions;
using Common.Interfaces;

namespace Application.Brew.Commands;
public class BrewCoffeeOperationException: IBrewCoffeeOperationException
{
    private readonly IDateTimeSnapshot _dateTimeSnapshot;

    private readonly ICoffeeCounter _coffeesCounter;


    private const int MaxCoffee = 5;

    public BrewCoffeeOperationException(
        IDateTimeSnapshot dateTimeSnapshot,
        ICoffeeCounter coffeeCounter)
    {
        _dateTimeSnapshot = dateTimeSnapshot;
        _coffeesCounter = coffeeCounter;
    }

    public void Execute()
    {
        if (_coffeesCounter.Counter == MaxCoffee)
        {
            throw new OutOfCoffeeException();

        }
        else if (_dateTimeSnapshot.GetDate is { Day: 01, Month: 04 })
        {
            throw new AprilFoolException();
        }
    }
}
