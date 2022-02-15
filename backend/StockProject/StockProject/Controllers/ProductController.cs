using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using StockProject.Business;
using StockProject.Entities;
using StockProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockProject.Controllers
{
    [EnableCors("ProductPolicy")]
    [ApiController]
    [Route("api/stock")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IBusiness _productBusiness;
        

        public ProductController(ILogger<ProductController> logger, IBusiness productBusiness, IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _productBusiness = productBusiness ?? throw new ArgumentNullException(nameof(productBusiness));
            
        }
        
        
        
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_productBusiness.GetProducts());
        }

        [HttpGet("{name}")]
        public IActionResult GetProduct(string name)
        {
            return Ok(_productBusiness.GetProduct(name));
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductDtoForCreation productDto)
        {
            return Ok();
        }

        [HttpPut("{name}")]
        public IActionResult UpdateProduct()
        {
            return Ok();
        }
    }
}
