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
                    [FromRoute(Name = "id")] int id)
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

        [HttpPatch("{id:int}/Add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<AddStockResultDTO>> AddStockAsync(
             [FromRoute(Name = "id")] int id,
             [FromQuery] int quantity)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Invalid product ID.");

                if (quantity <= 0)
                    return BadRequest(
                        "Quantity must be greater than zero.");

                AddStockResultDTO? result =
                    await InventoryManagement.AddStockAsync(
                        id,
                        quantity
                    );

                if (result is null)
                    return NotFound(
                        $"Product with ID {id} was not found.");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    ex.Message
                );
            }
        }

        [HttpPatch("{id:int}/Remove")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<RemoveStockResultDTO>> RemoveStockAsync(
                [FromRoute(Name = "id")] int id,
                [FromQuery] int quantity)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Invalid product ID.");

                if (quantity <= 0)
                    return BadRequest(
                        "Quantity must be greater than zero.");

                RemoveStockResultDTO? result =
                    await InventoryManagement.RemoveStockAsync(
                        id,
                        quantity
                    );

                if (result is null)
                    return NotFound(
                        $"Product with ID {id} was not found.");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    ex.Message
                );
            }
        }

        [HttpPatch("{id:int}/Adjust")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<AdjustStockResultDTO>> AdjustStockAsync(
                    [FromRoute(Name = "id")] int id,
                    [FromQuery] int actualStock)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Invalid product ID.");

                if (actualStock < 0)
                    return BadRequest("Actual stock cannot be negative.");

                AdjustStockResultDTO? result =
                    await InventoryManagement.AdjustStockAsync(
                        id,
                        actualStock
                    );

                if (result is null)
                    return NotFound(
                        $"Product with ID {id} was not found."
                    );

                return Ok(result);
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