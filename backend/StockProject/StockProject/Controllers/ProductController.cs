using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        
        
        [HttpGet]
        public IActionResult getProducts()
        {
            return Ok(ProductDataStore.Current.Products);
        }

        [HttpGet("{id}")]
        public IActionResult getProduct(int id)
        {

            var product = ProductDataStore.Current.Products.Where(p => p.Id == id).FirstOrDefault();


            return Ok(product);
        }
    }
}
