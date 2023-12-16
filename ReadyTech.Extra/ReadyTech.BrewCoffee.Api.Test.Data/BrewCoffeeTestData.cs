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

        public static string BrewCoofeeJsonString()
        {
            return "{\"statusMessage\":\"Yourrefreshingicedcoffeeisready\",\"preparedDate\":\"2023-12-16T18:00:33+11\"}";
        }
    }
}