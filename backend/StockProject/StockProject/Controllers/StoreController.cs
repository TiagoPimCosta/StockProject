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
    [Route("api/store")]
    public class StoreController : ControllerBase
    {
        private readonly ILogger<StoreController> _logger;
        private readonly IBusinessStore _storeBusiness;

        public StoreController(ILogger<StoreController> logger, IBusinessStore storeBusiness)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _storeBusiness = storeBusiness ?? throw new ArgumentNullException(nameof(storeBusiness));
        }

        [HttpGet]
        public IActionResult GetStores()
        {
            var stores = _storeBusiness.GetStores();

            if(stores == null)
            {
                return NotFound();
            }
            return Ok(stores);
        }

        [HttpGet("{name}")]
        public IActionResult GetStore(string name)
        {
            var store = _storeBusiness.GetStore(name);

            if(store == null)
            {
                return NotFound();
            }

            return Ok(store);
        }

        [HttpPost("addStore")]
        public IActionResult AddStore(StoreDto storeDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                _storeBusiness.AddStore(storeDto);

                _logger.LogInformation($"Store: {storeDto.Name} was added. {DateTime.Now}");

                return Ok($"{storeDto.Name} Store was added with success");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
