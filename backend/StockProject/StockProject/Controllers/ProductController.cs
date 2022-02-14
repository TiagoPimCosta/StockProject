using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using StockProject.Business;
using StockProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockProject.Controllers
{
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
        public IEnumerable<Product> getProducts()
        {

            return _productBusiness.GetProducts();

            
        }

        [HttpGet("{name}")]
        public IActionResult getProduct(string name)
        {

            return Ok(_productBusiness.GetProduct(name));
        }
    }
}
