using Microsoft.AspNetCore.Mvc;
using NovaBusinessSystem.BL.Customers.Reports;
using NovaBusinessSystem.DTOs.Customers.Reports;

namespace NovaBusinessSystem.API
{

    [ApiController]
    [Route("api/CustomersReport")]
    public class CustomersReportController : ControllerBase
    {
        [HttpGet("", Name = "GetCustomerStatusSummary")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<CustomerStatusDTO>>> GetCustomerStatusSummaryAsync()
        {

            try
            {
                List<CustomerStatusDTO> customerStatuses = (await ReportBL.GetCustomerStatusSummaryAsync()!).ToList();

                if (!customerStatuses.Any() || customerStatuses.Count == 0)
                    return NotFound("Not found any Customers Status");


                return Ok(customerStatuses);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }


        }
    }
}