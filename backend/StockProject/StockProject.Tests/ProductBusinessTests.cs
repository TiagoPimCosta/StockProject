using AutoFixture;
using AutoMapper;
using Moq;
using StockProject.Business;
using StockProject.Entities;
using StockProject.Repositories;
using System;
using Xunit;
using System.Linq;
using System.Collections.Generic;
using StockProject.Models;

namespace StockProject.Tests
{
    public class ProductBusinessTests
    {
        private readonly Mock<IRepository> productRepositoryMock;
        private readonly ProductBusiness productBusiness;
        private readonly Mock<IMapper> mapper;
        private readonly Fixture fixture;
        public ProductBusinessTests()
        {
            this.productRepositoryMock = new Mock<IRepository>();
            this.mapper = new Mock<IMapper>();
            this.productBusiness = new ProductBusiness(this.productRepositoryMock.Object, this.mapper.Object);
            this.fixture = new Fixture();
            
        }

        [Fact]
        public void GetProducts_Success()
        {
            //Arrange
            
            var productList = this.fixture.Build<Product>().Without(p => p.Id).CreateMany(10);

            /*var product = this.fixture.Create<Product>();
            var productName = this.fixture.Create<string>();
            var productListWithPrice = this.fixture.Build<Product>().With(p => p.Price, 100).CreateMany();
            var productWithoutDescription = this.fixture.Build<Product>().Without(p => p.Description).Create();
            var productWithoutName = this.fixture.Build<Product>().Without(p => p.Name).Create();
            var productL = this.fixture.Build<Product>().Without(p => p.Description).Without(p => p.Brand).With(p => p.Price, 50).CreateMany(10);*/

            //It.IsAny<IEnumerable<Product>>());
            this.productRepositoryMock.Setup(x => x.GetProducts()).Returns(productList);

            //Action
            var result = productBusiness.GetProducts();


            //Assert
            Assert.Equal(productList.Count(), result.Count());

            this.productRepositoryMock.Verify(
                x => x.GetProducts(), 
                Times.Once
                );
        }

        [Fact]
        public void GetProduct_Success()
        {
            //Arrange
            var product = this.fixture.Create<Product>();
            this.productRepositoryMock.Setup(x => x.GetProduct(product.Name)).Returns(product);
            var productDto = mapper.Object.Map<ProductDto>(product);
            //Action
            var result = productBusiness.GetProduct(product.Name);

            //Assert
            Assert.Equal(result, productDto);
        }
        
        [Fact]
        public void AddProduct()
        {
            //Arrange
            var productDto = this.fixture.Create<ProductDto>();
            var product = mapper.Object.Map<Product>(productDto);
            productRepositoryMock.Object.AddProduct(product);

            

            

            //Action
            //var result = productBusiness.AddProduct(productDto);

            //Assert
            //Assert.Equal(result,productDto); 
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

            //Action
            this.productBusiness.UpdateStockProduct(updateStockProductDto);

            //Assert
            this.productRepositoryMock.Verify(
                x => x.GetProduct(updateStockProductDto.Name),
                Times.Once
                );

            //this.productRepositoryMock.Verify(
            //    x => x.GetProduct(It.IsAny<string>()),
            //    Times.Once
            //    );

            //this.productRepositoryMock.Verify(
            //    x => x.GetProduct(It.Is<string>(a => a == updateStockProductDto.Name)),
            //    Times.Exactly(1)
            //    );

            this.productRepositoryMock.Verify(
                x => x.UpdateStockProduct(It.Is<Product>(p => 
                p.Name == product.Name &&
                p.Quantity == quantityExp &&
                p.Price == product.Price
                )),
                Times.Once
                );
        }
    }
}
