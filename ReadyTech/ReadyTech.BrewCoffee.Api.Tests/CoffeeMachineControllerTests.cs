namespace ReadyTech.BrewCoffee.Api.Tests
{
    public class CoffeeMachineControllerTests
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
        private readonly CoffeeMachineController _coffeeMachineController;
        public CoffeeMachineControllerTests() 
        {
            _setupMockMediator(new BrewCoffeeQueryResponse());

            _coffeeMachineController = new CoffeeMachineController(_mockMediator.Object);
        }


        [Fact]
        public async Task Brew_Success_Return200()
        {
            // Assign
            _setupMockMediator(BrewCoffeeTestData.BrewCoffeeQuerySuccessfulResponse());

            // Act

            ActionResult<BrewCoffeeQueryResponse> testResponse =
                    Assert.IsType<ActionResult<BrewCoffeeQueryResponse>>
                    (await this._coffeeMachineController.Brew());

            OkObjectResult returnValue = Assert.IsType<OkObjectResult>(testResponse.Result);

            // Assert
            Assert.Equal(StatusCodes.Status200OK, returnValue.StatusCode);
          
        }

        [Fact]
        public async Task Brew_Success_ValidResponse()
        {
            // Assign
            _setupMockMediator(BrewCoffeeTestData.BrewCoffeeQuerySuccessfulResponse(new DateTime (2023,1,1)));

            // Act

            ActionResult<BrewCoffeeQueryResponse> testResponse =
                    Assert.IsType<ActionResult<BrewCoffeeQueryResponse>>
                    (await this._coffeeMachineController.Brew());

            OkObjectResult returnValue = Assert.IsType<OkObjectResult>(testResponse.Result);
            BrewCoffeeQueryResponse? brewCoffeeQueryResponse = returnValue.Value is BrewCoffeeQueryResponse ? (BrewCoffeeQueryResponse)returnValue.Value: null;

            // Assert
            Assert.Equal("Your piping hot coffee is ready", brewCoffeeQueryResponse.StatusMessage);
            Assert.Equal(brewCoffeeQueryResponse.PreparedDate.ToString(), (new DateTime(2023, 1, 1)).ToString());

        }
        [Fact]
        public async Task Brew_ThrowOutOfCoffeeException_Return503()
        {
            // Assign
            _setupMockMediatorThrowException<OutOfCoffeeException>();

            // Act

            ActionResult<BrewCoffeeQueryResponse> testResponse =
                    Assert.IsType<ActionResult<BrewCoffeeQueryResponse>>
                    (await this._coffeeMachineController.Brew());

            ObjectResult returnValue = Assert.IsType<ObjectResult>(testResponse.Result);

            // Assert
            Assert.Equal(StatusCodes.Status503ServiceUnavailable, returnValue.StatusCode);

        }

        [Fact]
        public async Task Brew_AprilFoolException_Return418Teapot()
        {
            // Assign
            _setupMockMediatorThrowException<AprilFoolException>();

            // Act

            ActionResult<BrewCoffeeQueryResponse> testResponse =
                    Assert.IsType<ActionResult<BrewCoffeeQueryResponse>>
                    (await this._coffeeMachineController.Brew());

            ObjectResult returnValue = Assert.IsType<ObjectResult>(testResponse.Result);

            // Assert
            Assert.Equal(StatusCodes.Status418ImATeapot, returnValue.StatusCode);
        }

        private void _setupMockMediator(BrewCoffeeQueryResponse brewCoffeeQueryResponse)
        {
            _mockMediator.Setup(x => x.Send(It.IsAny<BrewCoffeeQuery>(), CancellationToken.None))
                                .ReturnsAsync(brewCoffeeQueryResponse);
        }
        private void _setupMockMediatorThrowException<T>() where T : Exception, new() 
        {
            _mockMediator.Setup(x => x.Send(It.IsAny<BrewCoffeeQuery>(), CancellationToken.None))
                                .Throws<T>();
        }
    }
}