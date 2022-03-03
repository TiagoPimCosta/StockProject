using Moq;
using StockProject.Business;
using StockProject.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Microsoft.Extensions.Logging;
using AutoFixture;
using StockProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace StockProject.Tests
{
    [Trait("Category", "Product")]
    public class ProductControllerTests
    {
        private readonly ProductController productController;
        private readonly Mock<IBusiness> productBusinessMock;
        private readonly Mock<ILogger<ProductController>> loggerMock;
        private readonly Fixture fixture;

        public ProductControllerTests()
        {
            this.productBusinessMock = new Mock<IBusiness>();
            this.loggerMock = new Mock<ILogger<ProductController>>();
            this.productController = new ProductController(loggerMock.Object, productBusinessMock.Object);
            this.fixture = new Fixture();
        }
        [Fact]
        public void GetProducts_Success()
        {
            //Arrange
            var productsDtoList = this.fixture.CreateMany<ProductDto>();
            this.productBusinessMock.Setup(p => p.GetProducts()).Returns(productsDtoList);
            

            //Act
            var result = productController.GetProducts();
            var okObjectResult = result as OkObjectResult;

            //Assert
            Assert.NotNull(okObjectResult);
            Assert.NotNull(result);
            Assert.Equal(okObjectResult, result);


        }

        [Fact]
        public void GetProduct_Success()
        {
            //Arrange
            var productDto = this.fixture.Create<ProductDto>();
            this.productBusinessMock.Setup(p => p.GetProduct(productDto.Name)).Returns(productDto);

            //Act
            var result = productController.GetProduct(productDto.Name);
            var okObjectResult = result as OkObjectResult;

            //Assert
            Assert.NotNull(okObjectResult);
            Assert.NotNull(result);
            Assert.Equal(okObjectResult, result);
        }

        [Fact]
        public void CreateProduct_Success()
        {
            //Arrange
            var productDto = this.fixture.Create<ProductDto>();
            this.productBusinessMock.Setup(p => p.AddProduct(productDto));

            //Act
            var result = productController.CreateProduct(productDto);
            var okObjectResult = result as OkObjectResult;

            //Assert
            Assert.NotNull(okObjectResult);
            Assert.NotNull(result);
            Assert.Equal(okObjectResult, result);
        }
        
        [Fact]
        public void UpdateStockProduct_Success()
        {
            //Arrange
            var updateStockProductDto = this.fixture.Create<UpdateStockProductDto>();
            this.productBusinessMock.Setup(p => p.UpdateStockProduct(updateStockProductDto));

            //Act
            var result = productController.UpdateStockProduct(updateStockProductDto);
            var okObjectResult = result as OkObjectResult;

            //Assert
            Assert.NotNull(okObjectResult);
            Assert.NotNull(result);
            Assert.Equal(okObjectResult, result);
        }
    }
}
