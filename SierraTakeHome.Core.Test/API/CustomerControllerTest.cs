using Autofac.Extras.FakeItEasy;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using SierraTakeHome.API.Controllers;
using SierraTakeHome.Core.Applications.Customers;
using SierraTakeHome.Core.Data;
using SierraTakeHome.Core.Models.Customers;

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
        public void GetAll_Customers()
        {
            // Arrange
            var appService = new CustomerAppService(_unitOfWork);
            var controller = new CustomerController(appService);

            // Fake objects
            var products = A.Fake<List<Customer>>();
            A.CallTo(() => _unitOfWork.Customers.GetAll()).Returns(products);

            // Act
            var result = controller.Get();

            // Assert
            result.Result.Result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public void GetById_Customer()
        {
            // Arrange
            var appService = new CustomerAppService(_unitOfWork);
            var controller = new CustomerController(appService);

            // Fake objects
            var customerId = 1;
            var customer = A.Fake<Customer>();
            A.CallTo(() => _unitOfWork.Customers.GetById(customerId)).Returns(customer);

            // Act
            var result = controller.Get();

            // Assert
            result.Result.Result.Should().BeOfType<OkObjectResult>();
        }
    }
}