using Autofac.Extras.FakeItEasy;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using SierraTakeHome.API.Controllers;
using SierraTakeHome.Core.Application.Products;
using SierraTakeHome.Core.Domain.Products;
using SierraTakeHome.Core.Infrastructure.Data;

namespace SierraTakeHome.Core.Test.API
{
    public class ProductControllerTest : IDisposable
    {
        private readonly AutoFake _faker;
        private readonly IUnitOfWork _unitOfWork;

        public ProductControllerTest()
        {
            _faker = new AutoFake();
            _unitOfWork = A.Fake<IUnitOfWork>();
        }

        [Fact]
        public async Task GetAll_Products()
        {
            // Arrange
            var appService = new ProductAppService(_unitOfWork);
            var controller = new ProductController(appService);

            // Fake objects
            var products = A.Fake <List<Product>>();
            A.CallTo(() => _unitOfWork.Products.GetAll()).Returns(products);

            // Act
            var result = await controller.Get();

            // Assert
            result.Result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async Task GetById_Product()
        {
            // Arrange
            var appService = new ProductAppService(_unitOfWork);
            var controller = new ProductController(appService);

            // Fake objects
            var productId = 1;
            var product = A.Fake<Product>();
            A.CallTo(() => _unitOfWork.Products.GetById(productId)).Returns(product);

            // Act
            var result = await controller.Get();

            // Assert
            result.Result.Should().BeOfType<OkObjectResult>();
        }

        public void Dispose()
        {
            _faker?.Dispose();
        }
    }
}