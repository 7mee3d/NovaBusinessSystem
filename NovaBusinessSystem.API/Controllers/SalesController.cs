using Microsoft.AspNetCore.Mvc;
using NovaBusinessSystem.BL.Products;
using NovaBusinessSystem.BL.Products.Sales;
using NovaBusinessSystem.DTOs.Products.Sales;

namespace NovaBusinessSystem.API
{
    [ApiController]
    [Route("api/Sales")]
    public class SalesController : ControllerBase
    {

        [HttpGet("{id:int}")]

        public async Task<ActionResult<IEnumerable<ProductSalesHistoryDTO>>> GetProductSalesHistoriesAsync(
            [FromRoute(Name = "id")] int id
        )

        {

            try
            {
                if (id <= 0)
                    return BadRequest("Invalid product id");

                Product product = await Product.GetProductByIDAsync(id);

                if (product is null)
                    return NotFound($"The Product id [{id}] does not exists");

                List<ProductSalesHistoryDTO> L_ProductSalesHistories = (await Sales.GetProductSalesHistoriesAsync(id)!).ToList();

                return Ok(L_ProductSalesHistories);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}