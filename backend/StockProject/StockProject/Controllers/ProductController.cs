using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StockProject.Business;
using StockProject.Models;
using System;


namespace StockProject.Controllers
{
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
            if(_productBusiness.GetProducts() == null)
            {
                return NotFound();
            }
            
            return Ok(_productBusiness.GetProducts());
        }

        [HttpGet("{name}")]
        public IActionResult GetProduct(string name)
        {
            if(_productBusiness.GetProduct(name) == null)
            {
                return NotFound();
            }
            
            return Ok(_productBusiness.GetProduct(name));
        }

        [HttpPost("addProduct")]
        public IActionResult CreateProduct(ProductDto productDto)
        {
            if(_productBusiness.AddProduct(productDto) == null)
            {
                return NotFound();
            }

            _logger.LogInformation($"{productDto.CreationTime.TimeOfDay}");
            
            return Ok(_productBusiness.AddProduct(productDto));
        }

        [HttpPut("in")]
        public IActionResult UpdateStockInProduct(ProductDto productDto)
        {
            if(_productBusiness.StockInProduct(productDto) == null)
            {
                return NotFound();
            }

            //_logger.LogInformation($"{productDto.CreationTime.TimeOfDay}");

            //return Ok(_productBusiness.StockInProduct(productDto));
            return Ok();
        }
    }
}
