using Microsoft.AspNetCore.Mvc;
using NovaBusinessSystem.BL.Interfaces;
using NovaBusinessSystem.DTOs.Products.Reports;

namespace NovaBusinessSystem.API.Controllers.Products.Reports;

[ApiController]
[Route("api/ProductReports")]
public class ProductReportsController : ControllerBase
{
    private readonly IProductsReportsService _service;

    public ProductReportsController(IProductsReportsService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpGet("StatusSummary")]
    [ProducesResponseType(typeof(IEnumerable<ProductStatusSummaryReportDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<ProductStatusSummaryReportDto>>> GetProductStatusSummariesAsync()
    {
        var reports = await _service.GetProductStatusSummariesAsync();
        return Ok(reports);
    }

    [HttpGet("Category")]
    [ProducesResponseType(typeof(IEnumerable<ProductsByCategoryReportDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<ProductsByCategoryReportDto>>> GetProductByCategoriesAsync()
    {
        var reports = await _service.GetProductByCategoriesAsync();
        return Ok(reports);
    }

    [HttpGet("StockLevels")]
    [ProducesResponseType(typeof(IEnumerable<StockLevelReportDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<StockLevelReportDto>>> GetStockLevelReportsAsync()
    {
        var reports = await _service.GetStockLevelReportsAsync();
        return Ok(reports);
    }

    [HttpGet("InventoryValuation")]
    [ProducesResponseType(typeof(IEnumerable<InventoryValuationReportDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<InventoryValuationReportDto>>> GetInventoryValuationsAsync()
    {
        var reports = await _service.GetInventoryValuationsAsync();
        return Ok(reports);
    }

    [HttpGet("SalesPerformance")]
    [ProducesResponseType(typeof(IEnumerable<SalesPerformanceReportDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<SalesPerformanceReportDto>>> GetSalesPerformanceReportsAsync()
    {
        var reports = await _service.GetSalesPerformanceReportsAsync();
        return Ok(reports);
    }

    [HttpGet("CategoryRevenue")]
    [ProducesResponseType(typeof(IEnumerable<CategoryRevenueReportDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<CategoryRevenueReportDto>>> GetCategoryRevenueReportsAsync()
    {
        var reports = await _service.GetCategoryRevenueReportsAsync();
        return Ok(reports);
    }

    [HttpGet("TopSellingProducts")]
    [ProducesResponseType(typeof(IEnumerable<TopSellingProductReportDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<TopSellingProductReportDto>>> GetTopSellingProductsAsync(
        [FromQuery] int rank)
    {
        if (rank <= 0)
            return BadRequest("Rank must be greater than zero.");

        var products = await _service.GetTopSellingProductsAsync(rank);
        return Ok(products);
    }

    [HttpGet("SlowMovingProducts")]
    [ProducesResponseType(typeof(IEnumerable<SlowMovingProductReportDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<SlowMovingProductReportDto>>> GetSlowMovingProductsAsync(
        [FromQuery] int maximumUnitsSold)
    {
        if (maximumUnitsSold <= 0)
            return BadRequest("Maximum units sold must be greater than zero.");

        var products = await _service.GetSlowMovingProductsAsync(maximumUnitsSold);
        return Ok(products);
    }

    [HttpGet("UnsoldProducts")]
    [ProducesResponseType(typeof(IEnumerable<UnsoldProductReportDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<UnsoldProductReportDto>>> GetUnsoldProductsAsync()
    {
        var products = await _service.GetUnsoldProductsAsync();
        return Ok(products);
    }

    [HttpGet("MonthlyPerformance")]
    [ProducesResponseType(typeof(IEnumerable<MonthlyProductPerformanceReportDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<MonthlyProductPerformanceReportDto>>> GetMonthlyProductPerformanceAsync()
    {
        var reports = await _service.GetMonthlyProductPerformanceAsync();
        return Ok(reports);
    }
}