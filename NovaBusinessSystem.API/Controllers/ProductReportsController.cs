
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NovaBusinessSystem.BL.Products.Reports;
using NovaBusinessSystem.DTOs.Products.Reports;

[ApiController]
[Route("api/ProductReports")]
public class ProductReportsController : ControllerBase
{

    private readonly ReportsBL _reportsBL;
    public ProductReportsController(ReportsBL reportsBL)
    {
        this._reportsBL = reportsBL;
    }


    [HttpGet("StatusSummary")]
    [ProducesResponseType(typeof(IEnumerable<ProductStatusSummaryDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<Ok<IEnumerable<ProductStatusSummaryDTO>>> GetProductStatusSummariesAsync()
    {
        return TypedResults.Ok(await _reportsBL.GetProductStatusSummariesAsync());
    }

    [HttpGet("Category")]
    [ProducesResponseType(typeof(IEnumerable<ProductsByCategoryDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<Ok<IEnumerable<ProductsByCategoryDTO>>> GetProductByCategoriesAsync()
    {
        return TypedResults.Ok(await _reportsBL.GetProductByCategoriesAsync());
    }

    [HttpGet("StockLevels")]
    [ProducesResponseType(typeof(IEnumerable<StockLevelReportDTO>), StatusCodes.Status200OK)]

    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public async Task<Ok<IEnumerable<StockLevelReportDTO>>> GetStockLevelReportsAsync()
    {
        return TypedResults.Ok(await _reportsBL.GetStockLevelReportsAsync());
    }

    [HttpGet("InventoryValuation")]
    [ProducesResponseType(typeof(IEnumerable<InventoryValuationDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public async Task<Ok<IEnumerable<InventoryValuationDTO>>> GetInventoryValuationsAsync()
    {
        return TypedResults.Ok(await _reportsBL.GetInventoryValuationsAsync());
    }


    [HttpGet("SalesPerformance")]
    [ProducesResponseType(typeof(IEnumerable<SalesPerformanceReportDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public async Task<Ok<IEnumerable<SalesPerformanceReportDTO>>> GetSalesPerformanceReportsAsync()
    {
        return TypedResults.Ok(await _reportsBL.GetSalesPerformanceReportsAsync());
    }


    [HttpGet("CategoryRevenue")]
    [ProducesResponseType(typeof(IEnumerable<CategoryRevenueReportDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public async Task<Ok<IEnumerable<CategoryRevenueReportDTO>>> GetCategoryRevenueReportsAsync()
    {
        return TypedResults.Ok(await _reportsBL.GetCategoryRevenueReportsAsync());
    }

    [HttpGet("TopSellingProducts")]
    [ProducesResponseType(typeof(IEnumerable<TopSellingProductDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<IActionResult> GetTopSellingProductsAsync(
    [FromQuery] int rank)
    {
        if (rank <= 0)
            return BadRequest("Rank is reqired");

        var products = await _reportsBL.GetTopSellingProductsAsync(rank);

        return Ok(products);
    }

    [HttpGet("SlowMovingProducts")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<Results<Ok<IEnumerable<SlowMovingProductDTO>>, BadRequest<string>>> GetSlowMovingProductsAsync(
    [FromQuery(Name = "maximumUnitsSold")] int maximumUnitsSold)
    {
        if (maximumUnitsSold <= 0)
            return TypedResults.BadRequest($"The {nameof(maximumUnitsSold)} is not valid");

        return TypedResults.Ok(
            await _reportsBL.GetSlowMovingProductsAsync(maximumUnitsSold));
    }

    [HttpGet("UnsoldProducts")]
    [ProducesResponseType(typeof(IEnumerable<UnsoldProductDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<Ok<IEnumerable<UnsoldProductDTO>>> GetUnsoldProductsAsync()
    {
        return TypedResults.Ok(
            await _reportsBL.GetUnsoldProductsAsync());
    }
}