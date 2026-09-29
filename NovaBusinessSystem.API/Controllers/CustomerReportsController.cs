using Microsoft.AspNetCore.Mvc;
using NovaBusinessSystem.BL.Customers.Reports;
using NovaBusinessSystem.DTOs.Customers.Reports;

namespace NovaBusinessSystem.API
{

    [ApiController]
    [Route("api/CustomersReport")]
    public class CustomersReportController : ControllerBase
    {
        [HttpGet("Status", Name = "GetCustomerStatusSummary")]

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


        [HttpGet("City", Name = "GetCustomersByCity")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<CustomersByCityDTO>>> GetCustomersByCityAsync()
        {

            try
            {
                List<CustomersByCityDTO> customersByCities = (await ReportBL.GetCustomersByCityAsync()!).ToList();

                if (!customersByCities.Any() || customersByCities.Count == 0)
                    return NotFound("Not found any Customers City");


                return Ok(customersByCities);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }


        }

        [HttpGet("Loyalty", Name = "GetLoyaltySummaryReport")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<CustomersByCityDTO>>> GetLoyaltySummaryReportAsync()
        {

            try
            {
                List<LoyaltySummaryDTO> L_LoyaltySummaries = (await ReportBL.GetLoyaltySummaryReportAsync()!).ToList();

                if (!L_LoyaltySummaries.Any() || L_LoyaltySummaries.Count == 0)
                    return NotFound("Not found any Loyalty Summary");


                return Ok(L_LoyaltySummaries);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }

        }

        [HttpGet("Registration", Name = "GetRegistrationSummary")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<CustomersByCityDTO>>> GetRegistrationSummaryAsync()
        {

            try
            {
                List<RegistrationSummaryDTO> L_RegistrationSummaries = (await ReportBL.GetRegistrationSummaryAsync()!).ToList();

                if (!L_RegistrationSummaries.Any() || L_RegistrationSummaries.Count == 0)
                    return NotFound("Not found any Registration Summary");


                return Ok(L_RegistrationSummaries);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }

        }
    }
}