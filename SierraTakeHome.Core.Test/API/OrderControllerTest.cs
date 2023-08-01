using SierraTakeHome.API.Controllers;
using SierraTakeHome.Core.Applications.Orders;
using SierraTakeHome.Core.Data;

namespace SierraTakeHome.Core.Test.API
{
    public class OrderControllerTest
    {
        private readonly OrderController _controller;

        public OrderControllerTest()
        {
            var unitOfWork = new UnitOfWork(null);
            var appService = new OrderAppService(unitOfWork);
            _controller = new OrderController(appService);
        }

        [Fact]
        public void CreateOrder()
        {
            // Arrange
            var command = new OrderCommand();

            // Act
            var result = _controller.Post(command);

            // Assert
            Assert.NotNull(result);
        }
    }
}