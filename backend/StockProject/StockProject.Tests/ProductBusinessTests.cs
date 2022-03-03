using AutoFixture;
using AutoMapper;
using Moq;
using StockProject.Business;
using StockProject.Entities;
using StockProject.Models;
using StockProject.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace StockProject.Tests
{
    [Trait("Category", "Product")]
    public class ProductBusinessTests
    {
        private readonly Mock<IRepository> productRepositoryMock;
        private readonly ProductBusiness productBusiness;
        private readonly Mock<IMapper> mapperMock;
        private readonly Fixture fixture;

        

        public ProductBusinessTests()
        {
            this.productRepositoryMock = new Mock<IRepository>();
            this.mapperMock = new Mock<IMapper>();
            this.productBusiness = new ProductBusiness(this.productRepositoryMock.Object, this.mapperMock.Object);
            this.fixture = new Fixture();
        }


        [Fact]
        public void GetProducts_Success()
        {
            //Arrange
            var products = this.fixture.Build<Product>().Without(p => p.Id).CreateMany(10);
            this.productRepositoryMock.Setup(r => r.GetProducts()).Returns(products);
            var productsDto = this.mapperMock.Object.Map<IEnumerable<ProductDto>>(products);

            //Act
            var result = productBusiness.GetProducts();

            //Assert
            Assert.Equal(productsDto, result);

        }

        [Fact]
        public void GetProduct_Success()
        {
            //Arrange
            var product = this.fixture.Build<Product>().Without(p => p.Id).Create();
            this.productRepositoryMock.Setup(r => r.GetProduct(product.Name)).Returns(product);
            //this.mapperMock.Setup(m => m.Map<ProductDto>(product));
            var productDto = this.mapperMock.Object.Map<ProductDto>(product);
            
            //Act
            var result = productBusiness.GetProduct(product.Name);

            //Assert
            Assert.Equal(productDto, result);
        }

        [Fact]
        public void AddProduct_Success()
        {
            //Arrange
            var productDto = this.fixture.Create<ProductDto>();
            var product = this.mapperMock.Object.Map<Product>(productDto);
            

            this.productRepositoryMock.Setup(r => r.GetProduct(productDto.Name)).Returns(product);

            
            
            this.productRepositoryMock.Setup(r => r.AddProduct(product));
            


            //Act
            productBusiness.AddProduct(productDto);

            //Assert
            this.productRepositoryMock.Verify(
                r => r.AddProduct(product),
                Times.Once
                );

            this.productRepositoryMock.Verify(
                r => r.GetProduct(productDto.Name)
                );
        }

        [Fact]
        public void UpdateStockProduct_StockIn_Success()
        {
            //Arrange
            var nameP = this.fixture.Create<string>();
            var updateStockProductDto = this.fixture.Build<UpdateStockProductDto>().With(p => p.Name, nameP).Create();
            var product = this.fixture.Build<Product>().Without(p => p.Id).With(p => p.Name, nameP).Create();

            var quantityExp = product.Quantity + updateStockProductDto.Quantity;

            this.productRepositoryMock.Setup(x => x.GetProduct(updateStockProductDto.Name)).Returns(product);

            this.productRepositoryMock.Setup(x => x.UpdateStockProduct(product));

            //Act
            this.productBusiness.UpdateStockProduct(updateStockProductDto);

            //Assert
            this.productRepositoryMock.Verify(
                x => x.GetProduct(updateStockProductDto.Name),
                Times.Once
                );

            this.productRepositoryMock.Verify(
                x => x.UpdateStockProduct(product),
                Times.Once
                );
        }

        [Fact]
        public void UpdateStockProduct_StockOut_Success()
        {
            //Arrange
            var nameP = this.fixture.Create<string>();
            var updateStockProductDto = this.fixture.Build<UpdateStockProductDto>().With(p => p.Name, nameP).Create();
            var product = this.fixture.Build<Product>().Without(p => p.Id).With(p => p.Name, nameP).Create();

            var quantityExp = product.Quantity - updateStockProductDto.Quantity;

            this.productRepositoryMock.Setup(x => x.GetProduct(updateStockProductDto.Name)).Returns(product);

            this.productRepositoryMock.Setup(x => x.UpdateStockProduct(product));

            //Act
            this.productBusiness.UpdateStockProduct(updateStockProductDto);

            //Assert
            this.productRepositoryMock.Verify(
                x => x.GetProduct(updateStockProductDto.Name),
                Times.Once
                );

            this.productRepositoryMock.Verify(
                x => x.UpdateStockProduct(product),
                Times.Once
                );
        }

    }
}
