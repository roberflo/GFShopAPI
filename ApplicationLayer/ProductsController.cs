

using System.Collections.Generic;
using GFShop.ApplicationLayer.Dto.Request.Products;
using GFShop.Helpers;
using GFStore.ApplicationLayer.Dto;
using GFStore.BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GFStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductBol _productBol;
        private readonly ILogger _logger;
      public ProductsController(IProductBol productBol, ILogger<ProductsController> logger)
        {
            _productBol = productBol;
            _logger = logger;
        }
       
       [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            
            return Ok(_productBol.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(_productBol.GetById(id));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateProduct([FromBody]ProductDto productDto)
        {
            
            try
            {
                // save 
                
                return Ok(_productBol.Create(productDto));
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
           
            try
            {
                 _productBol.Delete(id);
                 return NoContent();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return NotFound(new { message = ex.Message });
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPatch("{id}")]
        public IActionResult UpdatePrice([FromBody] ChangePricePatchRequest request, int id)
        {
            
            try
            {

                 _productBol.UpdatePrice(request.Price, id);
                 _logger.LogInformation("ChangePrice", "ChangePrice: Update product with {id} to Price {price} Updated", request,id);
                 return NoContent();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return NotFound(new { message = ex.Message });
            }
        }


        
    }
}
