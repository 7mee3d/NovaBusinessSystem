using Microsoft.AspNetCore.Mvc;
using NovaBusinessSystem.BL.Interfaces;
using NovaBusinessSystem.DTOs.Products.Inventory;

namespace NovaBusinessSystem.API.Controllers.Products.Inventory;

[ApiController]
[Route("api/Products/Inventory")]
public class InventoryController : ControllerBase
{
    private readonly IInventoryService _service;

    public InventoryController(IInventoryService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(ProductStockResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ProductStockResponseDto>> ViewProductStockAsync([FromRoute] int id)
    {
        if (id <= 0)
            return BadRequest("Product ID must be greater than zero.");

        var productStock = await _service.ViewProductStockAsync(id);

        if (productStock is null)
            return NotFound($"Product with ID {id} was not found.");

        return Ok(productStock);
    }

    [HttpPatch("{id:int}/Add")]
    [ProducesResponseType(typeof(AddStockResultDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<AddStockResultDto>> AddStockAsync(
        [FromRoute] int id,
        [FromQuery] int quantity)
    {
        if (id <= 0)
            return BadRequest("Product ID must be greater than zero.");

        if (quantity <= 0)
            return BadRequest("Quantity must be greater than zero.");

        var result = await _service.AddStockAsync(id, quantity);

        if (result is null)
            return NotFound($"Product with ID {id} was not found.");

        return Ok(result);
    }

    [HttpPatch("{id:int}/Remove")]
    [ProducesResponseType(typeof(RemoveStockResultDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<RemoveStockResultDto>> RemoveStockAsync(
        [FromRoute] int id,
        [FromQuery] int quantity)
    {
        if (id <= 0)
            return BadRequest("Product ID must be greater than zero.");

        if (quantity <= 0)
            return BadRequest("Quantity must be greater than zero.");

        var result = await _service.RemoveStockAsync(id, quantity);

        if (result is null)
            return NotFound($"Product with ID {id} was not found.");

        return Ok(result);
    }

    [HttpPatch("{id:int}/Adjust")]
    [ProducesResponseType(typeof(AdjustStockResultDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<AdjustStockResultDto>> AdjustStockAsync(
        [FromRoute] int id,
        [FromQuery] int actualStock)
    {
        if (id <= 0)
            return BadRequest("Product ID must be greater than zero.");

        if (actualStock < 0)
            return BadRequest("Actual stock cannot be negative.");

        var result = await _service.AdjustStockAsync(id, actualStock);

        if (result is null)
            return NotFound($"Product with ID {id} was not found.");

        return Ok(result);
    }

    [HttpGet("LowStock")]
    [ProducesResponseType(typeof(IEnumerable<LowStockProductDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<LowStockProductDto>>> GetLowStockProducts(
        [FromQuery] int threshold)
    {
        if (threshold <= 0)
            return BadRequest("Threshold must be greater than zero.");

        var products = await _service.GetLowStockProducts(threshold);

        return Ok(products);
    }

    [HttpGet("OutStock")]
    [ProducesResponseType(typeof(IEnumerable<OutOfStockProductDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<OutOfStockProductDto>>> GetOutOfStockProducts()
    {
        var products = await _service.GetOutOfStockProducts();

        return Ok(products);
    }

    [HttpGet("Values")]
    [ProducesResponseType(typeof(InventoryValueDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<InventoryValueDto>> GetInventoryValueAsync()
    {
        var inventoryValue = await _service.GetInventoryValueAsync();

        if (inventoryValue is null)
            return NotFound("Inventory value data was not found.");

        return Ok(inventoryValue);
    }
}