using Autofac.Extras.FakeItEasy;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using SierraTakeHome.API.Controllers;
using SierraTakeHome.Core.Application.Customers;
using SierraTakeHome.Core.Domain.Customers;
using SierraTakeHome.Core.Infrastructure.Data;

namespace SierraTakeHome.Core.Test.API
{
    public class CustomerControllerTest
    {
        private readonly AutoFake _faker;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerControllerTest()
        {
            _faker = new AutoFake();
            _unitOfWork = A.Fake<IUnitOfWork>();
        }

        public void Dispose()
        {
            _faker?.Dispose();
        }

        [Fact]
        public async Task GetAll_Customers()
        {
            // Arrange
            var appService = new CustomerAppService(_unitOfWork);
            var controller = new CustomerController(appService);

            // Fake objects
            var products = A.Fake<List<Customer>>();
            A.CallTo(() => _unitOfWork.Customers.GetAll()).Returns(products);

            // Act
            var result = await controller.Get();

            // Assert
            result.Result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async Task GetById_Customer()
        {
            // Arrange
            var appService = new CustomerAppService(_unitOfWork);
            var controller = new CustomerController(appService);

            // Fake objects
            var customerId = 1;
            var customer = A.Fake<Customer>();
            A.CallTo(() => _unitOfWork.Customers.GetById(customerId)).Returns(customer);

            // Act
            var result = await controller.Get();

            // Assert
            result.Result.Should().BeOfType<OkObjectResult>();
        }
    }
}