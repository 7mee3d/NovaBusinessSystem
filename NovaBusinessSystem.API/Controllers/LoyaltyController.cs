using Microsoft.AspNetCore.Mvc;
using NovaBusinessSystem.BL;
using NovaBusinessSystem.DTOs;

namespace NovaBusinessSystem.API
{
    [ApiController]
    [Route("api/Loyalty")]
    public class LoyaltyController : ControllerBase
    {

        [HttpGet("{id:int}")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<CustomerPointsDTO>> ViewCustomerPoints([FromRoute(Name = "id")] int id)
        {

            try
            {

                if (id < 0)
                    return BadRequest(new { Message = $"Invalid Data {id}" });

                CustomerPointsDTO? customerPointsDTO = await CustomersBL.ViewCustomerPointsAsync(id)!;

                if (customerPointsDTO is null)
                    return NotFound(new { Message = "The Customer does not exists" });

                return Ok(customerPointsDTO);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpPatch("{id:int}/{points:int}/AddPoints")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<PointsTransactionResultDTO>> ViewCustomerPoints(
            [FromRoute(Name = "id")] int id, [FromRoute(Name = "points")] int points
         )
        {

            try
            {

                if (id < 0 || points < 0)
                    return BadRequest(new { Message = $"Invalid Data" });

                CustomersBL? customer = CustomersBL.Find(id)!;

                if (customer is null)
                    return NotFound(new { Message = "The Customer does not exists" });

                if (!await customer.AddPointsToCustomerAsync(points))
                    return Conflict(new { Message = "Once happens" });

                PointsTransactionResultDTO pointsTransactionResultDTO = new PointsTransactionResultDTO(
                                string.Join(" ", customer.FirstName, customer.LastName),
                                customer.LoyaltyPoints,
                                points,
                                customer.LoyaltyPoints + points
                    );

                return Ok(pointsTransactionResultDTO);

            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpPatch("{id:int}/{points:int}/RedeemPoints")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<PointsTransactionResultDTO>> RedeemPointsCustomer(
                 [FromRoute(Name = "id")] int id, [FromRoute(Name = "points")] int points
                 )
        {

            try
            {

                if (id < 0 || points < 0)
                    return BadRequest($"Invalid Data");

                CustomersBL? customer = CustomersBL.Find(id)!;

                if (customer is null)
                    return NotFound("The Customer does not exists");

                int previousPoints = customer.LoyaltyPoints;

                if (!await customer.RedeemPointsToCustomerAsync(points))
                    return Conflict("Insufficient points.");

                PointsTransactionResultDTO pointsTransactionResultDTO = new PointsTransactionResultDTO(
                                string.Join(" ", customer.FirstName, customer.LastName),
                                customer.LoyaltyPoints,
                                points,
                                customer.LoyaltyPoints - points
                    );

                return Ok(pointsTransactionResultDTO);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }


        [HttpGet("TopCustomers")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<IEnumerable<TopLoyaltyCustomerDTO>>> GetTopLoyaltyCustomers()
        {
            try
            {

                List<TopLoyaltyCustomerDTO> topLoyaltyCustomers =
                    (await CustomersBL.GetTopLoyaltyCustomersAsync()!).ToList();

                if (!topLoyaltyCustomers.Any() || topLoyaltyCustomers.Count <= 0)
                    return NotFound("No loyalty customers found.");


                return Ok(topLoyaltyCustomers);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }

        }

        [HttpGet("Statistics")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<LoyaltyStatisticsDTO>> GetLoyaltyStatistics()
        {

            try
            {

                LoyaltyStatisticsDTO loyaltyStatisticsDTO =
                    await CustomersBL.GetLoyaltyStatisticsAsync()!;

                if (loyaltyStatisticsDTO is null)
                    return NotFound("No loyalty Statistics found.");


                return Ok(loyaltyStatisticsDTO);

            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }

        }
    }
}