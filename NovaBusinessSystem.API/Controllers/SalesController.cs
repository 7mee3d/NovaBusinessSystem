using Microsoft.AspNetCore.Mvc;
using NovaBusinessSystem.BL.Interfaces;
using NovaBusinessSystem.DTOs.Products.Sales;

namespace NovaBusinessSystem.API.Controllers.Products.Sales;

[ApiController]
[Route("api/Sales")]
public class SalesController : ControllerBase
{
    private readonly ISalesService _service;

    public SalesController(ISalesService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpGet("{id:int}/Histories")]
    [ProducesResponseType(typeof(IEnumerable<ProductSalesHistoryDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<ProductSalesHistoryDto>>> GetProductSalesHistoriesAsync(
        [FromRoute] int id)
    {
        if (id <= 0)
            return BadRequest("Product ID must be greater than zero.");

        var histories = await _service.GetProductSalesHistoriesAsync(id);
        return Ok(histories);
    }

    [HttpGet("{id:int}/Summaries")]
    [ProducesResponseType(typeof(IEnumerable<ProductSalesSummaryDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ProductSalesSummaryDto>>> GetProductSalesSummariesAsync(
        [FromRoute] int id)
    {
        if (id <= 0)
            return BadRequest("Product ID must be greater than zero.");

        var summaries = await _service.GetProductSalesSummariesAsync(id);
        return Ok(summaries);
    }

    [HttpGet("TopSelling")]
    [ProducesResponseType(typeof(IEnumerable<TopSellingProductDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<TopSellingProductDto>>> GetTopSellingProductsAsync(
        [FromQuery] int rank)
    {
        if (rank <= 0)
            return BadRequest("Rank must be greater than zero.");

        var products = await _service.GetTopSellingProductsAsync(rank);
        return Ok(products);
    }

    [HttpGet("LeastSelling")]
    [ProducesResponseType(typeof(IEnumerable<LeastSellingProductDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<LeastSellingProductDto>>> GetLeastSellingProductsAsync(
        [FromQuery] int rank)
    {
        if (rank <= 0)
            return BadRequest("Rank must be greater than zero.");

        var products = await _service.GetLeastSellingProductsAsync(rank);
        return Ok(products);
    }

    [HttpGet("RevenueRankings")]
    [ProducesResponseType(typeof(IEnumerable<ProductRevenueRankingDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ProductRevenueRankingDto>>> GetProductRevenueRankingsAsync(
        [FromQuery] int rank)
    {
        if (rank <= 0)
            return BadRequest("Rank must be greater than zero.");

        var rankings = await _service.GetProductRevenueRankingsAsync(rank);
        return Ok(rankings);
    }

    [HttpGet("{id:int}/Monthly")]
    [ProducesResponseType(typeof(IEnumerable<MonthlyProductSalesDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MonthlyProductSalesDto>>> GetMonthlyProductSalesAsync(
        [FromRoute] int id)
    {
        if (id <= 0)
            return BadRequest("Product ID must be greater than zero.");

        var monthlySales = await _service.GetMonthlyProductSalesAsync(id);
        return Ok(monthlySales);
    }

    [HttpGet("CategoryPerformances")]
    [ProducesResponseType(typeof(IEnumerable<CategoryPerformanceDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<CategoryPerformanceDto>>> GetCategoryPerformancesAsync()
    {
        var performances = await _service.GetCategoryPerformancesAsync();
        return Ok(performances);
    }

    [HttpGet("{id:int}/CustomerSales")]
    [ProducesResponseType(typeof(ProductCustomerSalesDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductCustomerSalesDto>> GetProductCustomerSalesAsync(
        [FromRoute] int id)
    {
        if (id <= 0)
            return BadRequest("Product ID must be greater than zero.");

        var customerSales = await _service.GetProductCustomerSalesAsync(id);

        if (customerSales is null)
            return NotFound($"Sales analysis for product ID {id} was not found.");

        return Ok(customerSales);
    }
}