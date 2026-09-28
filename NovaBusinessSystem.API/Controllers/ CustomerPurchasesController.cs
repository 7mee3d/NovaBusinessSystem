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
        public async Task<ActionResult<IEnumerable<CustomerPurchaseDTO>>> GetCustomerPurchaseHistoryAsync([FromRoute(Name = "id")] int id)
        {

            try
            {
                if (id <= 0)
                    return BadRequest("Invalid Data");

                CustomersBL? customer = CustomersBL.Find(id);

                if (customer is null)
                    return NotFound("The Customer not found");

                List<CustomerPurchaseDTO> L_customerPurchases = (await CustomerPurchasesBL.GetPurchaseHistoryAsync(id)).ToList();

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
        public async Task<ActionResult<CustomerSpendingSummaryDTO>> GetCustomerSpendingAsync([FromRoute(Name = "id")] int id)
        {

            try
            {
                if (id <= 0)
                    return BadRequest("Invalid Data");

                CustomersBL? customer = CustomersBL.Find(id);

                if (customer is null)
                    return NotFound("The Customer not found");

                CustomerSpendingSummaryDTO customerSpendingSummary = await CustomerPurchasesBL.GetCustomerSpendingAsync(id)!;

                if (customerSpendingSummary is null)
                    return NotFound("Not found any Customer Spending");


                return Ok(customerSpendingSummary);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }


        }


        [HttpGet("{id:int}/FavoriteProducts", Name = "GetCustomerFavoriteProducts")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CustomerSpendingSummaryDTO>> GetCustomerFavoriteProductsAsync([FromRoute(Name = "id")] int id)
        {

            try
            {
                if (id <= 0)
                    return BadRequest("Invalid Data");

                CustomersBL? customer = CustomersBL.Find(id);

                if (customer is null)
                    return NotFound("The Customer not found");

                List<FavoriteProductDTO> L_FavoriteProducts =
                (await CustomerPurchasesBL.GetCustomerFavoriteProductsAsync(id)!).ToList();

                if (!L_FavoriteProducts.Any() || L_FavoriteProducts.Count == 0)
                    return NotFound("Not found any Customer Favorite Products");


                return Ok(L_FavoriteProducts);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }


        }

        [HttpGet("MonthlyPurchases", Name = "GetCustomerMonthlyPurchases")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<MonthlyPurchaseDTO>>> GetCustomerMonthlyPurchasesAsync()
        {

            try
            {
                List<MonthlyPurchaseDTO> monthlyPurchases = (await CustomerPurchasesBL.GetCustomerMonthlyPurchasesAsync()!).ToList();

                if (!monthlyPurchases.Any() || monthlyPurchases.Count == 0)
                    return NotFound("Not found any Customer Monthly Purchases");

                return Ok(monthlyPurchases);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }


        }

        [HttpGet("CustomersRanking", Name = "GetCustomersRankingAsync")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<MonthlyPurchaseDTO>>> GetCustomersRankingAsync()
        {

            try
            {
                List<CustomerRankingDTO> customerRankings = (await CustomerPurchasesBL.GetCustomersRankingAsync()!).ToList();

                if (!customerRankings.Any() || customerRankings.Count == 0)
                    return NotFound("Not found any Customer Ranking");

                return Ok(customerRankings);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }


        }
    }

}