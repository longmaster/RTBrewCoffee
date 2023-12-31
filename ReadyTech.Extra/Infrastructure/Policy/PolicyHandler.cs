﻿namespace Infrastructure.Policy;
public class PolicyHandler : DelegatingHandler
{
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {

        return (Polly.Policy.WrapAsync<HttpResponseMessage>(HttpClientPolicies.RetryPolicy, HttpClientPolicies.TimeoutPolicy))
            .ExecuteAsync(ct => base.SendAsync(request, ct), cancellationToken);
    }
}