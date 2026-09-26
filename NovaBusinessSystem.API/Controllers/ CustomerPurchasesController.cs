using Microsoft.AspNetCore.Mvc;
using NovaBusinessSystem.BL;
using NovaBusinessSystem.DTOs;

namespace NovaBusinessSystem.API
{
    [ApiController]
    [Route("api/CustomerPurchases")]
    public class CustomerPurchasesController : ControllerBase
    {

        [HttpGet("{id:int}", Name = "GetCustomerPurchaseHistory")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<CustomerPurchaseDTO>>> GetCustomerPurchaseHistory([FromRoute(Name = "id")] int id)
        {

            try
            {
                if (id <= 0)
                    return BadRequest("Invalid Data");

                CustomersBL? customer = CustomersBL.Find(id);

                if (customer is null)
                    return NotFound("The Customer not found");

                List<CustomerPurchaseDTO> L_customerPurchases = (await CustomerPurchasesBL.GetPurchaseHistory(id)).ToList();

                if (!L_customerPurchases.Any() || L_customerPurchases.Count == 0)
                    return NotFound("Not found any Purchase History");


                return Ok(L_customerPurchases);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }


        }

        [HttpGet("{id:int}/SpendingSummary", Name = "GetCustomerSpending")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CustomerSpendingSummaryDTO>> GetCustomerSpending([FromRoute(Name = "id")] int id)
        {

            try
            {
                if (id <= 0)
                    return BadRequest("Invalid Data");

                CustomersBL? customer = CustomersBL.Find(id);

                if (customer is null)
                    return NotFound("The Customer not found");

                CustomerSpendingSummaryDTO customerSpendingSummary = await CustomerPurchasesBL.GetCustomerSpending(id)!;

                if (customerSpendingSummary is null)
                    return NotFound("Not found any Customer Spending");


                return Ok(customerSpendingSummary);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }


        }
    }

}