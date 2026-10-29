using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NovaBusinessSystem.BL.Interfaces;
using NovaBusinessSystem.DTOs.Products;

namespace NovaBusinessSystem.API.Controllers;

[ApiController]
[Route("api/Products")]
public class ProductsController : ControllerBase
{
    private readonly IProductsService _service;

    public ProductsController(IProductsService service)
    {
        _service = service;
    }

    [HttpGet]
    [ProducesResponseType(
        typeof(IEnumerable<ProductResponseDto>),
        StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<Ok<IEnumerable<ProductResponseDto>>> GetAllAsync()
    {
        var products = await _service.GetAllAsync();

        return TypedResults.Ok(products);
    }

    [HttpGet("{id:int}", Name = nameof(GetProductByIdAsync))]
    [ProducesResponseType(
        typeof(ProductResponseDto),
        StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<
        Results<
            Ok<ProductResponseDto>,
            BadRequest<string>,
            NotFound<string>>> GetProductByIdAsync(
                [FromRoute] int id)
    {
        if (id <= 0)
            return TypedResults.BadRequest("Product ID must be greater than zero.");

        var product = await _service.GetProductByIDAsync(id);

        if (product is null)
            return TypedResults.NotFound("Product not found.");

        return TypedResults.Ok(product);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<CreatedAtRoute<int>> AddAsync(
        [FromBody] ProductCreateRequestDto product)
    {
        var newProductId = await _service.AddProductAsync(product);

        return TypedResults.CreatedAtRoute(
            newProductId,
            nameof(GetProductByIdAsync),
            new { id = newProductId });
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<
        Results<NoContent, BadRequest<string>, NotFound<string>>> UpdateAsync(
            [FromRoute] int id,
            [FromBody] ProductUpdateRequestDto product)
    {
        if (id <= 0)
            return TypedResults.BadRequest("Product ID must be greater than zero.");

        var updated = await _service.UpdateProductAsync(id, product);

        if (!updated)
            return TypedResults.NotFound("Product not found.");

        return TypedResults.NoContent();
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<
        Results<NoContent, BadRequest<string>, NotFound<string>>> DeleteAsync(
            [FromRoute] int id)
    {
        if (id <= 0)
            return TypedResults.BadRequest("Product ID must be greater than zero.");

        var deleted = await _service.DeleteProductAsync(id);

        if (!deleted)
            return TypedResults.NotFound("Product not found.");

        return TypedResults.NoContent();
    }
}