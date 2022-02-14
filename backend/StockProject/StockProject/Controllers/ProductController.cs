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
        private readonly IMapper _mapper;

        public ProductController(ILogger<ProductController> logger, IBusiness productBusiness, IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _productBusiness = productBusiness ?? throw new ArgumentNullException(nameof(productBusiness));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        
        
        
        [HttpGet]
        public IActionResult GetProducts()
        {

            var products = _productBusiness.GetProducts();

            if(products == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
        }

        [HttpGet("{name}")]
        public IActionResult GetProduct(string name)
        {
            var product = _productBusiness.GetProduct(name);

            if(product == null)
            {
                return NotFound();
            }
            
            return Ok(_mapper.Map<ProductDto>(product));
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductDtoForCreation productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            
            _productBusiness.AddProduct(product);

            return Ok();
        }

        [HttpPut("{name}")]
        public IActionResult UpdateProduct()
        {
            return Ok();
        }
    }
}
