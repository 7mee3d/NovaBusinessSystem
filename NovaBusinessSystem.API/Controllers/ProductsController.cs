using Microsoft.AspNetCore.Mvc;
using NovaBusinessSystem.DTOs.Products;
using NovaBusinessSystem.BL.Products;

namespace NovaBusinessSystem.API
{

    [Route("api/Products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet("", Name = "GetAllProductsAsync")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProductsAsync()
        {
            try
            {
                List<ProductDTO> L_Products = (await Product.GetAllProductsAsync()).ToList();
                if (!L_Products.Any() || L_Products.Count == 0)
                    return NotFound("Not found any Products");

                return Ok(L_Products);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpGet("{id:int}", Name = "GetProductByIDAsync")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<ProductDTO>> GetProductByIDAsync([FromRoute(Name = "id")] int id)
        {
            try
            {

                if (id <= 0)
                    return BadRequest("Invalid product id");

                Product product = (await Product.GetProductByIDAsync(id));

                if (product is null)
                    return NotFound("Product not found");

                ProductDTO productDto = product.ProductDto;
                if (productDto is null)
                    return NotFound("Product not found");

                return Ok(productDto);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }
    }
}