
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
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
}