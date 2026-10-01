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
    }
}