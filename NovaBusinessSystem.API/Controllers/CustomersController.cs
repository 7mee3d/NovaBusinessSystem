using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using NovaBusinessSystem.BL.Interfaces;
using NovaBusinessSystem.DTOs.Customers;

namespace NovaBusinessSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly ICustomersService _service;

    public CustomersController(ICustomersService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<CustomerResponseDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<CustomerResponseDto>>> GetAllAsync()
    {
        var customers = await _service.GetAllAsync();

        return Ok(customers);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(CustomerResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CustomerResponseDto>> GetByIdAsync([FromRoute] int id)
    {
        if (id <= 0)
            return BadRequest("Customer ID must be greater than zero.");

        var customer = await _service.GetByIdAsync(id);

        if (customer is null)
            return NotFound();

        return Ok(customer);
    }

    [HttpPost]
    [ProducesResponseType(typeof(CustomerResponseDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<CustomerResponseDto>> CreateAsync(
        [FromBody] CustomerCreateRequestDto customer)
    {
        if (await _service.IsEmailExistsAsync(0, customer.Email))
            return Conflict("A customer with this email already exists.");

        var customerID = await _service.AddAsync(customer);

        var createdCustomer = await _service.GetByIdAsync(customerID);

        if (createdCustomer is null)
            return Problem(
                statusCode: StatusCodes.Status500InternalServerError,
                title: "Customer creation failed",
                detail: "The customer was created, but could not be retrieved."
            );

        return CreatedAtAction(
            nameof(GetByIdAsync),
            new { id = customerID },
            createdCustomer
        );
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> UpdateAsync(
        [FromRoute] int id,
        [FromBody] CustomerCreateRequestDto customer)
    {
        if (id <= 0)
            return BadRequest("Customer ID must be greater than zero.");

        var existingCustomer = await _service.GetByIdAsync(id);

        if (existingCustomer is null)
            return NotFound();

        if (await _service.IsEmailExistsAsync(id, customer.Email))
            return Conflict("A customer with this email already exists.");

        await _service.UpdateAsync(id, customer);

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
        if (id <= 0)
            return BadRequest("Customer ID must be greater than zero.");

        var existingCustomer = await _service.GetByIdAsync(id);

        if (existingCustomer is null)
            return NotFound();

        var deleted = await _service.DeleteAsync(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}