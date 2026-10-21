using Microsoft.AspNetCore.Http.HttpResults;
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

        [HttpGet("{id:int}/Histories")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

        [HttpGet("{id:int}/Summaries")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ProductSalesSummaryDTO>>> GetProductSalesSummariesAsync(
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

                List<ProductSalesSummaryDTO> L_ProductSalesSummaries = (await Sales.ProductSalesSummariesAsync(id)!).ToList();

                return Ok(L_ProductSalesSummaries);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{rank:int}/TopSelling")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<TopSellingProductDTO>>> TopSellingProductsAsync(
                   [FromRoute(Name = "rank")] int rank
               )

        {
            try
            {
                if (rank <= 0)
                    return BadRequest("Invalid rank");

                List<TopSellingProductDTO> topSellingProducts = (await Sales.TopSellingProductsAsync(rank)!).ToList();

                return Ok(topSellingProducts);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{rank:int}/LeastSelling")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<LeastSellingProductDTO>>> GetLeastSellingProductsAsync(
                [FromRoute(Name = "rank")] int rank
            )

        {
            try
            {
                if (rank <= 0)
                    return BadRequest("Invalid rank");

                List<LeastSellingProductDTO> leastSellingProducts = (await Sales.GetLeastSellingProductsAsync(rank)!).ToList();

                return Ok(leastSellingProducts);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{rank:int}/RevenueRankings")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ProductRevenueRankingDTO>>> GetProductRevenueRankingsAsync(
            [FromRoute(Name = "rank")] int rank
        )

        {
            try
            {
                if (rank <= 0)
                    return BadRequest("Invalid rank");

                List<ProductRevenueRankingDTO> productRevenueRanking = (await Sales.GetProductRevenueRankingsAsync(rank)!).ToList();

                return Ok(productRevenueRanking);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpGet("{id:int}/Monthly")]

        public async Task<Results<Ok<List<MonthlyProductSalesDTO>>, BadRequest<string>>> GetMonthlyProductSalesAsync([FromRoute(Name = "id")] int id)
        {
            if (id <= 0)
                return TypedResults.BadRequest("Invalid product id");
            var monthlyProductSales =
                await Sales.GetMonthlyProductSalesAsync(id);

            return TypedResults.Ok(monthlyProductSales.ToList());
        }

        [HttpGet("CategoryPerformances")]

        public async Task<Ok<List<CategoryPerformanceDTO>>> GetCategoryPerformancesAsync()
        {

            var categoryPerformances =
                await Sales.GetCategoryPerformancesAsync();

            return TypedResults.Ok(categoryPerformances.ToList());
        }

    }
}