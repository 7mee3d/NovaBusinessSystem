using Microsoft.AspNetCore.Mvc;
using NovaBusinessSystem.DTOs.Products.Inventory;
using NovaBusinessSystem.BL.Products.Inventory;

namespace NovaBusinessSystem.API.Controllers.Products.Inventory
{
    [Route("api/Products/Inventory")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<ProductStockDTO>> ViewProductStockAsync(
                    [FromRoute] int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Invalid product ID.");

                ProductStockDTO? productStock =
                    await InventoryManagement.ViewProductStockAsync(id);

                if (productStock is null)
                    return NotFound($"Product with ID {id} was not found.");

                return Ok(productStock);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    ex.Message
                );
            }
        }
    }

}