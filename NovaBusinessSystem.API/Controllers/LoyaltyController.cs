using Microsoft.AspNetCore.Mvc;
using NovaBusinessSystem.BL.Interfaces;
using NovaBusinessSystem.DTOs.Customers.Loyalty;

namespace NovaBusinessSystem.API.Controllers.Customers;

[ApiController]
[Route("api/Customers/Loyalty")]
public class LoyaltyController : ControllerBase
{
    private readonly ILoyaltyService _loyaltyService;
    private readonly ICustomersService _customersService;

    public LoyaltyController(
        ILoyaltyService loyaltyService,
        ICustomersService customersService)
    {
        _loyaltyService = loyaltyService
            ?? throw new ArgumentNullException(nameof(loyaltyService));

        _customersService = customersService
            ?? throw new ArgumentNullException(nameof(customersService));
    }

    [HttpGet("{id:int}/Points")]
    [ProducesResponseType(typeof(CustomerPointsDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CustomerPointsDto>> GetCustomerPointsAsync(
        [FromRoute] int id)
    {
        if (id <= 0)
            return BadRequest("Customer ID must be greater than zero.");

        var customerPoints = await _loyaltyService.GetCustomerPointsAsync(id);

        if (customerPoints is null)
            return NotFound($"Customer with ID {id} was not found.");

        return Ok(customerPoints);
    }

    [HttpPatch("{id:int}/Points/Add")]
    [ProducesResponseType(typeof(PointsTransactionResultDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<PointsTransactionResultDto>> AddPointsAsync(
        [FromRoute] int id,
        [FromQuery] int points)
    {
        if (id <= 0 || points <= 0)
            return BadRequest("Customer ID and points must be greater than zero.");

        var customer = await _customersService.GetByIdAsync(id);

        if (customer is null)
            return NotFound($"Customer with ID {id} was not found.");

        int previousPoints = customer.LoyaltyPoints;

        var added = await _loyaltyService.AddPointsAsync(id, points);

        if (!added)
            return Conflict("Unable to add loyalty points.");

        var result = new PointsTransactionResultDto(
            $"{customer.FirstName} {customer.LastName}",
            previousPoints,
            points,
            previousPoints + points
        );

        return Ok(result);
    }

    [HttpPatch("{id:int}/Points/Redeem")]
    [ProducesResponseType(typeof(PointsTransactionResultDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<PointsTransactionResultDto>> RedeemPointsAsync(
        [FromRoute] int id,
        [FromQuery] int points)
    {
        if (id <= 0 || points <= 0)
            return BadRequest("Customer ID and points must be greater than zero.");

        var customer = await _customersService.GetByIdAsync(id);

        if (customer is null)
            return NotFound($"Customer with ID {id} was not found.");

        int previousPoints = customer.LoyaltyPoints;

        if (points > previousPoints)
            return Conflict("Insufficient loyalty points.");

        var redeemed = await _loyaltyService.RedeemPointsAsync(id, points);

        if (!redeemed)
            return Conflict("Unable to redeem loyalty points.");

        var result = new PointsTransactionResultDto(
            $"{customer.FirstName} {customer.LastName}",
            previousPoints,
            points,
            previousPoints - points
        );

        return Ok(result);
    }

    [HttpGet("TopCustomers")]
    [ProducesResponseType(typeof(IEnumerable<TopLoyaltyCustomerDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<TopLoyaltyCustomerDto>>> GetTopLoyaltyCustomersAsync()
    {
        var customers = await _loyaltyService.GetTopLoyaltyCustomersAsync();

        return Ok(customers);
    }

    [HttpGet("Statistics")]
    [ProducesResponseType(typeof(LoyaltyStatisticsDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<LoyaltyStatisticsDto>> GetLoyaltyStatisticsAsync()
    {
        var statistics = await _loyaltyService.GetLoyaltyStatisticsAsync();

        if (statistics is null)
            return NotFound("Loyalty statistics were not found.");

        return Ok(statistics);
    }
}