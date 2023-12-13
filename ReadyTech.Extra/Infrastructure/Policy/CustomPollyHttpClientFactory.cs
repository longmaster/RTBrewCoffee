using Flurl.Http.Configuration;

namespace Infrastructure.Policy;
public class CustomPollyHttpClientFactory : DefaultHttpClientFactory
{
    public override HttpMessageHandler CreateMessageHandler()
    {
        return new PolicyHandler
        {
            InnerHandler = base.CreateMessageHandler()
        };
    }
}
