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

        [HttpGet("{id:int}", Name = "GetProductByID")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<ProductDTO>> GetProductByIDAsync(
              [FromRoute] int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Invalid product id");

                Product? product = await Product.GetProductByIDAsync(id);

                if (product is null)
                    return NotFound("Product not found");

                ProductDTO productDto = product.ProductDto;

                if (productDto is null)
                    return NotFound("Product not found");

                return Ok(productDto);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    ex.Message
                );
            }
        }

        [HttpPost]

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<ProductDTO>> AddNewProductAsync(
                [FromBody] ProductRequestDTO product)
        {
            try
            {
                if (product is null)
                    return BadRequest("Product data is required.");

                if (string.IsNullOrWhiteSpace(product.ProductName) ||
                    string.IsNullOrWhiteSpace(product.Category) ||
                    string.IsNullOrWhiteSpace(product.Status))
                {
                    return BadRequest("Invalid product data.");
                }

                if (product.Price <= 0 ||
                    product.StockQuantity < 0)
                {
                    return BadRequest("Invalid product data.");
                }

                Product productObj = new Product(
                    product,
                    Enumeration.Enumerations.EnMode._kADD
                );

                if (!await productObj.SaveMode())
                    return BadRequest("Something went wrong.");

                return CreatedAtRoute(
                    "GetProductByID",
                    new { id = productObj.ProductID },
                    productObj.ProductDto
                     );
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