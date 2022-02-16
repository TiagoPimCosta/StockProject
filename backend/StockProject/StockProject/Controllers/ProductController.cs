namespace StockProject.Controllers
{
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using StockProject.Business;
    using StockProject.Models;
    using System;
    using System.Linq;

    [EnableCors("ProductPolicy")]
    [ApiController]
    [Route("api/stock")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IBusiness _productBusiness;

        public ProductController(ILogger<ProductController> logger, IBusiness productBusiness)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _productBusiness = productBusiness ?? throw new ArgumentNullException(nameof(productBusiness));
            
        }
        
        [HttpGet]
        public IActionResult GetProducts()
        {
            var productList = _productBusiness.GetProducts();

            if (!productList.Any())
            {
                return NotFound();
            }

            return Ok(productList);
        }

        [HttpGet("{name}")]
        public IActionResult GetProduct(string name)
        {
            var product = _productBusiness.GetProduct(name);

            if(product == null)
            {
                return NotFound();
            }
            
            return Ok(product);
        }

        [HttpPost("addProduct")]
        public IActionResult CreateProduct(ProductDto productDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                _productBusiness.AddProduct(productDto);

                _logger.LogInformation($"Product: {productDto.Name} was added. {DateTime.Now}");

                return Ok("Product added successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("updateStock")]
        public IActionResult UpdateStockProduct(UpdateStockProductDto updateStock)
        {
            try
            {
                _productBusiness.UpdateStockProduct(updateStock);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
