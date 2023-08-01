using Autofac.Extras.FakeItEasy;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using SierraTakeHome.API.Controllers;
using SierraTakeHome.Core.Applications.Orders;
using SierraTakeHome.Core.Data;
using SierraTakeHome.Core.Models.Orders;

namespace SierraTakeHome.Core.Test.API
{
    public class OrderControllerTest : IDisposable
    {
        private readonly AutoFake _faker;
        private readonly IUnitOfWork _unitOfWork;

        public OrderControllerTest()
        {
            _faker = new AutoFake();
            _unitOfWork = A.Fake<IUnitOfWork>();
        }

        [Fact]
        public void CreateOrder_Valid_Command()
        {
            // Arrange
            var appService = new OrderAppService(_unitOfWork);
            var controller = new OrderController(appService);

            var command = new OrderCommand 
            { CustomerId = 1, ProductId = 2, Quantity = 5 };

            // Fake objects
            var order = A.Fake<Order>();
            var newOrderId = 1;
            A.CallTo(() => _unitOfWork.Orders.Create(order)).Returns(newOrderId);

            // Act
            var result = controller.Post(command);

            // Assert
            result.Result.Should().BeOfType<OkResult>();
        }

        [Fact]
        public void CreateOrder_InvalidProductId_Command()
        {
            // Arrange
            var appService = new OrderAppService(_unitOfWork);
            var controller = new OrderController(appService);

            var command = new OrderCommand
            { CustomerId = 1, ProductId = 0, Quantity = 5 };

            // Fake objects
            var order = A.Fake<Order>();
            var newOrderId = 1;
            A.CallTo(() => _unitOfWork.Orders.Create(order)).Returns(newOrderId);

            // Act
            var result = controller.Post(command);

            // Assert
            result.Result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public void CreateOrder_InvalidNegativeQuantity_Command()
        {
            // Arrange
            var appService = new OrderAppService(_unitOfWork);
            var controller = new OrderController(appService);

            var command = new OrderCommand
            { CustomerId = 1, ProductId = 2, Quantity = -5 };

            // Fake objects
            var order = A.Fake<Order>();
            var newOrderId = 1;
            A.CallTo(() => _unitOfWork.Orders.Create(order)).Returns(newOrderId);

            // Act
            var result = controller.Post(command);

            // Assert
            result.Result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public void CreateOrder_InvalidZeroQuantity_Command()
        {
            // Arrange
            var appService = new OrderAppService(_unitOfWork);
            var controller = new OrderController(appService);

            var command = new OrderCommand
            { CustomerId = 1, ProductId = 2, Quantity = 0 };

            // Fake objects
            var order = A.Fake<Order>();
            var newOrderId = 1;
            A.CallTo(() => _unitOfWork.Orders.Create(order)).Returns(newOrderId);

            // Act
            var result = controller.Post(command);

            // Assert
            result.Result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public void CreateOrder_Null_Command()
        {
            // Arrange
            var appService = new OrderAppService(_unitOfWork);
            var controller = new OrderController(appService);

            // Fake objects
            var order = A.Fake<Order>();
            var newOrderId = 1;
            A.CallTo(() => _unitOfWork.Orders.Create(order)).Returns(newOrderId);

            // Act
            var result = controller.Post(null);

            // Assert
            result.Result.Should().BeOfType<NotFoundResult>();
        }

        public void Dispose()
        {
            _faker?.Dispose();
        }
    }
}