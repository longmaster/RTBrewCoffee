using Application.Brew.Commands;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Text.Json;

namespace ReadyTech.BrewCoffee.Api.Integration.Tests;

public class BrewCoofeeApiIntegrationTests
{
    private readonly HttpClient _httpClient;

    public BrewCoofeeApiIntegrationTests()
    {
        var webAppFactory = new WebApplicationFactory<Program>();
        _httpClient = webAppFactory.CreateDefaultClient();

    }

    [Fact]
    public async Task Brew_Execute_ReturnValidResponse()
    {
        // Assign
        HttpResponseMessage response = await _httpClient.GetAsync("/brew-coffee");

        // Act
        string stringResult = await response.Content.ReadAsStringAsync();

        BrewCoffeeQueryResponse brewCoffeeQueryResponse = JsonSerializer.Deserialize<BrewCoffeeQueryResponse>(stringResult);

        // Assert
        Assert.NotNull(brewCoffeeQueryResponse);

        Assert.NotNull(brewCoffeeQueryResponse.StatusMessage);
        Assert.NotNull(brewCoffeeQueryResponse.PreparedDate);
    }
}