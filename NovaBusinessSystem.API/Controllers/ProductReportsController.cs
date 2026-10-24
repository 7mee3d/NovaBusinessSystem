
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NovaBusinessSystem.BL.Products.Reports;
using NovaBusinessSystem.DTOs.Products.Reports;

[ApiController]
[Route("api/ProductReports")]
public class ProductReportsController : ControllerBase
{
    
    private readonly ReportsBL _reportsBL ;
    public ProductReportsController (ReportsBL reportsBL)
    {
        this._reportsBL = reportsBL ; 
    }


    [HttpGet("StatusSummary")]

    public async Task<Ok<IEnumerable<ProductStatusSummaryDTO>>> GetProductStatusSummariesAsync()
    {
        return TypedResults.Ok(await _reportsBL.GetProductStatusSummariesAsync());
    }
}