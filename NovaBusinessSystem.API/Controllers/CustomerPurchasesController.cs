using Microsoft.AspNetCore.Mvc;
using NovaBusinessSystem.BL.Interfaces;
using NovaBusinessSystem.DTOs.Customers;

namespace NovaBusinessSystem.API.Controllers.Customers;

[ApiController]
[Route("api/customers/purchases")]
public class CustomerPurchasesController : ControllerBase
{
    private readonly IPurchasesService _purchasesService;
    private readonly ICustomersService _customersService;

    public CustomerPurchasesController(
        IPurchasesService purchasesService,
        ICustomersService customersService)
    {
        _purchasesService = purchasesService
            ?? throw new ArgumentNullException(nameof(purchasesService));

        _customersService = customersService
            ?? throw new ArgumentNullException(nameof(customersService));
    }

    [HttpGet("{customerId:int}/history", Name = "GetCustomerPurchaseHistory")]
    [ProducesResponseType(typeof(IEnumerable<CustomerPurchaseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<CustomerPurchaseDto>>> GetPurchaseHistoryAsync(
        [FromRoute] int customerId)
    {
        var customer = await _customersService.GetByIdAsync(customerId);

        if (customer is null)
            return NotFound($"Customer with ID {customerId} was not found.");

        var purchaseHistory = await _purchasesService.GetPurchaseHistoryAsync(customerId);

        return Ok(purchaseHistory);
    }

    [HttpGet("{customerId:int}/spending-summary", Name = "GetCustomerSpendingSummary")]
    [ProducesResponseType(typeof(CustomerSpendingSummaryDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CustomerSpendingSummaryDto>> GetSpendingSummaryAsync(
        [FromRoute] int customerId)
    {
        var customer = await _customersService.GetByIdAsync(customerId);

        if (customer is null)
            return NotFound($"Customer with ID {customerId} was not found.");

        var spendingSummary = await _purchasesService.GetCustomerSpendingAsync(customerId);

        if (spendingSummary is null)
            return NotFound($"No spending summary found for customer ID {customerId}.");

        return Ok(spendingSummary);
    }

    [HttpGet("{customerId:int}/favorite-products", Name = "GetCustomerFavoriteProducts")]
    [ProducesResponseType(typeof(IEnumerable<FavoriteProductDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<FavoriteProductDto>>> GetFavoriteProductsAsync(
        [FromRoute] int customerId)
    {
        var customer = await _customersService.GetByIdAsync(customerId);

        if (customer is null)
            return NotFound($"Customer with ID {customerId} was not found.");

        var favoriteProducts =
            await _purchasesService.GetCustomerFavoriteProductsAsync(customerId);

        return Ok(favoriteProducts);
    }

    [HttpGet("monthly-summary", Name = "GetCustomerMonthlyPurchaseSummary")]
    [ProducesResponseType(typeof(IEnumerable<MonthlyPurchaseSummaryDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<MonthlyPurchaseSummaryDto>>> GetMonthlyPurchaseSummaryAsync()
    {
        var monthlyPurchaseSummary =
            await _purchasesService.GetCustomerMonthlyPurchasesAsync();

        return Ok(monthlyPurchaseSummary);
    }

    [HttpGet("customer-rankings", Name = "GetCustomerRankings")]
    [ProducesResponseType(typeof(IEnumerable<CustomerRankingDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<CustomerRankingDto>>> GetCustomerRankingsAsync()
    {
        var customerRankings = await _purchasesService.GetCustomersRankingAsync();

        return Ok(customerRankings);
    }
}