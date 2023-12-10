using Application.Brew.Commands;
using Common.Constants;

namespace ReadyTech.BrewCoffee.Api.Tests.Data
{
    public static class BrewCoffeeTestData
    {
        public static BrewCoffeeQueryResponse BrewCoffeeQuerySuccessfulResponse(DateTime? dateTime = null)
        { 
            return new BrewCoffeeQueryResponse() 
            {
                StatusMessage = StatusMessageConstants.Get(200),
                PreparedDate = dateTime.HasValue ? dateTime.Value.ToString():DateTime.Now.ToString() ,
            };
            
        }
    }
}