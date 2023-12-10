using MediatR;

namespace Application.Brew.Commands
{
    public class BrewCoffeeQuery : IRequest<BrewCoffeeQueryResponse>
    {
    }
}
