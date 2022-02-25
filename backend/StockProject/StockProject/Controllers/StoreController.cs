using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StockProject.Business;
using StockProject.Entities;
using StockProject.Models;
using System;
using System.Linq;

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
            try
            {
                var stores = _storeBusiness.GetStores();

                if (stores.Count() == 0)
                {
                    return NotFound("There are no stores.");
                }
                return Ok(stores);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{name}")]
        public IActionResult GetStore(string name)
        {
            try
            {
                var store = _storeBusiness.GetStore(name);

                if (store == null)
                {
                    return NotFound($"{name} Store was not found.");
                }

                return Ok(store);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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

                _logger.LogInformation($"Store: {storeDto.Name} was added.");

               
                return Created(storeDto.Name,storeDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeleteStore(DeleteStoreDto deleteStoreDto)
        {
            try
            {
                _storeBusiness.RemoveStore(deleteStoreDto);

                _logger.LogInformation($"Store: {deleteStoreDto.Name} was deleted.");

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateStore")]
        public IActionResult UpdateStore(StoreDto storeDto)
        {
            try
            {
                _storeBusiness.UpdateStore(storeDto);

                _logger.LogInformation($"Store: {storeDto.Name} was updated.");

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
