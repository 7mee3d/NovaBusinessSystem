

==================================================
FILE: ./NovaBusinessSystem.API/Controllers/ CustomerPurchasesController.cs
==================================================
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

==================================================
FILE: ./NovaBusinessSystem.API/Controllers/CustomerReportsController.cs
==================================================
using Microsoft.AspNetCore.Mvc;
using NovaBusinessSystem.BL.Interfaces;
using NovaBusinessSystem.DTOs.Customers.Reports;

namespace NovaBusinessSystem.API.Controllers.Customers;

[ApiController]
[Route("api/customers/reports")]
public class CustomersReportController : ControllerBase
{
    private readonly IReportsService _reportsService;

    public CustomersReportController(IReportsService reportsService)
    {
        _reportsService = reportsService
            ?? throw new ArgumentNullException(nameof(reportsService));
    }

    [HttpGet("status", Name = "GetCustomerStatusSummary")]
    [ProducesResponseType(typeof(IEnumerable<CustomerStatusReportDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<CustomerStatusReportDto>>> GetCustomerStatusSummaryAsync()
    {
        var customerStatuses = await _reportsService.GetCustomerStatusSummaryAsync();

        return Ok(customerStatuses);
    }

    [HttpGet("cities", Name = "GetCustomersByCity")]
    [ProducesResponseType(typeof(IEnumerable<CustomersByCityReportDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<CustomersByCityReportDto>>> GetCustomersByCityAsync()
    {
        var customersByCity = await _reportsService.GetCustomersByCityAsync();

        return Ok(customersByCity);
    }

    [HttpGet("loyalty", Name = "GetLoyaltySummaryReport")]
    [ProducesResponseType(typeof(IEnumerable<LoyaltyLevelSummaryReportDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<LoyaltyLevelSummaryReportDto>>> GetLoyaltySummaryReportAsync()
    {
        var loyaltySummary = await _reportsService.GetLoyaltySummaryReportAsync();

        return Ok(loyaltySummary);
    }

    [HttpGet("registrations", Name = "GetCustomerRegistrationSummary")]
    [ProducesResponseType(typeof(IEnumerable<CustomerRegistrationSummaryDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<CustomerRegistrationSummaryDto>>> GetRegistrationSummaryAsync()
    {
        var registrationSummary = await _reportsService.GetRegistrationSummaryAsync();

        return Ok(registrationSummary);
    }
}

==================================================
FILE: ./NovaBusinessSystem.API/Controllers/CustomersController.cs
==================================================
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

==================================================
FILE: ./NovaBusinessSystem.API/Controllers/EmployeeReportsController.cs
==================================================

using Microsoft.AspNetCore.Mvc;
using NovaBusinessSystem.BL.Interfaces;
using NovaBusinessSystem.DTOs.Employees;

[ApiController]
[Route("api/EmployeeReports")]
public class EmployeeReportsController : ControllerBase
{

    private readonly IEmployeesReportsService _service;


    public EmployeeReportsController(IEmployeesReportsService service)
    {
        this._service = service;
    }

    [HttpGet("search")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<EmployeeSearchResponseDto>>> SearchEmployeesAsync(
        [FromQuery] EmployeeSearchRequestDto request)
    {
        var employees = await _service.GetEmployeeSearchAsync(request);

        return Ok(employees);
    }

    [HttpGet("department-summary")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<DepartmentEmployeeSummaryResponseDto>>> GetDepartmentEmployeeSummaryAsync()
    {

        var departmentSummary = await _service.GetDepartmentEmployeeSummaryAsync();

        return Ok(departmentSummary);
    }

    [HttpGet("salary-summary")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<EmployeeSalarySummaryResponseDto>>> GetEmployeeSalarySummaryAsync()
    {

        var salarysummary = await _service.GetEmployeeSalarySummaryAsync();

        return Ok(salarysummary);
    }

    [HttpGet("status-summary")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<EmployeeStatusSummaryResponseDto>>> GetEmployeeStatusSummaryAsync()
    {

        var statusSummary = await _service.GetEmployeeStatusSummaryAsync();

        return Ok(statusSummary);
    }

    [HttpGet("hiring-summary")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<EmployeeHiringSummaryResponseDto>>> GetEmployeeHiringSummaryAsync()
    {

        var hiringSummary = await _service.GetEmployeeHiringSummaryAsync();

        return Ok(hiringSummary);
    }
}


==================================================
FILE: ./NovaBusinessSystem.API/Controllers/EmployeesController.cs
==================================================
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NovaBusinessSystem.BL.Interfaces;
using NovaBusinessSystem.DTOs.Employees;

[ApiController]
[Route("api/Employees")]
public class EmployeesController : ControllerBase
{

    private readonly IEmployeesService _service;


    public EmployeesController(IEmployeesService service)
    {
        this._service = service;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<EmployeeDetailsResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<Ok<IEnumerable<EmployeeDetailsResponseDto>>> GetEmployeeDetails()
    {
        return TypedResults.Ok(await _service.GetAllAsync());
    }

    [HttpGet("{id:int}", Name = "GetEmployeeByID")]
    [ProducesResponseType(typeof(EmployeeResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<Results<Ok<EmployeeResponseDto?>, BadRequest<string>, NotFound<string>>> GetEmployeeById(
        [FromRoute(Name = "id")] int id
        )
    {
        if (id <= 0)
            return TypedResults.BadRequest("Invalid data");

        var emp = await _service.GetEmployeeAsync(id);

        if (emp is null)
            return TypedResults.NotFound("Not found employee");

        return TypedResults.Ok(emp);
    }



    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<CreatedAtRoute> AddEmployeeAsync(
        [FromBody] EmployeeCreateRequestDto employee)
    {
        var newId = await _service.AddEmployeeAsync(employee);

        return TypedResults.CreatedAtRoute(
            nameof(GetEmployeeById),
            new { ID = newId });
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<NoContent> UpdateEmployeeAsync(
        [FromRoute(Name = "id")] int id,
        [FromBody] EmployeeUpdateRequestDto employee)
    {
        var newId = await _service.UpdateEmployeeAsync(id, employee);

        return TypedResults.NoContent();
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<Results<NoContent, BadRequest<string>>> DeleteEmployeeAsync(
        [FromRoute(Name = "id")] int id
        )
    {
        var idDeleted = await _service.DeleteEmployeeAsync(id);
        if (!idDeleted)
            return TypedResults.BadRequest("Something is wrong");

        return TypedResults.NoContent();
    }


 
    }


==================================================
FILE: ./NovaBusinessSystem.API/Controllers/InventoryController.cs
==================================================
using Microsoft.AspNetCore.Mvc;
using NovaBusinessSystem.BL.Interfaces;
using NovaBusinessSystem.DTOs.Products.Inventory;

namespace NovaBusinessSystem.API.Controllers.Products.Inventory;

[ApiController]
[Route("api/Products/Inventory")]
public class InventoryController : ControllerBase
{
    private readonly IInventoryService _service;

    public InventoryController(IInventoryService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(ProductStockResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ProductStockResponseDto>> ViewProductStockAsync([FromRoute] int id)
    {
        if (id <= 0)
            return BadRequest("Product ID must be greater than zero.");

        var productStock = await _service.ViewProductStockAsync(id);

        if (productStock is null)
            return NotFound($"Product with ID {id} was not found.");

        return Ok(productStock);
    }

    [HttpPatch("{id:int}/Add")]
    [ProducesResponseType(typeof(AddStockResultDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<AddStockResultDto>> AddStockAsync(
        [FromRoute] int id,
        [FromQuery] int quantity)
    {
        if (id <= 0)
            return BadRequest("Product ID must be greater than zero.");

        if (quantity <= 0)
            return BadRequest("Quantity must be greater than zero.");

        var result = await _service.AddStockAsync(id, quantity);

        if (result is null)
            return NotFound($"Product with ID {id} was not found.");

        return Ok(result);
    }

    [HttpPatch("{id:int}/Remove")]
    [ProducesResponseType(typeof(RemoveStockResultDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<RemoveStockResultDto>> RemoveStockAsync(
        [FromRoute] int id,
        [FromQuery] int quantity)
    {
        if (id <= 0)
            return BadRequest("Product ID must be greater than zero.");

        if (quantity <= 0)
            return BadRequest("Quantity must be greater than zero.");

        var result = await _service.RemoveStockAsync(id, quantity);

        if (result is null)
            return NotFound($"Product with ID {id} was not found.");

        return Ok(result);
    }

    [HttpPatch("{id:int}/Adjust")]
    [ProducesResponseType(typeof(AdjustStockResultDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<AdjustStockResultDto>> AdjustStockAsync(
        [FromRoute] int id,
        [FromQuery] int actualStock)
    {
        if (id <= 0)
            return BadRequest("Product ID must be greater than zero.");

        if (actualStock < 0)
            return BadRequest("Actual stock cannot be negative.");

        var result = await _service.AdjustStockAsync(id, actualStock);

        if (result is null)
            return NotFound($"Product with ID {id} was not found.");

        return Ok(result);
    }

    [HttpGet("LowStock")]
    [ProducesResponseType(typeof(IEnumerable<LowStockProductDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<LowStockProductDto>>> GetLowStockProducts(
        [FromQuery] int threshold)
    {
        if (threshold <= 0)
            return BadRequest("Threshold must be greater than zero.");

        var products = await _service.GetLowStockProducts(threshold);

        return Ok(products);
    }

    [HttpGet("OutStock")]
    [ProducesResponseType(typeof(IEnumerable<OutOfStockProductDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<OutOfStockProductDto>>> GetOutOfStockProducts()
    {
        var products = await _service.GetOutOfStockProducts();

        return Ok(products);
    }

    [HttpGet("Values")]
    [ProducesResponseType(typeof(InventoryValueDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<InventoryValueDto>> GetInventoryValueAsync()
    {
        var inventoryValue = await _service.GetInventoryValueAsync();

        if (inventoryValue is null)
            return NotFound("Inventory value data was not found.");

        return Ok(inventoryValue);
    }
}

==================================================
FILE: ./NovaBusinessSystem.API/Controllers/LoyaltyController.cs
==================================================
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

==================================================
FILE: ./NovaBusinessSystem.API/Controllers/ProductReportsController.cs
==================================================
using Microsoft.AspNetCore.Mvc;
using NovaBusinessSystem.BL.Interfaces;
using NovaBusinessSystem.DTOs.Products.Reports;

namespace NovaBusinessSystem.API.Controllers.Products.Reports;

[ApiController]
[Route("api/ProductReports")]
public class ProductReportsController : ControllerBase
{
    private readonly IProductsReportsService _service;

    public ProductReportsController(IProductsReportsService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpGet("StatusSummary")]
    [ProducesResponseType(typeof(IEnumerable<ProductStatusSummaryReportDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<ProductStatusSummaryReportDto>>> GetProductStatusSummariesAsync()
    {
        var reports = await _service.GetProductStatusSummariesAsync();
        return Ok(reports);
    }

    [HttpGet("Category")]
    [ProducesResponseType(typeof(IEnumerable<ProductsByCategoryReportDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<ProductsByCategoryReportDto>>> GetProductByCategoriesAsync()
    {
        var reports = await _service.GetProductByCategoriesAsync();
        return Ok(reports);
    }

    [HttpGet("StockLevels")]
    [ProducesResponseType(typeof(IEnumerable<StockLevelReportDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<StockLevelReportDto>>> GetStockLevelReportsAsync()
    {
        var reports = await _service.GetStockLevelReportsAsync();
        return Ok(reports);
    }

    [HttpGet("InventoryValuation")]
    [ProducesResponseType(typeof(IEnumerable<InventoryValuationReportDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<InventoryValuationReportDto>>> GetInventoryValuationsAsync()
    {
        var reports = await _service.GetInventoryValuationsAsync();
        return Ok(reports);
    }

    [HttpGet("SalesPerformance")]
    [ProducesResponseType(typeof(IEnumerable<SalesPerformanceReportDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<SalesPerformanceReportDto>>> GetSalesPerformanceReportsAsync()
    {
        var reports = await _service.GetSalesPerformanceReportsAsync();
        return Ok(reports);
    }

    [HttpGet("CategoryRevenue")]
    [ProducesResponseType(typeof(IEnumerable<CategoryRevenueReportDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<CategoryRevenueReportDto>>> GetCategoryRevenueReportsAsync()
    {
        var reports = await _service.GetCategoryRevenueReportsAsync();
        return Ok(reports);
    }

    [HttpGet("TopSellingProducts")]
    [ProducesResponseType(typeof(IEnumerable<TopSellingProductReportDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<TopSellingProductReportDto>>> GetTopSellingProductsAsync(
        [FromQuery] int rank)
    {
        if (rank <= 0)
            return BadRequest("Rank must be greater than zero.");

        var products = await _service.GetTopSellingProductsAsync(rank);
        return Ok(products);
    }

    [HttpGet("SlowMovingProducts")]
    [ProducesResponseType(typeof(IEnumerable<SlowMovingProductReportDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<SlowMovingProductReportDto>>> GetSlowMovingProductsAsync(
        [FromQuery] int maximumUnitsSold)
    {
        if (maximumUnitsSold <= 0)
            return BadRequest("Maximum units sold must be greater than zero.");

        var products = await _service.GetSlowMovingProductsAsync(maximumUnitsSold);
        return Ok(products);
    }

    [HttpGet("UnsoldProducts")]
    [ProducesResponseType(typeof(IEnumerable<UnsoldProductReportDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<UnsoldProductReportDto>>> GetUnsoldProductsAsync()
    {
        var products = await _service.GetUnsoldProductsAsync();
        return Ok(products);
    }

    [HttpGet("MonthlyPerformance")]
    [ProducesResponseType(typeof(IEnumerable<MonthlyProductPerformanceReportDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<MonthlyProductPerformanceReportDto>>> GetMonthlyProductPerformanceAsync()
    {
        var reports = await _service.GetMonthlyProductPerformanceAsync();
        return Ok(reports);
    }
}

==================================================
FILE: ./NovaBusinessSystem.API/Controllers/ProductsController.cs
==================================================
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NovaBusinessSystem.BL.Interfaces;
using NovaBusinessSystem.DTOs.Products;

namespace NovaBusinessSystem.API.Controllers;

[ApiController]
[Route("api/Products")]
public class ProductsController : ControllerBase
{
    private readonly IProductsService _service;

    public ProductsController(IProductsService service)
    {
        _service = service;
    }

    [HttpGet]
    [ProducesResponseType(
        typeof(IEnumerable<ProductResponseDto>),
        StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<Ok<IEnumerable<ProductResponseDto>>> GetAllAsync()
    {
        var products = await _service.GetAllAsync();

        return TypedResults.Ok(products);
    }

    [HttpGet("{id:int}", Name = nameof(GetProductByIdAsync))]
    [ProducesResponseType(
        typeof(ProductResponseDto),
        StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<
        Results<
            Ok<ProductResponseDto>,
            BadRequest<string>,
            NotFound<string>>> GetProductByIdAsync(
                [FromRoute] int id)
    {
        if (id <= 0)
            return TypedResults.BadRequest("Product ID must be greater than zero.");

        var product = await _service.GetProductByIDAsync(id);

        if (product is null)
            return TypedResults.NotFound("Product not found.");

        return TypedResults.Ok(product);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<CreatedAtRoute<int>> AddAsync(
        [FromBody] ProductCreateRequestDto product)
    {
        var newProductId = await _service.AddProductAsync(product);

        return TypedResults.CreatedAtRoute(
            newProductId,
            nameof(GetProductByIdAsync),
            new { id = newProductId });
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<
        Results<NoContent, BadRequest<string>, NotFound<string>>> UpdateAsync(
            [FromRoute] int id,
            [FromBody] ProductUpdateRequestDto product)
    {
        if (id <= 0)
            return TypedResults.BadRequest("Product ID must be greater than zero.");

        var updated = await _service.UpdateProductAsync(id, product);

        if (!updated)
            return TypedResults.NotFound("Product not found.");

        return TypedResults.NoContent();
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<
        Results<NoContent, BadRequest<string>, NotFound<string>>> DeleteAsync(
            [FromRoute] int id)
    {
        if (id <= 0)
            return TypedResults.BadRequest("Product ID must be greater than zero.");

        var deleted = await _service.DeleteProductAsync(id);

        if (!deleted)
            return TypedResults.NotFound("Product not found.");

        return TypedResults.NoContent();
    }
}

==================================================
FILE: ./NovaBusinessSystem.API/Controllers/SalesController.cs
==================================================
using Microsoft.AspNetCore.Mvc;
using NovaBusinessSystem.BL.Interfaces;
using NovaBusinessSystem.DTOs.Products.Sales;

namespace NovaBusinessSystem.API.Controllers.Products.Sales;

[ApiController]
[Route("api/Sales")]
public class SalesController : ControllerBase
{
    private readonly ISalesService _service;

    public SalesController(ISalesService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpGet("{id:int}/Histories")]
    [ProducesResponseType(typeof(IEnumerable<ProductSalesHistoryDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<ProductSalesHistoryDto>>> GetProductSalesHistoriesAsync(
        [FromRoute] int id)
    {
        if (id <= 0)
            return BadRequest("Product ID must be greater than zero.");

        var histories = await _service.GetProductSalesHistoriesAsync(id);
        return Ok(histories);
    }

    [HttpGet("{id:int}/Summaries")]
    [ProducesResponseType(typeof(IEnumerable<ProductSalesSummaryDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ProductSalesSummaryDto>>> GetProductSalesSummariesAsync(
        [FromRoute] int id)
    {
        if (id <= 0)
            return BadRequest("Product ID must be greater than zero.");

        var summaries = await _service.GetProductSalesSummariesAsync(id);
        return Ok(summaries);
    }

    [HttpGet("TopSelling")]
    [ProducesResponseType(typeof(IEnumerable<TopSellingProductDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<TopSellingProductDto>>> GetTopSellingProductsAsync(
        [FromQuery] int rank)
    {
        if (rank <= 0)
            return BadRequest("Rank must be greater than zero.");

        var products = await _service.GetTopSellingProductsAsync(rank);
        return Ok(products);
    }

    [HttpGet("LeastSelling")]
    [ProducesResponseType(typeof(IEnumerable<LeastSellingProductDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<LeastSellingProductDto>>> GetLeastSellingProductsAsync(
        [FromQuery] int rank)
    {
        if (rank <= 0)
            return BadRequest("Rank must be greater than zero.");

        var products = await _service.GetLeastSellingProductsAsync(rank);
        return Ok(products);
    }

    [HttpGet("RevenueRankings")]
    [ProducesResponseType(typeof(IEnumerable<ProductRevenueRankingDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ProductRevenueRankingDto>>> GetProductRevenueRankingsAsync(
        [FromQuery] int rank)
    {
        if (rank <= 0)
            return BadRequest("Rank must be greater than zero.");

        var rankings = await _service.GetProductRevenueRankingsAsync(rank);
        return Ok(rankings);
    }

    [HttpGet("{id:int}/Monthly")]
    [ProducesResponseType(typeof(IEnumerable<MonthlyProductSalesDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MonthlyProductSalesDto>>> GetMonthlyProductSalesAsync(
        [FromRoute] int id)
    {
        if (id <= 0)
            return BadRequest("Product ID must be greater than zero.");

        var monthlySales = await _service.GetMonthlyProductSalesAsync(id);
        return Ok(monthlySales);
    }

    [HttpGet("CategoryPerformances")]
    [ProducesResponseType(typeof(IEnumerable<CategoryPerformanceDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<CategoryPerformanceDto>>> GetCategoryPerformancesAsync()
    {
        var performances = await _service.GetCategoryPerformancesAsync();
        return Ok(performances);
    }

    [HttpGet("{id:int}/CustomerSales")]
    [ProducesResponseType(typeof(ProductCustomerSalesDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductCustomerSalesDto>> GetProductCustomerSalesAsync(
        [FromRoute] int id)
    {
        if (id <= 0)
            return BadRequest("Product ID must be greater than zero.");

        var customerSales = await _service.GetProductCustomerSalesAsync(id);

        if (customerSales is null)
            return NotFound($"Sales analysis for product ID {id} was not found.");

        return Ok(customerSales);
    }
}

==================================================
FILE: ./NovaBusinessSystem.API/DependencyInjection.cs
==================================================
using System.Reflection;

namespace NovaBusinessSystem.API;

public static class DependencyInjection
{
    public static IServiceCollection AddProjectDependencies(
        this IServiceCollection services,
        params Assembly[] assemblies)
    {
        var types = assemblies
            .Distinct()
            .SelectMany(assembly => assembly.GetTypes())
            .Where(type => type.IsClass && !type.IsAbstract);

        foreach (var implementation in types)
        {
            var interfaces = implementation.GetInterfaces()
                .Where(i => i.Name == $"I{implementation.Name}");

            foreach (var serviceInterface in interfaces)
            {
                services.AddScoped(serviceInterface, implementation);
            }
        }

        return services;
    }
}

==================================================
FILE: ./NovaBusinessSystem.API/NovaBusinessSystem.API.csproj
==================================================
<Project Sdk="Microsoft.NET.Sdk.Web">

  <PropertyGroup>
    <TargetFramework>net10.0</TargetFramework>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.AspNetCore.OpenApi" Version="10.0.11" />
    <PackageReference Include="Swashbuckle.AspNetCore.SwaggerUI" Version="10.2.3" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="../NovaBusinessSystem.BL/NovaBusinessSystemBL.csproj" />
    <ProjectReference Include="../NovaBusinessSystem.DAL/DataAccessLayer.csproj" />
  </ItemGroup>

</Project>


==================================================
FILE: ./NovaBusinessSystem.API/Program.cs
==================================================
using System.Reflection;
using NovaBusinessSystem.BL.Services;
using NovaBusinessSystem.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddProblemDetails();
builder.Services.AddControllers();

// Auto-register project dependencies
var assemblies = new[]
{
    typeof(EmployeesService).Assembly,
    typeof(EmployeesRepository).Assembly
}.Distinct();

foreach (var assembly in assemblies)
{
    foreach (var implementation in assembly.GetTypes().Where(t =>
        t.IsClass && !t.IsAbstract && !t.IsGenericType))
    {
        foreach (var serviceInterface in implementation.GetInterfaces()
            .Where(i => i.Name == $"I{implementation.Name}"))
        {
            builder.Services.AddScoped(
                serviceInterface,
                implementation);
        }
    }
}

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseExceptionHandler();
    app.UseSwaggerUI(options =>
        options.SwaggerEndpoint(
            "/openapi/v1.json",
            "Nova Business System"));
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

==================================================
FILE: ./NovaBusinessSystem.API/Properties/launchSettings.json
==================================================
﻿{
  "$schema": "https://json.schemastore.org/launchsettings.json",
  "profiles": {
    "http": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": false,
      "applicationUrl": "http://localhost:5276",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "https": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": false,
      "applicationUrl": "https://localhost:7056;http://localhost:5276",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  }
}


==================================================
FILE: ./NovaBusinessSystem.BL/Interfaces/Customers/ICustomersRepository.cs
==================================================
using NovaBusinessSystem.DTOs;
using NovaBusinessSystem.DTOs.Customers;
using NovaBusinessSystem.DTOs.Employees;

namespace NovaBusinessSystem.BL.Interfaces;

public interface ICustomersRepository
{

    Task<IEnumerable<CustomerResponseDto>> GetAllAsync();
    Task<CustomerResponseDto?> GetByIdAsync(int CustomerID);
    Task<int> AddAsync(CustomerCreateRequestDto customerDTO);
    Task<int> UpdateAsync(int customerID, CustomerCreateRequestDto customer);
    Task<bool> DeleteAsync(int customerID);
    Task<bool> IsEmailExistsAsync(int id, string email);
}


==================================================
FILE: ./NovaBusinessSystem.BL/Interfaces/Customers/ICustomersService.cs
==================================================

using NovaBusinessSystem.DTOs.Customers;

namespace NovaBusinessSystem.BL.Interfaces;

public interface ICustomersService
{

    Task<IEnumerable<CustomerResponseDto>> GetAllAsync();
    Task<CustomerResponseDto?> GetByIdAsync(int CustomerID);
    Task<int> AddAsync(CustomerCreateRequestDto customerDTO);
    Task<int> UpdateAsync(int customerID, CustomerCreateRequestDto customer);
    Task<bool> DeleteAsync(int customerID);
    Task<bool> IsEmailExistsAsync(int id, string email);

}


==================================================
FILE: ./NovaBusinessSystem.BL/Interfaces/Employees/IEmployeesReportsRepository.cs
==================================================
using NovaBusinessSystem.DTOs.Employees;

namespace NovaBusinessSystem.BL.Interfaces;

public interface IEmployeesReportsRepository
{

    Task<IEnumerable<EmployeeSearchResponseDto>> GetEmployeeSearchAsync(EmployeeSearchRequestDto request);
    Task<IEnumerable<DepartmentEmployeeSummaryResponseDto>> GetDepartmentEmployeeSummaryAsync();
    Task<EmployeeSalarySummaryResponseDto> GetEmployeeSalarySummaryAsync();
    Task<IEnumerable<EmployeeStatusSummaryResponseDto>> GetEmployeeStatusSummaryAsync();
    Task<IEnumerable<EmployeeHiringSummaryResponseDto>> GetEmployeeHiringSummaryAsync();

}

==================================================
FILE: ./NovaBusinessSystem.BL/Interfaces/Employees/IEmployeesReportsService.cs
==================================================

using NovaBusinessSystem.DTOs.Employees;

namespace NovaBusinessSystem.BL.Interfaces;

public interface IEmployeesReportsService
{

    Task<IEnumerable<EmployeeSearchResponseDto>> GetEmployeeSearchAsync(EmployeeSearchRequestDto request);
    Task<IEnumerable<DepartmentEmployeeSummaryResponseDto>> GetDepartmentEmployeeSummaryAsync();
    Task<EmployeeSalarySummaryResponseDto> GetEmployeeSalarySummaryAsync();
    Task<IEnumerable<EmployeeStatusSummaryResponseDto>> GetEmployeeStatusSummaryAsync();
    Task<IEnumerable<EmployeeHiringSummaryResponseDto>> GetEmployeeHiringSummaryAsync();

}


==================================================
FILE: ./NovaBusinessSystem.BL/Interfaces/Employees/IEmployeesRepository.cs
==================================================
using NovaBusinessSystem.DTOs.Employees;

namespace NovaBusinessSystem.BL.Interfaces;

public interface IEmployeesRepository
{
    Task<IEnumerable<EmployeeDetailsResponseDto>> GetAllAsync();
    Task<EmployeeResponseDto?> GetEmployeeAsync(int id);
    Task<int> AddEmployeeAsync(EmployeeCreateRequestDto employee);
    Task<bool> UpdateEmployeeAsync(int id, EmployeeUpdateRequestDto employee);
    Task<bool> DeleteEmployeeAsync(int id);


}


==================================================
FILE: ./NovaBusinessSystem.BL/Interfaces/Employees/IEmployeesService.cs
==================================================

using NovaBusinessSystem.DTOs.Employees;

namespace NovaBusinessSystem.BL.Interfaces;

public interface IEmployeesService
{
    Task<IEnumerable<EmployeeDetailsResponseDto>> GetAllAsync();
    Task<EmployeeResponseDto?> GetEmployeeAsync(int id);
    Task<int> AddEmployeeAsync(EmployeeCreateRequestDto employee);
    Task<bool> UpdateEmployeeAsync(int id , EmployeeUpdateRequestDto employee);
    Task<bool> DeleteEmployeeAsync (int id ) ; 
    

}


==================================================
FILE: ./NovaBusinessSystem.BL/Interfaces/Products/IProductsRepository.cs
==================================================
using NovaBusinessSystem.DTOs.Products;

namespace NovaBusinessSystem.BL.Interfaces;

public interface IProductsRepository
{
    Task<IEnumerable<ProductResponseDto?>> GetAllAsync();
    Task<ProductResponseDto?> GetProductByIDAsync(int productID);
    Task<int> AddProductAsync(ProductCreateRequestDto product);
    Task<bool> UpdateProductAsync(int productID, ProductUpdateRequestDto product);
    Task<bool> DeleteProductAsync(int productID);

}

==================================================
FILE: ./NovaBusinessSystem.BL/Interfaces/Products/IProductsService.cs
==================================================
using NovaBusinessSystem.DTOs.Products;

namespace NovaBusinessSystem.BL.Interfaces;

public interface IProductsService
{
    Task<IEnumerable<ProductResponseDto?>> GetAllAsync();
    Task<ProductResponseDto?> GetProductByIDAsync(int productID);
    Task<int> AddProductAsync(ProductCreateRequestDto product);
    Task<bool> UpdateProductAsync(int productID, ProductUpdateRequestDto product);
    Task<bool> DeleteProductAsync(int productID);
}

==================================================
FILE: ./NovaBusinessSystem.BL/NovaBusinessSystemBL.csproj
==================================================
﻿<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net10.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <ProjectReference Include="../NovaBusinessSystem.DTOs/NovaBusinessSystemDTOs.csproj" />
  </ItemGroup>
</Project>


==================================================
FILE: ./NovaBusinessSystem.BL/Services/Customers/CustomersService.cs
==================================================
using NovaBusinessSystem.BL.Interfaces;
using NovaBusinessSystem.DTOs.Customers;

namespace NovaBusinessSystem.BL.Services;

public class CustomersService : ICustomersService
{

    private readonly ICustomersRepository _repository;

    public CustomersService(ICustomersRepository customersRepository)
    {
        this._repository = customersRepository ?? throw new ArgumentNullException(nameof(customersRepository));
    }

    public Task<int> AddAsync(CustomerCreateRequestDto customerDto)
    {

        ArgumentNullException.ThrowIfNull(customerDto);
        return _repository.AddAsync(customerDto);
    }

    public Task<bool> DeleteAsync(int customerID)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(customerID);
        return _repository.DeleteAsync(customerID);
    }

    public Task<IEnumerable<CustomerResponseDto>> GetAllAsync()
    {
        return _repository.GetAllAsync();
    }

    public Task<CustomerResponseDto?> GetByIdAsync(int customerID)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(customerID);

        return _repository.GetByIdAsync(customerID);
    }

    public Task<int> UpdateAsync(int customerID, CustomerCreateRequestDto customer)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(customerID);
        ArgumentNullException.ThrowIfNull(customer);
        return _repository.UpdateAsync(customerID, customer);
    }

    public Task<bool> IsEmailExistsAsync(int id, string email)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);
        ArgumentOutOfRangeException.ThrowIfNullOrWhiteSpace(email);
        return _repository.IsEmailExistsAsync(id, email);
    }
}

==================================================
FILE: ./NovaBusinessSystem.BL/Services/Employees/EmployeesReportsService.cs
==================================================

using NovaBusinessSystem.BL.Interfaces;
using NovaBusinessSystem.DTOs.Employees;

namespace NovaBusinessSystem.BL.Services
{

    public class EmployeesReportsService : IEmployeesReportsService
    {

        private readonly IEmployeesReportsRepository _repository;

        public EmployeesReportsService(IEmployeesReportsRepository employeesReportsRepository)
        {
            this._repository = employeesReportsRepository;
        }

        public Task<IEnumerable<EmployeeSearchResponseDto>> GetEmployeeSearchAsync(EmployeeSearchRequestDto request)
        {
            ArgumentNullException.ThrowIfNull(request);

            return _repository.GetEmployeeSearchAsync(request);
        }

        public Task<IEnumerable<DepartmentEmployeeSummaryResponseDto>> GetDepartmentEmployeeSummaryAsync()
        {
            return _repository.GetDepartmentEmployeeSummaryAsync();
        }

        public Task<EmployeeSalarySummaryResponseDto> GetEmployeeSalarySummaryAsync()
        {
            return _repository.GetEmployeeSalarySummaryAsync();
        }

        public Task<IEnumerable<EmployeeStatusSummaryResponseDto>> GetEmployeeStatusSummaryAsync()
        {
            return _repository.GetEmployeeStatusSummaryAsync();
        }

        public Task<IEnumerable<EmployeeHiringSummaryResponseDto>> GetEmployeeHiringSummaryAsync()
        {
            return _repository.GetEmployeeHiringSummaryAsync();
        }

    }
}

==================================================
FILE: ./NovaBusinessSystem.BL/Services/Employees/EmployeesService.cs
==================================================

using NovaBusinessSystem.BL.Interfaces;
using NovaBusinessSystem.DTOs.Employees;

namespace NovaBusinessSystem.BL.Services
{

    public class EmployeesService : IEmployeesService
    {

        private readonly IEmployeesRepository _repository;

        public EmployeesService(IEmployeesRepository employeesRepository)
        {
            this._repository = employeesRepository;
        }

        public Task<IEnumerable<EmployeeDetailsResponseDto>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<int> AddEmployeeAsync(EmployeeCreateRequestDto employee)
        {
            ArgumentNullException.ThrowIfNull(employee);

            return _repository.AddEmployeeAsync(employee); ;
        }

        public Task<EmployeeResponseDto?> GetEmployeeAsync(int employeeID)
        {
            if (employeeID <= 0)
                throw new ArgumentOutOfRangeException("employee id is invalid ");

            return _repository.GetEmployeeAsync(employeeID);
        }
        public Task<bool> UpdateEmployeeAsync(int employeeID, EmployeeUpdateRequestDto employee)
        {
            ArgumentNullException.ThrowIfNull(employee);

            return _repository.UpdateEmployeeAsync(employeeID, employee); ;
        }

        public Task<bool> DeleteEmployeeAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException("employee id is invalid ");

            return _repository.DeleteEmployeeAsync(id);
        }


    }
}

==================================================
FILE: ./NovaBusinessSystem.BL/Services/Products/ProductsService.cs
==================================================
using NovaBusinessSystem.BL.Interfaces;
using NovaBusinessSystem.DTOs.Products;

namespace NovaBusinessSystem.BL.Services;

public class ProductsService : IProductsService
{

    private readonly IProductsRepository _repository;

    public ProductsService(IProductsRepository productsRepository)
    {
        this._repository = productsRepository ?? throw new ArgumentNullException(nameof(productsRepository));
    }

    public Task<IEnumerable<ProductResponseDto?>> GetAllAsync()
    {
        return this._repository.GetAllAsync();
    }

    public Task<ProductResponseDto?> GetProductByIDAsync(int productID)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(productID);
        return _repository.GetProductByIDAsync(productID);

    }

    public Task<int> AddProductAsync(ProductCreateRequestDto product)
    {
        ArgumentNullException.ThrowIfNull(product);

        return _repository.AddProductAsync(product);
    }

    public Task<bool> UpdateProductAsync(int productID, ProductUpdateRequestDto product)
    {
        ArgumentNullException.ThrowIfNull(product);

        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(productID);

        return _repository.UpdateProductAsync(productID, product);

    }

    public Task<bool> DeleteProductAsync(int productID)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(productID);


        return _repository.DeleteProductAsync(productID);
    }

}

==================================================
FILE: ./NovaBusinessSystem.DAL/DataAccessLayer.csproj
==================================================
﻿<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net10.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.Data.SqlClient" Version="7.0.2" />
    <PackageReference Include="Microsoft.Extensions.Configuration" Version="10.0.11" />
    <PackageReference Include="System.Configuration.ConfigurationManager" Version="10.0.11" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="../NovaBusinessSystem.BL/NovaBusinessSystemBL.csproj" />
    <ProjectReference Include="../NovaBusinessSystem.DTOs/NovaBusinessSystemDTOs.csproj" />
  </ItemGroup>

</Project>


==================================================
FILE: ./NovaBusinessSystem.DAL/Helpers/HelperDAL.cs
==================================================

namespace HelperDAL 
{

    public sealed class HelperDAL
    {
    public static readonly string ConnectionString =
    @"Server=.;Database=TrainingDB;User Id=sa;Password=Test12345;TrustServerCertificate=True;";
    }
    
}




==================================================
FILE: ./NovaBusinessSystem.DAL/Repositories/Customers/CustomersRepository.cs
==================================================
using System.Data;
using Microsoft.Data.SqlClient;
using NovaBusinessSystem.BL.Interfaces;
using NovaBusinessSystem.DTOs;
using NovaBusinessSystem.DTOs.Customers;

namespace NovaBusinessSystem.DAL.Repositories;

public class CustomersRepository : ICustomersRepository
{
    public async Task<IEnumerable<CustomerResponseDto>> GetAllAsync()
    {
        List<CustomerResponseDto> customers = new();

        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
        using var command = new SqlCommand("[dbo].[usp_GetCustomers]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        await connection.OpenAsync();

        using var reader = await command.ExecuteReaderAsync();

        int customerIDOrdinal = reader.GetOrdinal("CustomerID");
        int firstNameOrdinal = reader.GetOrdinal("FirstName");
        int lastNameOrdinal = reader.GetOrdinal("LastName");
        int emailOrdinal = reader.GetOrdinal("Email");
        int phoneOrdinal = reader.GetOrdinal("Phone");
        int cityOrdinal = reader.GetOrdinal("City");
        int registrationDateOrdinal = reader.GetOrdinal("RegistrationDate");
        int loyaltyPointsOrdinal = reader.GetOrdinal("LoyaltyPoints");
        int statusOrdinal = reader.GetOrdinal("Status");

        while (await reader.ReadAsync())
        {
            customers.Add(new CustomerResponseDto(
                reader.GetInt32(customerIDOrdinal),
                reader.GetString(firstNameOrdinal),
                reader.GetString(lastNameOrdinal),
                reader.GetString(emailOrdinal),
                reader.GetString(phoneOrdinal),
                reader.GetString(cityOrdinal),
                reader.GetDateTime(registrationDateOrdinal),
                reader.GetInt32(loyaltyPointsOrdinal),
                reader.GetString(statusOrdinal)
            ));
        }

        return customers;
    }

    public async Task<CustomerResponseDto?> GetByIdAsync(int customerID)
    {
        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
        using var command = new SqlCommand("[dbo].[usp_GetCustomerByID]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add("@ID", SqlDbType.Int).Value = customerID;

        await connection.OpenAsync();

        using var reader = await command.ExecuteReaderAsync();

        if (!await reader.ReadAsync())
            return null;

        int firstNameOrdinal = reader.GetOrdinal("FirstName");
        int lastNameOrdinal = reader.GetOrdinal("LastName");
        int emailOrdinal = reader.GetOrdinal("Email");
        int phoneOrdinal = reader.GetOrdinal("Phone");
        int cityOrdinal = reader.GetOrdinal("City");
        int registrationDateOrdinal = reader.GetOrdinal("RegistrationDate");
        int loyaltyPointsOrdinal = reader.GetOrdinal("LoyaltyPoints");
        int statusOrdinal = reader.GetOrdinal("Status");

        return new CustomerResponseDto(
            customerID,
            reader.GetString(firstNameOrdinal),
            reader.GetString(lastNameOrdinal),
            reader.GetString(emailOrdinal),
            reader.GetString(phoneOrdinal),
            reader.GetString(cityOrdinal),
            reader.GetDateTime(registrationDateOrdinal),
            reader.GetInt32(loyaltyPointsOrdinal),
            reader.GetString(statusOrdinal)
        );
    }

    public async Task<int> AddAsync(CustomerCreateRequestDto customer)
    {
        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
        using var command = new SqlCommand("[dbo].[usp_AddNewCustomer]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50).Value = customer.FirstName;
        command.Parameters.Add("@LastName", SqlDbType.NVarChar, 50).Value = customer.LastName;
        command.Parameters.Add("@Email", SqlDbType.NVarChar, 150).Value = customer.Email;
        command.Parameters.Add("@Phone", SqlDbType.NVarChar, 11).Value = customer.Phone.Trim();
        command.Parameters.Add("@City", SqlDbType.NVarChar, 100).Value = customer.City;
        command.Parameters.Add("@Status", SqlDbType.NVarChar, 20).Value = customer.Status;

        var customerIDParameter = new SqlParameter("@CustomerID", SqlDbType.Int)
        {
            Direction = ParameterDirection.Output
        };

        command.Parameters.Add(customerIDParameter);

        await connection.OpenAsync();
        await command.ExecuteNonQueryAsync();

        return Convert.ToInt32(customerIDParameter.Value);
    }

    public async Task<bool> IsEmailExistsAsync(int id, string email)
    {
        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
        using var command = new SqlCommand("[dbo].[usp_IsEmailExists]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add("@Email", SqlDbType.NVarChar, 150).Value = email;
        command.Parameters.Add("@ID", SqlDbType.Int).Value = id;

        await connection.OpenAsync();

        object? result = await command.ExecuteScalarAsync();

        return Convert.ToInt32(result) > 0;
    }

    public async Task<int> UpdateAsync(int customerID, CustomerCreateRequestDto customer)
    {
        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
        using var command = new SqlCommand("[dbo].[usp_UpdateCustomer]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50).Value = customer.FirstName;
        command.Parameters.Add("@LastName", SqlDbType.NVarChar, 50).Value = customer.LastName;
        command.Parameters.Add("@Email", SqlDbType.NVarChar, 150).Value = customer.Email;
        command.Parameters.Add("@Phone", SqlDbType.NVarChar, 11).Value = customer.Phone;
        command.Parameters.Add("@City", SqlDbType.NVarChar, 100).Value = customer.City;
        command.Parameters.Add("@Status", SqlDbType.NVarChar, 20).Value = customer.Status;
        command.Parameters.Add("@CustomerID", SqlDbType.Int).Value = customerID;

        await connection.OpenAsync();

        object? result = await command.ExecuteScalarAsync();

        return Convert.ToInt32(result);
    }

    public async Task<bool> DeleteAsync(int customerID)
    {
        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
        using var command = new SqlCommand("[dbo].[usp_DeleteCustomer]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add("@CustomerID", SqlDbType.Int).Value = customerID;

        await connection.OpenAsync();

        object? result = await command.ExecuteScalarAsync();

        return Convert.ToInt32(result) > 0;
    }

}

==================================================
FILE: ./NovaBusinessSystem.DAL/Repositories/Employees/EmployeesReportsRepository.cs
==================================================
using System.Data;
using Microsoft.Data.SqlClient;
using NovaBusinessSystem.BL.Interfaces;
using NovaBusinessSystem.DTOs.Employees;


namespace NovaBusinessSystem.DAL.Repositories;

public class EmployeesReportsRepository : IEmployeesReportsRepository
{

    public async Task<IEnumerable<EmployeeSearchResponseDto>> GetEmployeeSearchAsync(
        EmployeeSearchRequestDto request)
    {
        List<EmployeeSearchResponseDto> employeeSearches = new();

        using var connection = new SqlConnection(
            HelperDAL.HelperDAL.ConnectionString);

        using var command = new SqlCommand(
            "[dbo].usp_SearchEmployee", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add("@FullName", SqlDbType.NVarChar, 200).Value =
            (object?)request.FullName ?? DBNull.Value;

        command.Parameters.Add("@DepartmentName", SqlDbType.NVarChar, 150).Value =
            (object?)request.DepartmentName ?? DBNull.Value;

        command.Parameters.Add("@JobTitle", SqlDbType.NVarChar, 150).Value =
            (object?)request.JobTitle ?? DBNull.Value;

        command.Parameters.Add("@Status", SqlDbType.NVarChar, 20).Value =
            (object?)request.Status ?? DBNull.Value;

        await connection.OpenAsync();

        using var reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            employeeSearches.Add(new EmployeeSearchResponseDto(
                 reader.GetInt32(reader.GetOrdinal("EmployeeID")),
                reader.GetString(reader.GetOrdinal("FullName")),
                reader.GetString(reader.GetOrdinal("DepartmentName")),
                reader.GetString(reader.GetOrdinal("JobTitle")),
                reader.GetString(reader.GetOrdinal("Status"))
            ));
        }

        return employeeSearches;
    }

    public async Task<IEnumerable<DepartmentEmployeeSummaryResponseDto>> GetDepartmentEmployeeSummaryAsync()
    {
        List<DepartmentEmployeeSummaryResponseDto> summaries = new();

        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
        using var command = new SqlCommand("[dbo].[usp_DepartmentSummary]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };


        await connection.OpenAsync();

        using var reader = await command.ExecuteReaderAsync();

        int departmentNameOrdinal = reader.GetOrdinal("DepartmentName");
        int totalEmployeesOrdinal = reader.GetOrdinal("TotalEmployees");
        int avgSalaryOrdinal = reader.GetOrdinal("AvgSalary");

        while (await reader.ReadAsync())
        {
            summaries.Add(new DepartmentEmployeeSummaryResponseDto(
                reader.GetString(departmentNameOrdinal),
                reader.GetInt32(totalEmployeesOrdinal),
                reader.GetDecimal(avgSalaryOrdinal)
            ));
        }

        return summaries;

    }

    public async Task<EmployeeSalarySummaryResponseDto> GetEmployeeSalarySummaryAsync()
    {
        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
        using var command = new SqlCommand("[dbo].[usp_SalarySummary]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        await connection.OpenAsync();

        using var reader = await command.ExecuteReaderAsync();

        if (!await reader.ReadAsync())
            return null;

        return new EmployeeSalarySummaryResponseDto(
            reader.GetDecimal(reader.GetOrdinal("MinimumSalary")),
            reader.GetDecimal(reader.GetOrdinal("MaximumSalary")),
            reader.GetDecimal(reader.GetOrdinal("AverageSalary")),
            reader.GetDecimal(reader.GetOrdinal("TotalSalary"))
        );
    }

    public async Task<IEnumerable<EmployeeStatusSummaryResponseDto>> GetEmployeeStatusSummaryAsync()
    {
        List<EmployeeStatusSummaryResponseDto> employeeStatuses = new();

        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
        using var command = new SqlCommand("[dbo].[usp_EmployeeStatus]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        await connection.OpenAsync();

        using var reader = await command.ExecuteReaderAsync();
        int statusOrdinal = reader.GetOrdinal("Status");
        int countOrdinal = reader.GetOrdinal("Count");

        while (await reader.ReadAsync())
        {
            employeeStatuses.Add(new EmployeeStatusSummaryResponseDto(
                reader.GetString(statusOrdinal),
                reader.GetInt32(countOrdinal)
            ));
        }

        return employeeStatuses;
    }

    public async Task<IEnumerable<EmployeeHiringSummaryResponseDto>> GetEmployeeHiringSummaryAsync()
    {
        List<EmployeeHiringSummaryResponseDto> employeeHiringSummaries = new();

        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
        using var command = new SqlCommand("[dbo].[usp_HiringSummary]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };


        await connection.OpenAsync();

        using var reader = await command.ExecuteReaderAsync();


        int hireYearOrdinal = reader.GetOrdinal("HireYear");
        int employeesHiredOrdinal = reader.GetOrdinal("EmployeesHired");

        while (await reader.ReadAsync())
        {
            employeeHiringSummaries.Add(new EmployeeHiringSummaryResponseDto(
                reader.GetInt32(hireYearOrdinal),
                reader.GetInt32(employeesHiredOrdinal)
            ));
        }

        return employeeHiringSummaries;
    }

}






==================================================
FILE: ./NovaBusinessSystem.DAL/Repositories/Employees/EmployeesRepository.cs
==================================================
using System.Data;
using Microsoft.Data.SqlClient;
using NovaBusinessSystem.BL.Interfaces;
using NovaBusinessSystem.DTOs.Employees;


namespace NovaBusinessSystem.DAL.Repositories;

public class EmployeesRepository : IEmployeesRepository
{
    public async Task<IEnumerable<EmployeeDetailsResponseDto>> GetAllAsync()
    {

        List<EmployeeDetailsResponseDto> employees = new();

        using SqlConnection connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);

        using SqlCommand command = new SqlCommand("[dbo].[usp_ListEmployees]", connection);

        await connection.OpenAsync();

        using SqlDataReader reader = await command.ExecuteReaderAsync();

        var employeeID = reader.GetOrdinal("EmployeeID");
        var name = reader.GetOrdinal("FullName");
        var department = reader.GetOrdinal("DepartmentName");
        var jobTitle = reader.GetOrdinal("JobTitle");
        var salary = reader.GetOrdinal("Salary");
        var status = reader.GetOrdinal("Status");

        while (await reader.ReadAsync())
        {
            employees.Add(new EmployeeDetailsResponseDto(
                reader.GetInt32(employeeID),
                reader.GetString(name),
                reader.GetString(department),
                reader.GetString(jobTitle),
                reader.GetDecimal(salary),
                reader.GetString(status)
            ));
        }

        return employees;
    }

    private static void AddEmployeeParameters(SqlCommand command, EmployeeCreateRequestDto employee)
    {
        command.Parameters.Add(
            "@FirstName", SqlDbType.NVarChar, 100).Value =
            employee.FirstName;

        command.Parameters.Add(
            "@LastName", SqlDbType.NVarChar, 100).Value =
            employee.LastName;

        command.Parameters.Add(
            "@DepartmentID", SqlDbType.Int).Value =
            employee.DepartmentID;

        command.Parameters.Add(
            "@ManagerID", SqlDbType.Int).Value =
            employee.ManagerID == 0 || employee.ManagerID is null ? DBNull.Value : employee.ManagerID;

        command.Parameters.Add(
            "@JobTitle", SqlDbType.NVarChar, 200).Value =
            employee.JobTitle;

        var salaryParameter = command.Parameters.Add(
            "@Salary", SqlDbType.Decimal);

        salaryParameter.Precision = 10;
        salaryParameter.Scale = 2;
        salaryParameter.Value = employee.Salary;

        command.Parameters.Add(
            "@Phone", SqlDbType.Char, 11).Value =
            employee.Phone == "" || employee.Phone is null ? DBNull.Value : employee.Phone;

        command.Parameters.Add(
            "@Email", SqlDbType.VarChar, -1).Value =
            employee.Email == "" || employee.Email is null ? DBNull.Value : employee.Email;
    }

    public async Task<int> AddEmployeeAsync(EmployeeCreateRequestDto employee)
    {

        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);

        using var command = new SqlCommand("[dbo].[usp_AddNewEmployee]", connection)
        {

            CommandType = CommandType.StoredProcedure
        };

        AddEmployeeParameters(command, employee);

        var employeeIdParameter = command.Parameters.Add("@EmployeeID", SqlDbType.Int);

        employeeIdParameter.Direction = ParameterDirection.Output;

        await connection.OpenAsync();

        await command.ExecuteNonQueryAsync();

        return Convert.ToInt32(employeeIdParameter.Value);
    }

    public async Task<EmployeeResponseDto?> GetEmployeeAsync(int employeeID)
    {

        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);

        using var command = new SqlCommand("[dbo].[usp_GetEmployeeByID]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = employeeID;

        await connection.OpenAsync();

        using var reader = await command.ExecuteReaderAsync();

        if (!await reader.ReadAsync())
            return null;

        var firstName = reader.GetOrdinal("FirstName");
        var lastName = reader.GetOrdinal("LastName");
        var departmentID = reader.GetOrdinal("DepartmentName");
        var managerName = reader.GetOrdinal("ManagerName");
        var jobTitle = reader.GetOrdinal("JobTitle");
        var salary = reader.GetOrdinal("Salary");
        var hireDate = reader.GetOrdinal("HireDate");
        var phone = reader.GetOrdinal("Phone");
        var email = reader.GetOrdinal("Email");
        var status = reader.GetOrdinal("Status");

        return new EmployeeResponseDto(
            employeeID,
            reader.GetString(firstName),
            reader.GetString(lastName),
            reader.GetString(departmentID),
            reader.IsDBNull(managerName) ? null : reader.GetString(managerName),
            reader.GetString(jobTitle),
            reader.GetDecimal(salary),
            reader.GetDateTime(hireDate),
            reader.IsDBNull(phone) ? null : reader.GetString(phone),
            reader.IsDBNull(email) ? null : reader.GetString(email),
            reader.GetString(status)
        );
    }

    public async Task<bool> UpdateEmployeeAsync(int id, EmployeeUpdateRequestDto employee)
    {

        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
        using var command = new SqlCommand("[dbo].usp_UpdateEmployee", connection)
        {
            CommandType = CommandType.StoredProcedure
        };


        command.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = id;

        command.Parameters.Add(
            "@FirstName", SqlDbType.NVarChar, 100).Value =
            employee.FirstName;

        command.Parameters.Add(
            "@LastName", SqlDbType.NVarChar, 100).Value =
            employee.LastName;

        command.Parameters.Add(
            "@DepartmentID", SqlDbType.Int).Value =
            employee.DepartmentID;

        command.Parameters.Add(
            "@ManagerID", SqlDbType.Int).Value =
            employee.ManagerID == 0 || employee.ManagerID is null ? DBNull.Value : employee.ManagerID;

        command.Parameters.Add(
            "@JobTitle", SqlDbType.NVarChar, 200).Value =
            employee.JobTitle;

        var salaryParameter = command.Parameters.Add(
            "@Salary", SqlDbType.Decimal);

        salaryParameter.Precision = 10;
        salaryParameter.Scale = 2;
        salaryParameter.Value = employee.Salary;

        command.Parameters.Add(
            "@Phone", SqlDbType.Char, 11).Value =
            employee.Phone == "" || employee.Phone is null ? DBNull.Value : employee.Phone;

        command.Parameters.Add(
            "@Email", SqlDbType.VarChar, -1).Value =
            employee.Email == "" || employee.Email is null ? DBNull.Value : employee.Email;

        command.Parameters.Add(
                    "@Status", SqlDbType.VarChar).Value = employee.Status;


        await connection.OpenAsync();

        return await command.ExecuteNonQueryAsync() > 0;
    }

    public async Task<bool> DeleteEmployeeAsync(int id)
    {

        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);

        using var command = new SqlCommand("[dbo].usp_DeleteEmployee", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = id;

        await connection.OpenAsync();

        object? result = await command.ExecuteScalarAsync();

        if (result is not null && int.TryParse(result.ToString(), out int r))
            return r > 0;
        else return false;



    }
    public async Task<IEnumerable<EmployeeSearchResponseDto>> GetEmployeeSearchAsync(
        EmployeeSearchRequestDto request)
    {
        List<EmployeeSearchResponseDto> employeeSearches = new();

        using var connection = new SqlConnection(
            HelperDAL.HelperDAL.ConnectionString);

        using var command = new SqlCommand(
            "[dbo].usp_SearchEmployee", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add("@FullName", SqlDbType.NVarChar, 200).Value =
            (object?)request.FullName ?? DBNull.Value;

        command.Parameters.Add("@DepartmentName", SqlDbType.NVarChar, 150).Value =
            (object?)request.DepartmentName ?? DBNull.Value;

        command.Parameters.Add("@JobTitle", SqlDbType.NVarChar, 150).Value =
            (object?)request.JobTitle ?? DBNull.Value;

        command.Parameters.Add("@Status", SqlDbType.NVarChar, 20).Value =
            (object?)request.Status ?? DBNull.Value;

        await connection.OpenAsync();

        using var reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            employeeSearches.Add(new EmployeeSearchResponseDto(
                 reader.GetInt32(reader.GetOrdinal("EmployeeID")),
                reader.GetString(reader.GetOrdinal("FullName")),
                reader.GetString(reader.GetOrdinal("DepartmentName")),
                reader.GetString(reader.GetOrdinal("JobTitle")),
                reader.GetString(reader.GetOrdinal("Status"))
            ));
        }

        return employeeSearches;
    }
}





==================================================
FILE: ./NovaBusinessSystem.DAL/Repositories/Products/ProductsRepository.cs
==================================================
using System.Data;
using Microsoft.Data.SqlClient;
using NovaBusinessSystem.BL.Interfaces;
using NovaBusinessSystem.DTOs.Products;

namespace NovaBusinessSystem.DAL.Products;

public class ProductsRepository : IProductsRepository
{
    public async Task<IEnumerable<ProductResponseDto?>> GetAllAsync()
    {
        List<ProductResponseDto> products = new();


        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
        using var command = new SqlCommand("[dbo].usp_GetAllProducts", connection)
        {

            CommandType = CommandType.StoredProcedure
        };

        await connection.OpenAsync();

        using var reader = await command.ExecuteReaderAsync();

        int productIdOrdinal = reader.GetOrdinal("ProductID");
        int productNameOrdinal = reader.GetOrdinal("ProductName");
        int categoryOrdinal = reader.GetOrdinal("Category");
        int priceOrdinal = reader.GetOrdinal("Price");
        int stockQuantityOrdinal = reader.GetOrdinal("StockQuantity");
        int statusOrdinal = reader.GetOrdinal("Status");

        while (await reader.ReadAsync())
        {
            products.Add(new ProductResponseDto(
                reader.GetInt32(productIdOrdinal),
                reader.GetString(productNameOrdinal),
                reader.GetString(categoryOrdinal),
                reader.GetDecimal(priceOrdinal),
                reader.GetInt32(stockQuantityOrdinal),
                reader.GetString(statusOrdinal)
            ));
        }

        return products;
    }

    public async Task<ProductResponseDto?> GetProductByIDAsync(int productID)
    {
        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);

        using var command = new SqlCommand("[dbo].[usp_GetProductByID]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;

        await connection.OpenAsync();

        using var reader = await command.ExecuteReaderAsync();

        if (!await reader.ReadAsync())
            return null;

        int productIdOrdinal = reader.GetOrdinal("ProductID");
        int productNameOrdinal = reader.GetOrdinal("ProductName");
        int categoryOrdinal = reader.GetOrdinal("Category");
        int priceOrdinal = reader.GetOrdinal("Price");
        int stockQuantityOrdinal = reader.GetOrdinal("StockQuantity");
        int statusOrdinal = reader.GetOrdinal("Status");

        return new ProductResponseDto(
            reader.GetInt32(productIdOrdinal),
            reader.GetString(productNameOrdinal),
            reader.GetString(categoryOrdinal),
            reader.GetDecimal(priceOrdinal),
            reader.GetInt32(stockQuantityOrdinal),
            reader.GetString(statusOrdinal)
        );
    }

    public async Task<int> AddProductAsync(ProductCreateRequestDto product)
    {
        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);

        using var command = new SqlCommand("[dbo].[usp_AddNewProduct]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add("@ProductName", SqlDbType.VarChar, 100).Value = product.ProductName;

        command.Parameters.Add("@Category", SqlDbType.VarChar, 100).Value = product.Category;

        var priceParameter = command.Parameters.Add("@Price", SqlDbType.Decimal);

        priceParameter.Precision = 18;
        priceParameter.Scale = 2;
        priceParameter.Value = product.Price;

        command.Parameters.Add("@StockQuantity", SqlDbType.Int).Value = product.StockQuantity;

        command.Parameters.Add("@Status", SqlDbType.VarChar, 50).Value = product.Status;

        var productIdParameter = command.Parameters.Add("@ProductID", SqlDbType.Int);

        productIdParameter.Direction = ParameterDirection.Output;

        await connection.OpenAsync();

        await command.ExecuteNonQueryAsync();

        return Convert.ToInt32(productIdParameter.Value);
    }

    public async Task<bool> UpdateProductAsync(int productID, ProductUpdateRequestDto product)
    {

        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);

        using var command = new SqlCommand("[dbo].[usp_UpdateProduct]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;

        command.Parameters.Add("@ProductName", SqlDbType.VarChar, 100).Value = product.ProductName;

        command.Parameters.Add("@Category", SqlDbType.VarChar, 100).Value = product.Category;

        var priceParameter = command.Parameters.Add("@Price", SqlDbType.Decimal);

        priceParameter.Precision = 18;
        priceParameter.Scale = 2;
        priceParameter.Value = product.Price;

        command.Parameters.Add("@Status", SqlDbType.VarChar, 50).Value = product.Status;

        await connection.OpenAsync();

        object? result = await command.ExecuteScalarAsync();

        return result is null or DBNull
        ? false :
        Convert.ToInt32(result) > 0;
    }

    public async Task<bool> DeleteProductAsync(int productID)
    {
        using var connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);

        using var command = new SqlCommand("[dbo].[usp_DeleteProduct]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        command.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;

        await connection.OpenAsync();

        int rowsAffected = await command.ExecuteNonQueryAsync();

        return rowsAffected > 0;
    }
}

==================================================
FILE: ./NovaBusinessSystem.DTOs/Customer DTOs/CustomerCreateRequestDto.cs
==================================================
namespace NovaBusinessSystem.DTOs.Customers;

public record CustomerCreateRequestDto(
    string FirstName,
    string LastName,
    string Email,
    string Phone,
    string City,
    string Status
);

==================================================
FILE: ./NovaBusinessSystem.DTOs/Customer DTOs/CustomerResponseDto.cs
==================================================
﻿namespace NovaBusinessSystem.DTOs.Customers;

public record CustomerResponseDto(
    int CustomerID,
    string FirstName,
    string LastName,
    string Email,
    string Phone,
    string City,
    DateTime RegistrationDate,
    int LoyaltyPoints,
    string Status
);

==================================================
FILE: ./NovaBusinessSystem.DTOs/Customer DTOs/Report DTOs/CustomerRegistrationSummaryDto.cs
==================================================
namespace NovaBusinessSystem.DTOs.Customers.Reports;

public record CustomerRegistrationSummaryDto(
    int Year,
    int NewCustomers
);

==================================================
FILE: ./NovaBusinessSystem.DTOs/Customer DTOs/Report DTOs/CustomersByCityReportDto.cs
==================================================
namespace NovaBusinessSystem.DTOs.Customers.Reports;

public record CustomersByCityReportDto(
    string City,
    int TotalCustomers
);

==================================================
FILE: ./NovaBusinessSystem.DTOs/Customer DTOs/Report DTOs/CustomerStatusReportDto.cs
==================================================
namespace NovaBusinessSystem.DTOs.Customers.Reports;

public record CustomerStatusReportDto(
    string Status,
    int TotalCustomers
);

==================================================
FILE: ./NovaBusinessSystem.DTOs/Customer DTOs/Report DTOs/LoyaltyLevelSummaryReportDto.cs
==================================================
namespace NovaBusinessSystem.DTOs.Customers.Reports;

public record LoyaltyLevelSummaryReportDto(
    string LoyaltyLevel,
    int TotalCustomers,
    long TotalLoyaltyPoints
);

==================================================
FILE: ./NovaBusinessSystem.DTOs/Customer Purchases DTOs/CustomerPurchaseDto.cs
==================================================
namespace NovaBusinessSystem.DTOs.Customers;

public record CustomerPurchaseDto(
    int SaleID,
    DateTime SaleDate,
    decimal TotalAmount,
    string PaymentMethod,
    string Status
);

==================================================
FILE: ./NovaBusinessSystem.DTOs/Customer Purchases DTOs/CustomerRankingDto.cs
==================================================
namespace NovaBusinessSystem.DTOs.Customers;

public record CustomerRankingDto(
    long Rank,
    string CustomerName,
    int TotalOrders,
    decimal TotalSpent
);

==================================================
FILE: ./NovaBusinessSystem.DTOs/Customer Purchases DTOs/CustomerSpendingSummaryDto.cs
==================================================
namespace NovaBusinessSystem.DTOs.Customers;

public record CustomerSpendingSummaryDto(
    int TotalOrders,
    int CompletedOrders,
    int PendingOrders,
    int CancelledOrders,
    decimal TotalSpent,
    decimal AverageOrderValue,
    decimal LargestOrderValue,
    DateTime? FirstPurchaseDate,
    DateTime? LastPurchaseDate
);

==================================================
FILE: ./NovaBusinessSystem.DTOs/Customer Purchases DTOs/FavoriteProductDto.cs
==================================================
namespace NovaBusinessSystem.DTOs.Customers;

public record FavoriteProductDto(
    long Rank,
    string ProductName,
    int TotalQuantityPurchased
);

==================================================
FILE: ./NovaBusinessSystem.DTOs/Customer Purchases DTOs/MonthlyPurchaseSummaryDto.cs
==================================================
namespace NovaBusinessSystem.DTOs.Customers;

public record MonthlyPurchaseSummaryDto(
    string Month,
    int TotalOrders,
    decimal TotalSpent
);

==================================================
FILE: ./NovaBusinessSystem.DTOs/Department DTOs/DepartmentResponseDto.cs
==================================================
namespace NovaBusinessSystem.DTOs.Departments
{
    public record DepartmentResponseDto(
        int DepartmentID,
        string DepartmentName,
        string Location,
        decimal Budget
    );
}

==================================================
FILE: ./NovaBusinessSystem.DTOs/Employees DTOs/EmployeeCreateRequestDto.cs
==================================================

using System.ComponentModel.DataAnnotations;

namespace NovaBusinessSystem.DTOs.Employees;

public class EmployeeCreateRequestDto
{
    [Required]
    [StringLength(100, MinimumLength = 1)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [StringLength(100, MinimumLength = 1)]
    public string LastName { get; set; } = string.Empty;

    [Range(1, int.MaxValue)]
    public int DepartmentID { get; set; }

    [Range(0, int.MaxValue)]
    public int? ManagerID { get; set; }

    [Required]
    [StringLength(200, MinimumLength = 1)]
    public string JobTitle { get; set; } = string.Empty;

    [Required]
    [Range(typeof(decimal), "0.01", "9999999999999999.99")]
    public decimal Salary { get; set; }

    [Phone]
    [StringLength(30, MinimumLength = 1)]
    public string? Phone { get; set; } = string.Empty;

    [EmailAddress]
    [StringLength(254, MinimumLength = 1)]
    public string ? Email { get; set; } = string.Empty;
}


==================================================
FILE: ./NovaBusinessSystem.DTOs/Employees DTOs/EmployeeDetailsResponseDto.cs
==================================================
namespace NovaBusinessSystem.DTOs.Employees
{
    public record EmployeeDetailsResponseDto(
        int EmployeeID,
        string Name,
        string Department,
        string JobTitle,
        decimal Salary,
        string Status
    );
}

==================================================
FILE: ./NovaBusinessSystem.DTOs/Employees DTOs/EmployeeResponseDto.cs
==================================================
namespace NovaBusinessSystem.DTOs.Employees
{
    public record EmployeeResponseDto(
        int? EmployeeID,
        string FirstName,
        string LastName,
        string Department,
        string Manager,
        string JobTitle,
        decimal Salary,
        DateTime HireDate,
        string Phone,
        string Email,
        string Status
    );
}

==================================================
FILE: ./NovaBusinessSystem.DTOs/Employees DTOs/EmployeeUpdateRequestDto.cs.cs
==================================================
using System.ComponentModel.DataAnnotations;

namespace NovaBusinessSystem.DTOs.Employees;

public class EmployeeUpdateRequestDto
{
    [Required]
    [StringLength(100)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string LastName { get; set; } = string.Empty;

    [Range(1, int.MaxValue)]
    public int DepartmentID { get; set; }

    [Range(1, int.MaxValue)]
    public int? ManagerID { get; set; }

    [Required]
    [StringLength(200)]
    public string JobTitle { get; set; } = string.Empty;

    [Range(typeof(decimal), "0.01", "9999999999999999.99")]
    public decimal Salary { get; set; }

    [Phone]
    [StringLength(30)]
    public string? Phone { get; set; }

    [EmailAddress]
    [StringLength(254)]
    public string? Email { get; set; }

    [Required]
    [StringLength(20)]
    public string Status { get; set; } = string.Empty;
}

==================================================
FILE: ./NovaBusinessSystem.DTOs/Employees DTOs/Reports/DepartmentEmployeeSummaryResponseDto.cs
==================================================

using System.ComponentModel.DataAnnotations;

namespace NovaBusinessSystem.DTOs.Employees;

public record DepartmentEmployeeSummaryResponseDto(
    string DepartmentName,
    int TotalEmployees,
    decimal AvgSalary
);

==================================================
FILE: ./NovaBusinessSystem.DTOs/Employees DTOs/Reports/EmployeeHiringSummaryResponseDto.cs
==================================================
namespace NovaBusinessSystem.DTOs.Employees;

public record EmployeeHiringSummaryResponseDto(
    int HireYear,
    int EmployeesHired
);

==================================================
FILE: ./NovaBusinessSystem.DTOs/Employees DTOs/Reports/EmployeeSalarySummaryResponseDto.cs
==================================================
namespace NovaBusinessSystem.DTOs.Employees;

public record EmployeeSalarySummaryResponseDto(

    decimal MinimumSalary,
    decimal MaximumSalary,
    decimal AverageSalary,
    decimal TotalSalary
);

==================================================
FILE: ./NovaBusinessSystem.DTOs/Employees DTOs/Reports/EmployeeSearchRequestDto.cs
==================================================

using System.ComponentModel.DataAnnotations;

namespace NovaBusinessSystem.DTOs.Employees;

public class EmployeeSearchRequestDto
{
    [MaxLength(200)]
    public string? FullName { get; set; }

    [MaxLength(150)]
    public string? DepartmentName { get; set; }

    [MaxLength(150)]
    public string? JobTitle { get; set; }

    [MaxLength(20)]
    public string? Status { get; set; }
}


==================================================
FILE: ./NovaBusinessSystem.DTOs/Employees DTOs/Reports/EmployeeSearchResponseDto.cs
==================================================

namespace NovaBusinessSystem.DTOs.Employees;

public record EmployeeSearchResponseDto(
    int EmployeeID,
    string FullName,
    string DepartmentName,
    string JobTitle,
    string Status
);

==================================================
FILE: ./NovaBusinessSystem.DTOs/Employees DTOs/Reports/EmployeeStatusSummaryResponseDto.cs
==================================================

namespace NovaBusinessSystem.DTOs.Employees;

public record EmployeeStatusSummaryResponseDto(
        string Status,
        int Count
);


==================================================
FILE: ./NovaBusinessSystem.DTOs/Loyalty DTOs/CustomerPointsDto.cs
==================================================
namespace NovaBusinessSystem.DTOs.Customers.Loyalty;

public record CustomerPointsDto(
    int CustomerID,
    string CustomerName,
    int CurrentPoints,
    string LoyaltyLevel
);

==================================================
FILE: ./NovaBusinessSystem.DTOs/Loyalty DTOs/LoyaltyStatisticsDto.cs
==================================================
namespace NovaBusinessSystem.DTOs.Customers.Loyalty;
public record LoyaltyStatisticsDto(
    long TotalLoyaltyPoints,
    int MinimumPoints,
    int MaximumPoints,
    decimal AveragePoints,
    int DiamondCustomers,
    int PlatinumCustomers,
    int GoldCustomers,
    int SilverCustomers,
    int BronzeCustomers
);

==================================================
FILE: ./NovaBusinessSystem.DTOs/Loyalty DTOs/PointsTransactionResultDto.cs
==================================================
namespace NovaBusinessSystem.DTOs.Customers.Loyalty;
public record PointsTransactionResultDto(
    string CustomerName,
    int PreviousPoints,
    int Points,
    int NewBalance
);

==================================================
FILE: ./NovaBusinessSystem.DTOs/Loyalty DTOs/TopLoyaltyCustomerDto.cs
==================================================
namespace NovaBusinessSystem.DTOs.Customers.Loyalty;

public record TopLoyaltyCustomerDto(
    long Rank,
    string CustomerName,
    int Points,
    string Level
);

==================================================
FILE: ./NovaBusinessSystem.DTOs/NovaBusinessSystemDTOs.csproj
==================================================
﻿<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net10.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

</Project>


==================================================
FILE: ./NovaBusinessSystem.DTOs/Prodcuts DTOs/Inventory DTOs/AddStockResultDto.cs
==================================================
namespace NovaBusinessSystem.DTOs.Products.Inventory;

public record AddStockResultDto(
    int ProductID,
    string ProductName,
    int PreviousStock,
    int AddedStock,
    int NewStock
);

==================================================
FILE: ./NovaBusinessSystem.DTOs/Prodcuts DTOs/Inventory DTOs/AdjustStockResultDto.cs
==================================================
namespace NovaBusinessSystem.DTOs.Products.Inventory;

public record AdjustStockResultDto(
    int ProductID,
    string ProductName,
    int PreviousStock,
    int ActualStock,
    int Adjustment
);

==================================================
FILE: ./NovaBusinessSystem.DTOs/Prodcuts DTOs/Inventory DTOs/InventoryValueDto.cs
==================================================
namespace NovaBusinessSystem.DTOs.Products.Inventory;

public record InventoryValueDto(
    int TotalProducts,
    int TotalStockUnits,
    decimal TotalInventoryValue,
    decimal AverageProductPrice,
    decimal AverageStock,
    string MostValuableStock,
    decimal StockValue
);

==================================================
FILE: ./NovaBusinessSystem.DTOs/Prodcuts DTOs/Inventory DTOs/LowStockProductDto.cs
==================================================
namespace NovaBusinessSystem.DTOs.Products.Inventory;

public record LowStockProductDto(
    int ProductID,
    string ProductName,
    string Category,
    int StockQuantity,
    string Status
);

==================================================
FILE: ./NovaBusinessSystem.DTOs/Prodcuts DTOs/Inventory DTOs/OutOfStockProductDto.cs
==================================================
namespace NovaBusinessSystem.DTOs.Products.Inventory;

public record OutOfStockProductDto(
    int ProductID,
    string ProductName,
    string Category,
    string Status
);

==================================================
FILE: ./NovaBusinessSystem.DTOs/Prodcuts DTOs/Inventory DTOs/ProductStockResponseDto.cs
==================================================
namespace NovaBusinessSystem.DTOs.Products.Inventory;

public record ProductStockResponseDto(
    int ProductID,
    string ProductName,
    string Category,
    decimal Price,
    int StockQuantity,
    decimal StockValue,
    string Status
);

==================================================
FILE: ./NovaBusinessSystem.DTOs/Prodcuts DTOs/Inventory DTOs/RemoveStockResultDto.cs
==================================================
namespace NovaBusinessSystem.DTOs.Products.Inventory;

public record RemoveStockResultDto(
    int ProductID,
    string ProductName,
    int PreviousStock,
    int RemovedStock,
    int NewStock
);

==================================================
FILE: ./NovaBusinessSystem.DTOs/Prodcuts DTOs/Product DTOs/ProductCreateRequestDto.cs
==================================================
namespace NovaBusinessSystem.DTOs.Products;

public record ProductCreateRequestDto(
    string ProductName,
    string Category,
    decimal Price,
    int StockQuantity,
    string Status
);

==================================================
FILE: ./NovaBusinessSystem.DTOs/Prodcuts DTOs/Product DTOs/ProductResponseDto.cs
==================================================
namespace NovaBusinessSystem.DTOs.Products;

public record ProductResponseDto(
    int ProductID,
    string ProductName,
    string Category,
    decimal Price,
    int StockQuantity,
    string Status
);

==================================================
FILE: ./NovaBusinessSystem.DTOs/Prodcuts DTOs/Product DTOs/ProductUpdateRequestDto.cs
==================================================
namespace NovaBusinessSystem.DTOs.Products;

public record ProductUpdateRequestDto(
    string ProductName,
    string Category,
    decimal Price,
    string Status
);

==================================================
FILE: ./NovaBusinessSystem.DTOs/Prodcuts DTOs/Reports/CategoryRevenueReportDto.cs
==================================================

namespace NovaBusinessSystem.DTOs.Products.Reports
{
    public record CategoryRevenueReportDto(
        long Rank,
        string Category,
        int Orders,
        int Units,
        decimal Revenue
    );
}


==================================================
FILE: ./NovaBusinessSystem.DTOs/Prodcuts DTOs/Reports/InventoryValuationReportDto.cs
==================================================

namespace NovaBusinessSystem.DTOs.Products.Reports
{
    public record InventoryValuationReportDto(
        string Category,
        int Products,
        int Units,
        decimal InventoryValue
    );
}


==================================================
FILE: ./NovaBusinessSystem.DTOs/Prodcuts DTOs/Reports/MonthlyProductPerformanceReportDto.cs
==================================================
namespace NovaBusinessSystem.DTOs.Products.Reports
{
    public record MonthlyProductPerformanceReportDto(
        string Month,
        int Orders,
        int Units,
        decimal Revenue,
        string Growth
    );
}


==================================================
FILE: ./NovaBusinessSystem.DTOs/Prodcuts DTOs/Reports/ProductsByCategoryReportDto.cs
==================================================
namespace NovaBusinessSystem.DTOs.Products.Reports
{
    public record ProductsByCategoryReportDto(
        string Category,
        int Products
    );
}

==================================================
FILE: ./NovaBusinessSystem.DTOs/Prodcuts DTOs/Reports/ProductStatusSummaryReportDto.cs
==================================================
namespace NovaBusinessSystem.DTOs.Products.Reports
{

    public record ProductStatusSummaryReportDto(
        string Status, int Products
    );
}

==================================================
FILE: ./NovaBusinessSystem.DTOs/Prodcuts DTOs/Reports/SalesPerformanceReportDto.cs
==================================================

namespace NovaBusinessSystem.DTOs.Products.Reports
{
    public record SalesPerformanceReportDto(
        string ProductName,
        int Orders,
        int Units,
        decimal Revenue,
        string Performance
    );
}


==================================================
FILE: ./NovaBusinessSystem.DTOs/Prodcuts DTOs/Reports/SlowMovingProductReportDto.cs
==================================================

namespace NovaBusinessSystem.DTOs.Products.Reports
{
    public record SlowMovingProductReportDto(
        string ProductName,
        string Category,
        int UnitsSold
    );
}


==================================================
FILE: ./NovaBusinessSystem.DTOs/Prodcuts DTOs/Reports/StockLevelReportDto.cs
==================================================

namespace NovaBusinessSystem.DTOs.Products.Reports
{
    public record StockLevelReportDto(
        string ProductName,
        int StockQuantity,
        string StockLevel
    );
}


==================================================
FILE: ./NovaBusinessSystem.DTOs/Prodcuts DTOs/Reports/TopSellingProductReportDto.cs
==================================================
namespace NovaBusinessSystem.DTOs.Products.Reports
{
    public record TopSellingProductReportDto(
        long Rank,
        string ProductName,
        string Category,
        int Units
    );
}

==================================================
FILE: ./NovaBusinessSystem.DTOs/Prodcuts DTOs/Reports/UnsoldProductReportDto.cs
==================================================

namespace NovaBusinessSystem.DTOs.Products.Reports
{
    public record UnsoldProductReportDto(
        int ProductID,
        string ProductName,
        string Category,
        int StockQuantity
    );
}


==================================================
FILE: ./NovaBusinessSystem.DTOs/Prodcuts DTOs/ Sales DTOs/CategoryPerformanceDto.cs
==================================================

namespace NovaBusinessSystem.DTOs.Products.Sales;

public record CategoryPerformanceDto(
    string Category,
    int Products,
    int UnitsSold,
    decimal Revenue
);


==================================================
FILE: ./NovaBusinessSystem.DTOs/Prodcuts DTOs/ Sales DTOs/LeastSellingProductDto.cs
==================================================
namespace NovaBusinessSystem.DTOs.Products.Sales;

public record LeastSellingProductDto(
    long Rank,
    string ProductName,
    int UnitsSold,
    int Orders
);

==================================================
FILE: ./NovaBusinessSystem.DTOs/Prodcuts DTOs/ Sales DTOs/MonthlyProductSalesDto.cs
==================================================
namespace NovaBusinessSystem.DTOs.Products.Sales;

public record MonthlyProductSalesDto(
    string Month,
    int Orders,
    int Units,
    decimal Revenue,
    decimal? PreviousRevenue,
    string Change
);

==================================================
FILE: ./NovaBusinessSystem.DTOs/Prodcuts DTOs/ Sales DTOs/ProductCustomerSalesDto.cs
==================================================
namespace NovaBusinessSystem.DTOs.Products.Sales;

public record ProductCustomerSalesDto(
    string ProductName,
    int UniqueCustomers,
    int TotalOrders,
    int UnitsSold,
    string TopCustomer,
    int UnitsPurchased,
    decimal AmountSpent
);

==================================================
FILE: ./NovaBusinessSystem.DTOs/Prodcuts DTOs/ Sales DTOs/ProductRevenueRankingDto.cs
==================================================
namespace NovaBusinessSystem.DTOs.Products.Sales;

public record ProductRevenueRankingDto(
    long Rank,
    string ProductName,
    int UnitsSold,
    decimal RevenueFromCompletedSales
);

==================================================
FILE: ./NovaBusinessSystem.DTOs/Prodcuts DTOs/ Sales DTOs/ProductSalesHistoryDto.cs
==================================================
namespace NovaBusinessSystem.DTOs.Products.Sales;

public record ProductSalesHistoryDto(
    int SaleID,
    string SaleDate,
    string CustomerName,
    int Quantity,
    decimal UnitPrice,
    string Status
);

==================================================
FILE: ./NovaBusinessSystem.DTOs/Prodcuts DTOs/ Sales DTOs/ProductSalesSummaryDto.cs
==================================================
namespace NovaBusinessSystem.DTOs.Products.Sales;

public record ProductSalesSummaryDto(
    int ProductID,
    string ProductName,
    string Category,
    int Orders,
    int UnitsSold,
    decimal Revenue,
    decimal AverageQuantity,
    decimal AverageRevenue
);

==================================================
FILE: ./NovaBusinessSystem.DTOs/Prodcuts DTOs/ Sales DTOs/TopSellingProductDto.cs
==================================================
namespace NovaBusinessSystem.DTOs.Products.Sales;

public record TopSellingProductDto(
    long Rank,
    string ProductName,
    int UnitsSold,
    int Orders
);

==================================================
FILE: ./NovaBusinessSystemPL/Helpers/ConsoleHelper.cs
==================================================
using System.Reflection.Metadata;

namespace NovaBusinessSystem.Helpers
{

    public static class ConsoleHelper
    {

        public static string GenarateTabs(int numberTab)
        {
            string Tab = "";

            if (numberTab < 0) return "";

            for (int counter = 1; counter <= numberTab; counter += 1)
                Tab += '\t';

            return Tab;
        }

        private static int GetDisplayWIdth(string Text)
        {
            int width = 0;

            foreach (char character in Text)
            {


                width += char.GetUnicodeCategory(character) switch
                {
                    System.Globalization.UnicodeCategory.OtherSymbol => 2,
                    _ => 1
                };

            }

            return width;
        }

        public static void PrintHeader(string? TitleHeader, int? numberTab)
        {
            if (TitleHeader is null) return;
            if (numberTab is null) return;

            const int BoxBorders = 2;
            int width = 42;
            int contentLength = width - BoxBorders;
            int titleWidth = GetDisplayWIdth(TitleHeader);

            double paddingLeft = Math.Ceiling((contentLength - titleWidth) / 2.0);
            double paddingRight = contentLength - titleWidth - paddingLeft + 2;

            string Tabs = GenarateTabs(numberTab.Value);

            Console.WriteLine($"{Tabs}╔══════════════════════════════════════════╗");
            Console.WriteLine(
                $"{Tabs}║{new string(' ', (int)paddingLeft)}{TitleHeader.Trim()}{new string(' ', (int)paddingRight)}║"
            );
            Console.WriteLine($"{Tabs}╚══════════════════════════════════════════╝");
        }

        public static void PrintHeaderErrors(string? TitleHeader, int? numberTab)
        {
            if (TitleHeader is null) return;
            if (numberTab is null) return;

            const int BoxBorders = 2;
            int width = 72;
            int contentLength = width - BoxBorders;
            int titleWidth = GetDisplayWIdth(TitleHeader);

            double paddingLeft = Math.Ceiling((contentLength - titleWidth) / 2.0);
            double paddingRight = contentLength - titleWidth - paddingLeft + 2;

            string Tabs = GenarateTabs(numberTab.Value);

            Console.WriteLine($"{Tabs}╔════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine(
                $"{Tabs}║{new string(' ', (int)paddingLeft)}{TitleHeader.Trim()}{new string(' ', (int)paddingRight)}║"
            );
            Console.WriteLine($"{Tabs}╠════════════════════════════════════════════════════════════════════════╣");
        }

        public static void ReadInformation(string label, int alignmentNumber, int numberTabs)
        {
            Console.Write($"{GenarateTabs(numberTabs)}{label.PadRight(alignmentNumber) + " : "}");
        }

        public static string? ReadTheStringWithoutNumbers(string label, int alignemntNumber, int numberTabs)
        {

            if (alignemntNumber < 0 || numberTabs < 0 || string.IsNullOrWhiteSpace(label))
                return null;

            string text = string.Empty;

            while (true)
            {
                ReadInformation(label, alignemntNumber, numberTabs);
                text = Console.ReadLine()!;
                Console.WriteLine();
                bool isFound = false;

                if (!string.IsNullOrWhiteSpace(text))
                    foreach (char character in text)
                    {
                        if (char.IsDigit(character) || char.IsPunctuation(character) || Char.IsNumber(character) || char.IsSymbol(character) || char.IsWhiteSpace(character))
                        {
                            isFound = true;
                            break;
                        }

                    }


                if (!isFound && !string.IsNullOrWhiteSpace(text))
                    break;
            }

            return text;
        }


        public static T? ReadTheStringWithNumbers<T>(string label, int alignemntNumber, int numberTabs)
        {

            if (alignemntNumber < 0 || numberTabs < 0 || string.IsNullOrWhiteSpace(label))
                return default(T);

            string obj = string.Empty;

            string text = "";
            while (true)
            {
                ReadInformation(label, alignemntNumber, numberTabs);
                text = Console.ReadLine()!;
                Console.WriteLine();

                bool isFound = false;

                foreach (char character in text)
                {
                    if (char.IsLetter(character) || char.IsPunctuation(character) || char.IsSymbol(character))
                    {
                        isFound = true;
                        break;
                    }

                }

                if (!isFound)
                    break;
            }


            return (T)Convert.ChangeType(text, typeof(T));

        }

        public static void ShowNotFoundMessage(string MessageHeader , string MessageBody , string? MessageReason = null )
        {
            System.Console.WriteLine("\n\n");
            PrintHeaderErrors(MessageHeader, 5);
            Console.WriteLine($"{GenarateTabs(5)}║ {MessageBody.Trim(),-50}                     ║");
            if (MessageReason is not null)
                Console.WriteLine($"{GenarateTabs(5)}║ Reason: {MessageReason.Trim(),-50}             ║");
            Console.WriteLine($"{GenarateTabs(5)}╚════════════════════════════════════════════════════════════════════════╝");
        }
        
    }
}

==================================================
FILE: ./NovaBusinessSystemPL/Helpers/InputHelper.cs
==================================================
namespace NovaBusinessSystem.Helpers
{
    public static class InputHelper
    {

        public static int ReadTheID(string? Title, string? Message)
        {
            Console.Clear();
            System.Console.WriteLine("\n\n\n");

            ConsoleHelper.PrintHeader(Title, 7);
            System.Console.WriteLine("\n\n");
            System.Console.Write($"{ConsoleHelper.GenarateTabs(7)}{Message}");
            int ID = -1;
            while (!int.TryParse(Console.ReadLine(), out ID))
                System.Console.Write($"{ConsoleHelper.GenarateTabs(7)}Invalid Data ID : ");

            System.Console.WriteLine("\n\n");


            return ID;
        }
    }
}

==================================================
FILE: ./NovaBusinessSystemPL/Moduls/Customers Module/CustomersPL.cs
==================================================
using Microsoft.Data.SqlClient;
using NovaBusinessSystem.DTOs;
using NovaBusinessSystem.BL.Customers;
using NovaBusinessSystem.Enumeration;
using NovaBusinessSystem.Helpers;
using NovaBusinessSystem.Modules.Customers.Loyalty;
using NovaBusinessSystem.Modules.Customers.Purchases;
using NovaBusinessSystem.Modules.Customers.Reports;

namespace NovaBusinessSystemPL.Modules.Customers
{


    public class CustomersPL
    {
        private static void PrintDetail(string label, object? value, int numberTabs)
        {
            const int ContentWidth = 50;

            string Text = $"{label,-20} : {value ?? " "}";

            if (Text.Length > ContentWidth)
                Text = Text[..ContentWidth];


            Console.WriteLine($"{ConsoleHelper.GenarateTabs(numberTabs)}║ {Text,-48}║");
        }

        private static void _ShowSccessMessageAndShowInformationCustomer(CustomersBL informationCustomer, string message)
        {

            int width = 50;
            int contentWidth = width - 2;

            int paddingLeft = (contentWidth - message.Length) / 2;
            int paddingRight = contentWidth - message.Length - paddingLeft - 1;

            System.Console.WriteLine("\n\n\n");
            Console.WriteLine($"\n\n{ConsoleHelper.GenarateTabs(7)}╔═════════════════════════════════════════════════╗");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║{new string(' ', paddingLeft)}{message}{new string(' ', paddingRight)} ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}╚═════════════════════════════════════════════════╝");

            PrintDetail("Customer ID", informationCustomer.CustomerID, 7);
            PrintDetail("First Name", informationCustomer.FirstName, 7);
            PrintDetail("Last Name", informationCustomer.LastName, 7);
            PrintDetail("Email", informationCustomer.Email, 7);
            PrintDetail("Phone", informationCustomer.Phone, 7);
            PrintDetail("City", informationCustomer.City.Trim(), 7);
            PrintDetail("Registration Date", $"{informationCustomer.RegistrationDate.ToString("dd/MM/yyyy")}", 7);
            PrintDetail("Status", informationCustomer.Status, 7);
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}╚═════════════════════════════════════════════════╝");
        }

        private static void _MainMenuCustomersModule()
        {
            Console.WriteLine($"\n\n\n{ConsoleHelper.GenarateTabs(7)}╔══════════════════════════════════════════╗");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║              👥 CUSTOMERS                ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}╠══════════════════════════════════════════╣");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║                                          ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║  1. 📋 List Customers                    ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║  2. 🔎 Get Customer By ID                ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║  3. ➕ Add Customer                      ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║  4. ✏️  Update Customer                   ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║  5. 🗑️  Delete Customer                   ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║  6. 🔍 Search Customers                  ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║  7. ⭐ Loyalty Points                    ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║  8. 🛒 Customer Purchases                ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║  9. 📊 Customer Report                   ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║                                          ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║  0. 🔙 Back                              ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║                                          ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}╚══════════════════════════════════════════╝");

        }

        private static void _PrintCustomerDetails(CustomersBL informationCustomer, string? title)
        {
            if ((informationCustomer is null) || string.IsNullOrWhiteSpace(title))
                return;

            ConsoleHelper.PrintHeader(title, 7);

            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║ {"ID",-16} : {informationCustomer.CustomerID,-20}  ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║ {"Name",-16} : {string.Join(" ", informationCustomer.FirstName, informationCustomer.LastName),-20}  ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║ {"Email",-16} : {informationCustomer.Email,-20}  ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║ {"Phone",-16} : {informationCustomer.Phone,-20}  ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║ {"City",-16} : {informationCustomer.City,-20}  ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║ {"Registration",-16} : {informationCustomer.RegistrationDate,-20:dd/MM/yyyy}  ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║ {"Loyalty Points",-16} : {informationCustomer.LoyaltyPoints,-20}  ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║ {"Status",-16} : {informationCustomer.Status,-20}  ║");

            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}╚══════════════════════════════════════════╝");
        }

        private static void _CustomersList()
        {
            Console.Clear();

            System.Console.WriteLine("\n\n");

            ConsoleHelper.PrintHeader("📋 CUSTOMER LIST", 7);
            System.Console.WriteLine("\n\n\n");
            System.Console.WriteLine($"\t\t{"ID",-15} {"Name",-30} {"Email",-40} {"City",-15} {"Points",-10} {"Status",-15}");

            System.Console.WriteLine($"\t\t{new string('-', 123)}");
            List<CustomerDTO> L_ALlCustomers = CustomersBL.GetCustomersList().ToList();

            foreach (var Item_Customer in L_ALlCustomers)
                System.Console.WriteLine($"\t\t{Convert.ToInt32(Item_Customer.CustomerID),-15} {string.Join(" ", Item_Customer.FirstName, Item_Customer.LastName),-30} {Item_Customer.Email,-40} {Item_Customer.City,-15} {Convert.ToInt32(Item_Customer.LoyaltyPoints),-10} {Item_Customer.Status,-15}");
            System.Console.WriteLine($"\t\t{new string('-', 123)}\n\n");

            System.Console.WriteLine($"\t\tTotal Customers: {L_ALlCustomers.Count}\n\n");


        }

        private static string GetStatus(byte status)
        {
            switch (status)
            {
                case 0:
                    return "Inactive";
                case 1:
                    return "Active";
                case 2:
                    return "Blocked";

                default: return "";
            }
        }

        private static CustomerDTO? ReadInformationCustoemr()
        {
            string? firstName = ConsoleHelper.ReadTheStringWithoutNumbers("First Name", 15, 7);
            string? lastName = ConsoleHelper.ReadTheStringWithoutNumbers("Last Name", 15, 7);
            string? Email = ConsoleHelper.ReadTheStringWithoutNumbers("Email", 15, 7);
            string? Phone = ConsoleHelper.ReadTheStringWithNumbers<string>("Phone", 15, 7);
            string? City = ConsoleHelper.ReadTheStringWithoutNumbers("City", 15, 7);

            byte status = 0;

            System.Console.Write($"{ConsoleHelper.GenarateTabs(7)}Status (Active:1 , Inactive:0 , Blocked:2) : ");
            while (!byte.TryParse(Console.ReadLine(), out status))
                System.Console.Write($"{ConsoleHelper.GenarateTabs(7)}Try Agian , Status (Active:1 , Inactive:0 , Blocked:2) : ");

            string StatusString = GetStatus(status);

            return new CustomerDTO(-1, firstName!, lastName!, Email!, Phone!, City!, DateTime.Now, (short)0, StatusString);

        }

        private static int ReadTheID()
        {
            Console.Clear();
            System.Console.WriteLine("\n\n\n");

            ConsoleHelper.PrintHeader("🔎 GET CUSTOMER BY ID", 7);
            System.Console.WriteLine("\n\n");
            System.Console.Write($"{ConsoleHelper.GenarateTabs(7)}Enter Customer ID: ");
            int ID = -1;
            while (!int.TryParse(Console.ReadLine(), out ID))
                System.Console.Write($"{ConsoleHelper.GenarateTabs(7)}Invalid Data ID : ");

            System.Console.WriteLine("\n\n");


            return ID;
        }

        private static CustomersBL? GetCustomerByID()
        {

            System.Console.WriteLine("\n\n");
            CustomersBL customerInfo = CustomersBL.Find(ReadTheID())!;

            try
            {
                if (customerInfo is not null)
                    _PrintCustomerDetails(customerInfo, "👤 CUSTOMER DETAILS");
                else ConsoleHelper.ShowNotFoundMessage($"Employee with ID {customerInfo?.CustomerID} was not found.", "❌ NOT FOUND", "Customer could not be found.");

            }
            catch (SqlException SEX)
            {
                ConsoleHelper.ShowNotFoundMessage(SEX.Message, "❌ NOT FOUND", "Customer could not be found.");
            }

            return customerInfo;
        }

        private static void AddNewCustomer()
        {

            Console.Clear();
            System.Console.WriteLine("\n\n\n");
            ConsoleHelper.PrintHeader("➕ ADD CUSTOMER", 7);

            try
            {
                CustomerDTO? customer = ReadInformationCustoemr();
                CustomersBL? customersBL = new CustomersBL();
                customersBL.ConvertDTOtoObject(customer!);

                if (customersBL!.SaveModeCustomer())
                {
                    _ShowSccessMessageAndShowInformationCustomer(customersBL, "✅ CUSTOMER ADDED");
                }


            }
            catch (SqlException SEX)
            {
                ConsoleHelper.ShowNotFoundMessage(SEX.Message, "❌ CUSTOMER NOT ADDED", "Customer could not be added.");
            }

        }

        private static void _UpdateCustomer()
        {

            Console.Clear();

            try
            {
                CustomersBL infoCustomer = GetCustomerByID()!;
                System.Console.WriteLine("\n\n\n");
                ConsoleHelper.PrintHeader("UPDATE CUSTOMER", 7);
                if (infoCustomer is not null)
                {
                    System.Console.WriteLine("\n\n");

                    CustomerDTO? customer = ReadInformationCustoemr();
                    infoCustomer.ConvertDTOtoObject(customer!);

                    if (infoCustomer!.SaveModeCustomer())
                    {
                        _ShowSccessMessageAndShowInformationCustomer(infoCustomer, "✅ CUSTOMER UPDATED");
                    }
                }

            }
            catch (SqlException SEX)
            {
                ConsoleHelper.ShowNotFoundMessage(SEX.Message, "❌ CUSTOMER NOT UPDATED", "Customer could not be UPDATED.");
            }

        }

        private static void _DeleteCustomer()
        {

            Console.Clear();

            try
            {
                CustomersBL infoCustomer = GetCustomerByID()!;
                System.Console.WriteLine("\n\n\n");
                ConsoleHelper.PrintHeader("🗑️  DELETE CUSTOMER", 7);

                if (infoCustomer is not null)
                {
                    System.Console.WriteLine("\n\n");

                    Console.Write($"{ConsoleHelper.GenarateTabs(7)}Are you sure you want to delete this customer?\n");
                    Console.Write($"{ConsoleHelper.GenarateTabs(7)}Y = Yes N = No  Choice: ");
                    char choice = 'n';

                    while (!char.TryParse(Console.ReadLine(), out choice) || char.ToLower(choice) is not ('y' or 'n'))

                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}Invalid Choive , pLease Enter valid choive -> Y = Yes N = No  Choice: ");

                    if (char.ToLower(choice) == 'y')
                    {
                        if (infoCustomer.DeleteCustomer())
                            _ShowSccessMessageAndShowInformationCustomer(infoCustomer, "✅ CUSTOMER DELETED");
                        else
                            ConsoleHelper.ShowNotFoundMessage("❌ DELETE FAILED", "This customer cannot be deleted because\nthey have existing sales records.");
                    }
                    else
                        ConsoleHelper.ShowNotFoundMessage("ℹ️  DELETE CANCELLED ", "No changes were made.");
                }

            }
            catch (SqlException SEX)
            {
                ConsoleHelper.ShowNotFoundMessage(SEX.Message, "❌ CUSTOMER NOT UPDATED", "Customer could not be UPDATED.");
            }

        }

        public static async Task StartUpCustomersModule()
        {

            while (true)
            {
                Console.Clear();

                _MainMenuCustomersModule();

                Console.Write($"\n\n\n{ConsoleHelper.GenarateTabs(7)}Select: ");
                byte ChoiceCustomer = 0;
                while (!byte.TryParse(Console.ReadLine(), out ChoiceCustomer) || ChoiceCustomer > 9)
                    System.Console.WriteLine("\t\tInvalid Choice Customer Menu ");

                switch ((Enumerations.EnChoicesCustomersModule)ChoiceCustomer)
                {
                    case Enumerations.EnChoicesCustomersModule._kLIST_CUSTOMERS:
                        {
                            _CustomersList();
                            break;

                        }
                    case Enumerations.EnChoicesCustomersModule._kGET_CUSTOMER_BY_ID:
                        {
                            GetCustomerByID();
                            break;
                        }

                    case Enumerations.EnChoicesCustomersModule._kADD_NEW_CUSTOMER:
                        {
                            AddNewCustomer();
                            break;
                        }

                    case Enumerations.EnChoicesCustomersModule._kUPDATE_INFORMATION_CUSTOMER:
                        {
                            _UpdateCustomer();
                            break;
                        }

                    case Enumerations.EnChoicesCustomersModule._kDELETE_CUSTOMER:
                        {
                            _DeleteCustomer();
                            break;
                        }

                    case Enumerations.EnChoicesCustomersModule._kLOYALTY_POINTS:
                        {
                            await LoyaltyMenu.StartUpLoyaltyPointsSection();
                            break;
                        }
                    case Enumerations.EnChoicesCustomersModule._kCUSTOMER_PURCHASES:
                        {
                            await PurchasesMenu.StartupPurchasesCustomers();
                            break;
                        }

                    case Enumerations.EnChoicesCustomersModule._kCUSTOMER_REPORT :
                        {
                            await ReportMenu.StartupReportSection();
                            break;
                        }
                }


                Console.WriteLine($"\n{ConsoleHelper.GenarateTabs(7)}Press any key to continue...");
                Console.ReadKey();
            }
        }


    }
}

==================================================
FILE: ./NovaBusinessSystemPL/Moduls/Employees Module/Employees.cs
==================================================
// using System.Data;
// using NovaBusinessSystem.BL;
// using NovaBusinessSystem.Enumeration;

// namespace EmployeesPL
// {

//   public class EmployeesPL
//   {


//     private static void _ShowNotFoundMessage(string MessageReason, string MessageHeader, string MessageBody)
//     {
//       Console.WriteLine("\n\n\t\t╔════════════════════════════════════════════════════════════════════════╗");
//       Console.WriteLine($"\t\t║                  {MessageHeader}                                 ║");
//       Console.WriteLine("\t\t╠════════════════════════════════════════════════════════════════════════╣");
//       Console.WriteLine($"\t\t║ {MessageBody,-50}                             ║");
//       Console.WriteLine($"\t\t║ Reason: {MessageReason,-50}  ║");
//       Console.WriteLine("\t\t╚════════════════════════════════════════════════════════════════════════╝");
//     }

//     private static void PrintDetail(string label, object? value)
//     {
//       const int ContentWidth = 50;

//       string Text = $"{label,-13} : {value ?? " "}";

//       if (Text.Length > ContentWidth)
//         Text = Text[..ContentWidth];


//       Console.WriteLine($"\t\t║ {Text,-48}║");
//     }

//     private static void _ShowSccessMessageAndShowInformationEmployee(EmployeesBL informationEmployee, string message)
//     {

//       int width = 50;
//       int contentWidth = width - 2;

//       int paddingLeft = (contentWidth - message.Length) / 2;
//       int paddingRight = contentWidth - message.Length - paddingLeft - 1;


//       Console.WriteLine("\n\n\t\t╔═════════════════════════════════════════════════╗");
//       Console.WriteLine($"\t\t║{new string(' ', paddingLeft)}{message}{new string(' ', paddingRight)} ║");
//       Console.WriteLine("\t\t╚═════════════════════════════════════════════════╝");

//       PrintDetail("ID", informationEmployee.ID);
//       PrintDetail("First Name", informationEmployee.FirstName);
//       PrintDetail("Last Name", informationEmployee.LastName);
//       PrintDetail("Department ID", informationEmployee.DepartmentID);
//       PrintDetail("Manager ID", informationEmployee.ManagerID);
//       PrintDetail("Job Title", informationEmployee.JobTitle.Trim());
//       PrintDetail("Salary", $"{informationEmployee.Salary:N2}");
//       PrintDetail("Hire Date", DateTime.Now.ToString("dd/MM/yyyy"));
//       PrintDetail("Phone", informationEmployee.Phone);
//       PrintDetail("Email", informationEmployee.Email);
//       PrintDetail("Status", _GetStatusEmployee(informationEmployee.Status));

//       Console.WriteLine("\t\t╚═════════════════════════════════════════════════╝");
//     }

//     private static void PrintScreenMenuEmployeesModule(out byte ChoiseEmployeesModule)
//     {
//       System.Console.WriteLine("\n\n\n\n");
//       Console.WriteLine("\t\t╔══════════════════════════════════════════╗");
//       Console.WriteLine("\t\t║              👨‍💼 EMPLOYEES              ║");
//       Console.WriteLine("\t\t╠══════════════════════════════════════════╣");
//       Console.WriteLine("\t\t║                                          ║");
//       Console.WriteLine("\t\t║  1. 📋 List Employees                    ║");
//       Console.WriteLine("\t\t║  2. 🔎 Get Employee By ID                ║");
//       Console.WriteLine("\t\t║  3. ➕ Add Employee                      ║");
//       Console.WriteLine("\t\t║  4. ✏️  Update Employee                   ║");
//       Console.WriteLine("\t\t║  5. 🗑️  Delete Employee                   ║");
//       Console.WriteLine("\t\t║  6. 🔍 Search Employees                  ║");
//       Console.WriteLine("\t\t║  7. 📊 Employee Report                   ║");
//       Console.WriteLine("\t\t║                                          ║");
//       Console.WriteLine("\t\t║  0. 🔙 Back                              ║");
//       Console.WriteLine("\t\t║                                          ║");
//       Console.WriteLine("\t\t╚══════════════════════════════════════════╝");

//       System.Console.Write("\n\n\t\tSelect : ");

//       while (!Byte.TryParse(Console.ReadLine(), out ChoiseEmployeesModule) || ChoiseEmployeesModule > 7)
//         System.Console.Write("\t\tInvalid Choice Employees : ");

//     }

//     private static void _EmployeesList(string? FullName = null, string? DepartmentName = null, string? JobTitle = null, string? Status = null)
//     {

//       Console.Clear();
//       DataTable DT_AllEmployees = EmployeesBL.GetAllEmployees(FullName, DepartmentName, JobTitle, Status);

//       if (DT_AllEmployees is null || DT_AllEmployees.Rows.Count == 0)
//       {
//         Console.WriteLine("\t\t╔══════════════════════════════════════════╗");
//         Console.WriteLine("\t\t║             ❌ NO RESULTS                ║");
//         Console.WriteLine("\t\t╠══════════════════════════════════════════╣");
//         Console.WriteLine("\t\t║ No employees matched your search.        ║");
//         Console.WriteLine("\t\t╚══════════════════════════════════════════╝\n\n");

//         return;
//       }


//       System.Console.WriteLine($"\n\n\t\t {"ID",-10} {"Name",-35} {"Department",-20} {"Job Title",-30} {"Salary",-20} {"Status",-15}");
//       System.Console.WriteLine("\t\t" + new string('-', 125));

//       foreach (DataRow DR_Employee in DT_AllEmployees.Rows)
//       {

//         System.Console.WriteLine(
//           $"\t\t {Convert.ToInt32(DR_Employee["EmployeeID"]),-10} {DR_Employee["FullName"].ToString(),-35} {DR_Employee["DepartmentName"].ToString(),-20} {DR_Employee["JobTitle"].ToString(),-30} {(Convert.ToDouble(DR_Employee["Salary"])).ToString("C"),-20} {DR_Employee["Status"].ToString(),-15}");
//       }

//       System.Console.WriteLine("\t\t" + new string('-', 125));

//       System.Console.WriteLine($"\n\n\t\tTotal Employees : {DT_AllEmployees.Rows.Count}");

//     }

//     private static EmployeesBL? _GetEmployeeBy(int EmployeeID)
//     {

//       EmployeesBL EmployeeInfo = EmployeesBL.FindEmployeeBy(EmployeeID);

//       if (EmployeeInfo is not null)
//       {
//         System.Console.WriteLine("\n\n\n");
//         _ShowSccessMessageAndShowInformationEmployee(EmployeeInfo, "EMPLOYEE DETAILS");
//         return EmployeeInfo;
//       }
//       else
//       {
//         _ShowNotFoundMessage($"Employee with ID {EmployeeID} was not found.", "❌ NOT FOUND", "Employee could not be found.");
//       }

//       return null;

//     }

//     private static void ReadInformationEmployees(EmployeesBL NewEmployee)
//     {

//       Console.Write($"\n\n\t\t{"First Name",-16}: ");

//       string? FirstName = Console.ReadLine()!;
//       string Test = Console.ReadLine()!;
      
//       while (true)
//       {
//         bool isPass = true;

//         if (string.IsNullOrWhiteSpace(FirstName))
//           isPass = false;
//         else
//         {
//           foreach (char c in FirstName)
//             if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
//             {
//               isPass = false;
//               break;
//             }
//         }

//         if (!isPass)
//         {
//           Console.Write($"\t\t{"Invalid! First Name",-16}: ");
//           FirstName = Console.ReadLine()!;
//         }
//         else
//           break;
//       }

//       NewEmployee.FirstName = FirstName!;

//       Console.Write($"\t\t{"Last Name",-16}: ");

//       string? LastName = Console.ReadLine();
//       while (true)
//       {
//         bool isPass = true;

//         if (string.IsNullOrWhiteSpace(LastName))
//           isPass = false;
//         else
//         {
//           foreach (char c in LastName)
//             if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
//             {
//               isPass = false;
//               break;
//             }
//         }

//         if (!isPass)
//         {
//           Console.Write($"\t\t{"Invalid! Last Name",-16}: ");
//           LastName = Console.ReadLine();
//         }
//         else
//           break;
//       }

//       NewEmployee.LastName = LastName!;


//       Console.Write($"\t\t{"Department ID",-16}: ");
//       int deptID = 0;

//       while (!int.TryParse(Console.ReadLine(), out deptID))
//       {
//         Console.Write($"\t\t{"Invalid! Department ID",-16}: ");
//       }

//       NewEmployee.DepartmentID = deptID;

//       Console.Write($"\t\t{"Manager ID",-16}: ");
//       int mangeID = 0;

//       while (!int.TryParse(Console.ReadLine(), out mangeID))
//         Console.Write($"\t\t{"Invalid! Manager ID",-16}: ");

//       NewEmployee.ManagerID = mangeID;

//       Console.Write($"\t\t{"Job Title",-16}: ");

//       string? JobTitle = Console.ReadLine()!;

//       while (true)
//       {
//         bool isPass = true;

//         if (string.IsNullOrWhiteSpace(JobTitle))
//           isPass = false;
//         else
//         {
//           foreach (char c in JobTitle)
//             if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
//             {
//               isPass = false;
//               break;
//             }
//         }

//         if (!isPass)
//         {
//           Console.Write($"\t\t{"Invalid! Job Title",-16}: ");
//           JobTitle = Console.ReadLine();
//         }
//         else
//           break;
//       }


//       NewEmployee.JobTitle = JobTitle!;

//       Console.Write($"\t\t{"Salary",-16}: ");
//       decimal newSalary = 0.0m;

//       while (!decimal.TryParse(Console.ReadLine(), out newSalary) || newSalary < 0)
//         Console.Write($"\t\t{"Invalid! Salary ",-16}: ");

//       NewEmployee.Salary = newSalary;

//       Console.Write($"\t\t{"Phone",-16}: ");

//       string? Phone = Console.ReadLine()!;

//       while (true)
//       {
//         bool isPass = true;

//         if (string.IsNullOrWhiteSpace(Phone))
//           isPass = false;
//         else
//         {
//           foreach (char c in Phone)
//             if (!char.IsDigit(c))
//             {
//               isPass = false;
//               break;
//             }
//         }

//         if (!isPass)
//         {
//           Console.Write($"\t\t{"Invalid! Phone",-16}: ");
//           Phone = Console.ReadLine();
//         }
//         else
//           break;
//       }


//       NewEmployee.Phone = Phone!;

//       Console.Write($"\t\t{"Email",-16}: ");

//       string Email = Console.ReadLine()!;

//       while (true)
//       {
//         bool isPass = true;

//         if (string.IsNullOrWhiteSpace(Email))
//           isPass = false;
//         else
//         {
//           if (!Email.Contains(".com") || !Email.Contains("@"))
//             isPass = false;
//         }

//         if (!isPass)
//         {
//           Console.Write($"\t\t{"Invalid! Email ",-16}: ");
//           Email = Console.ReadLine()!;
//         }
//         else
//           break;
//       }

//       NewEmployee.Email = Email;

//     }

//     private static void _AddNewEmployee()
//     {

//       Console.WriteLine("\n\n\t\t╔══════════════════════════════════════════╗");
//       Console.WriteLine("\t\t║              ➕ ADD EMPLOYEE             ║");
//       Console.WriteLine("\t\t╚══════════════════════════════════════════╝");

//       EmployeesBL NewEmployee = new EmployeesBL();

//       ReadInformationEmployees(NewEmployee);
//       try
//       {

//         if (NewEmployee.SaveModeEmployees())
//         {
//           _ShowSccessMessageAndShowInformationEmployee(NewEmployee, "✅ EMPLOYEE ADDED");
//         }
//       }
//       catch (SqlException SEX)
//       {
//         _ShowNotFoundMessage($"Employee with ID {SEX.Message} was not found.", "❌ EMPLOYEE NOT ADDED", "Employee could not be added.");
//       }

//     }

//     private static string _GetStatusEmployee(Enumerations.EnStatus Status)
//     {

//       switch (Status)
//       {
//         case Enumerations.EnStatus._kACTIVE:
//           return "Active";
//         case Enumerations.EnStatus._kINACTIVE:
//           return "Inactive";
//         case Enumerations.EnStatus._kSUSPENDED:
//           return "Suspended";
//         default: return "";
//       }

//     }

//     private static void _UpdateEmployee()
//     {
//       Console.WriteLine("\n\n\t\t╔══════════════════════════════════════════╗");
//       Console.WriteLine("\t\t║            ✏️ UPDATE EMPLOYEE            ║");
//       Console.WriteLine("\t\t╚══════════════════════════════════════════╝");

//       int EmployeeID = 0;

//       System.Console.Write("\n\n\t\tEnter Employee ID: ");

//       while (!int.TryParse(Console.ReadLine(), out EmployeeID))
//         Console.Write($"\t\t{"Invalid! Employee ID",-16}: ");

//       EmployeesBL InfoEmployee = _GetEmployeeBy(EmployeeID)!;

//       if (InfoEmployee is not null)
//       {
//         ReadInformationEmployees(InfoEmployee);

//         Console.Write($"\n\t\t{"Enter Status(Active:1 , Inactive:0 , Suspended:2)",-16}: ");
//         byte status = 0;

//         while (!byte.TryParse(Console.ReadLine(), out status) || (status > 2))
//           Console.Write($"\t\t{"Invalid! Status Employee",-16}: ");

//         InfoEmployee.Status = (Enumerations.EnStatus)status;

//         try
//         {

//           if (InfoEmployee.SaveModeEmployees())
//           {
//             _ShowSccessMessageAndShowInformationEmployee(InfoEmployee, "✅ EMPLOYEE UPDATED");
//           }

//         }
//         catch (SqlException SEX)
//         {
//           _ShowNotFoundMessage($"{SEX.Message}", "❌ NOT FOUND", "Employee could not be found.");
//         }
//       }
//     }

//     private static void _DeleteEmployee()
//     {
//       Console.WriteLine("\n\n\t\t╔══════════════════════════════════════════╗");
//       Console.WriteLine("\t\t║            🗑️ DELETE EMPLOYEE             ║");
//       Console.WriteLine("\t\t╚══════════════════════════════════════════╝\n");

//       Console.Write("\n\t\tEnter Employee ID to delete: ");

//       int EmployeeID = 0;

//       while (!int.TryParse(Console.ReadLine(), out EmployeeID))
//         System.Console.WriteLine("\n\t\tInvalid!! Employee ID");


//       EmployeesBL InfoEmployee = EmployeesBL.FindEmployeeBy(EmployeeID);

//       if (InfoEmployee is null)
//         _ShowNotFoundMessage($"Employee with ID {EmployeeID} was not found.", "❌ NOT FOUND", "Employee could not be found.");
//       else
//       {

//         EmployeesBL CopyInfoEmployee = InfoEmployee;

//         _GetEmployeeBy(EmployeeID);
//         System.Console.WriteLine("\n\n");

//         Console.Write("\t\tAre you sure you want to delete this employee?\n");
//         System.Console.Write("\t\t(Y = Yes, N = No)\n");
//         System.Console.Write("\t\tChoice: ");

//         char choice = 'N';

//         while (!char.TryParse(Console.ReadLine(), out choice))
//           System.Console.Write("\t\tInvalid!! Choice");

//         if (char.ToLower(choice) == 'y')
//         {
//           try
//           {
//             if (EmployeesBL.DeleteEmployee(EmployeeID))
//             {
//               string FullNameManager = string.Join(" ", CopyInfoEmployee.FirstName, CopyInfoEmployee.LastName);

//               Console.WriteLine("\n\n\t\t╔══════════════════════════════════════════╗");
//               Console.WriteLine("\t\t║          ✅ EMPLOYEE DELETED             ║");
//               Console.WriteLine("\t\t╠══════════════════════════════════════════╣");
//               Console.WriteLine($"\t\t║ Employee ID : {CopyInfoEmployee.ID,-27} ║");
//               Console.WriteLine($"\t\t║ Name        : {FullNameManager,-27}║");
//               Console.WriteLine("\t\t╚══════════════════════════════════════════╝");

//             }
//           }
//           catch
//           {
//             _ShowNotFoundMessage($"Employee with ID {EmployeeID} was not found.", "❌ ERROR", "Employee could not be found. ");
//           }


//         }
//         else
//         {
//           Console.WriteLine("\n\n\t\t╔══════════════════════════════════════════╗");
//           Console.WriteLine("\t\t║          ℹ️ DELETE CANCELLED              ║");
//           Console.WriteLine("\t\t╠══════════════════════════════════════════╣");
//           Console.WriteLine("\t\t║ No changes were made.                    ║");
//           Console.WriteLine("\t\t╚══════════════════════════════════════════╝");
//         }
//       }


//     }

//     private static void _SearchEmployee()
//     {
//       while (true)
//       {
//         Console.Clear();

//         Console.WriteLine("\t\t╔══════════════════════════════════════════╗");
//         Console.WriteLine("\t\t║             🔍 SEARCH EMPLOYEES          ║");
//         Console.WriteLine("\t\t╚══════════════════════════════════════════╝");

//         Console.WriteLine();
//         Console.WriteLine("\t\tSearch by:\n\n");
//         Console.WriteLine("\t\t1. Name");
//         Console.WriteLine("\t\t2. Department");
//         Console.WriteLine("\t\t3. Job Title");
//         Console.WriteLine("\t\t4. Status");

//         Console.WriteLine("\t\t0. Back\n\n");

//         Console.Write("\t\tSelect: ");
//         byte Choice = 0;

//         while (!byte.TryParse(Console.ReadLine(), out Choice) || Choice > 4)
//           System.Console.Write("\t\tInvalid!! Choice Search Employee");


//         Enumerations.EnChoicesSearchEmployees ChoiceSearchEmployee = (Enumerations.EnChoicesSearchEmployees)Choice;

//         switch (ChoiceSearchEmployee)
//         {
//           case Enumerations.EnChoicesSearchEmployees._kSEARCH_BY_FULL_NAME:
//             {

//               System.Console.Write("\n\n\t\tEnter Full Name : ");
//               string? FullName = Console.ReadLine()!;

//               _EmployeesList(FullName);
//               break;
//             }

//           case Enumerations.EnChoicesSearchEmployees._kSEARCH_BY_DEPARTMENT_NAME:
//             {

//               System.Console.Write("\n\n\t\tEnter Department Name : ");
//               string? DepartmentName = Console.ReadLine()!;

//               _EmployeesList(null, DepartmentName);

//               break;
//             }

//           case Enumerations.EnChoicesSearchEmployees._kSEARCH_BY_JOB_TITLE:
//             {

//               System.Console.Write("\n\n\t\tEnter Job Title : ");
//               string? JobTitle = Console.ReadLine()!;

//               _EmployeesList(null, null, JobTitle);

//               break;
//             }

//           case Enumerations.EnChoicesSearchEmployees._kSEARCH_BY_STATUS:
//             {

//               Console.Write($"\n\t\t{"Enter Status(Active:1 , Inactive:0 , Suspended:2)",-16}: ");

//               byte status = 0;
//               while (!byte.TryParse(Console.ReadLine(), out status) || status > 2)
//                 System.Console.Write("\t\tInvalid!! Status Employee");


//               _EmployeesList(null, null, null, _GetStatusEmployee((Enumerations.EnStatus)status));

//               break;
//             }

//           case Enumerations.EnChoicesSearchEmployees._kBACK_MAIN_MENU_EMPLOYEES:
//             {
//               StartupEmployeesModule();
//               break;
//             }
//         }

//         System.Console.WriteLine("\n\n\t\tPress any key to continue...");
//         Console.ReadKey();
//       }

//     }

//     private static void _DepartmentSammary()
//     {
//       Console.Clear();

//       Console.WriteLine("\n\n\t\t╔══════════════════════════════════════════╗");
//       Console.WriteLine("\t\t║         📊 DEPARTMENT SUMMARY            ║");
//       Console.WriteLine("\t\t╚══════════════════════════════════════════╝");

//       System.Console.WriteLine($"\n\n\t\t{"Department",-25} {"Employees",-15} {"Avg Salary",-20}");
//       System.Console.WriteLine("\t\t" + new string('-', 55));

//       DataTable DT_DepartmentSummary = EmployeesBL.GetDepartmentSammary();
//       int CountEmployees = 0;

//       foreach (DataRow DR in DT_DepartmentSummary.Rows)
//       {

//         CountEmployees += Convert.ToInt32(DR["TotalEmployees"]);

//         System.Console.WriteLine($"\t\t{DR["DepartmentName"].ToString(),-25} {Convert.ToInt32(DR["TotalEmployees"]).ToString(),-15} {(Convert.ToDouble(DR["Avg Salary"])).ToString("C2"),-20}");


//       }

//       System.Console.WriteLine("\t\t" + new string('-', 55));
//       System.Console.WriteLine("\n\n");


//       System.Console.WriteLine($"\t\tTotal Employees: {CountEmployees}\n\n");



//     }

//     private static void _SalarySummary()
//     { 
      
//       Console.Clear();
//       Console.WriteLine("\n\n\t\t╔══════════════════════════════════════════╗");
//       Console.WriteLine("\t\t║            💰 SALARY SUMMARY             ║");
//       Console.WriteLine("\t\t╚══════════════════════════════════════════╝\n\n");

//       DataTable DT_SalarySummary = EmployeesBL.GetSalarySummary();

//       if (DT_SalarySummary.Rows.Count > 0)
//       {
//         DataRow DR_SalarySummary = DT_SalarySummary.Rows[0];

//         System.Console.WriteLine($"\t\tMinimum Salary : {Convert.ToDouble(DR_SalarySummary["MinimumSalary"]).ToString("C2")}");
//         System.Console.WriteLine($"\t\tMaximum Salary : {Convert.ToDouble(DR_SalarySummary["MaximumSalary"]).ToString("C2")}");
//         System.Console.WriteLine($"\t\tAverage Salary : {Convert.ToDouble(DR_SalarySummary["AverageSalary"]).ToString("C2")}");
//         System.Console.WriteLine($"\t\tTotal Salary   : {Convert.ToDouble(DR_SalarySummary["TotalSalary"]).ToString("C2")}");
//       }
//       else
//       {
//         Console.WriteLine("\n\n\t\t╔══════════════════════════════════════════╗");
//         Console.WriteLine("\t\t║             ❌ NO SALARY DATA            ║");
//         Console.WriteLine("\t\t╠══════════════════════════════════════════╣");
//         Console.WriteLine("\t\t║ No salary data is available.             ║");
//         Console.WriteLine("\t\t╚══════════════════════════════════════════╝");
//       }
//     }

//     private static void _EmployeeStatus()
//     {

//       Console.Clear();

//       Console.WriteLine("\n\n\t\t╔══════════════════════════════════════════╗");
//       Console.WriteLine("\t\t║          👥 EMPLOYEE STATUS             ║");
//       Console.WriteLine("\t\t╚══════════════════════════════════════════╝\n\n");


//       Dictionary<string, int> AllEmployeeStatus = EmployeesBL.GetEmployeeStatus();

//       System.Console.WriteLine($"\t\t{"Status",-15} {"Count",-15}");
//       System.Console.WriteLine($"\t\t{new string('-', 25)}");



//       foreach (var item in AllEmployeeStatus)
//       {
//         Console.WriteLine($"\t\t{item.Key,-15} {item.Value,-15}");
//       }

//       System.Console.WriteLine($"\t\t{new string('-', 25)}");
//     }

//     private static void _HiringSummary()
//     {
//       Console.Clear();

//       Console.WriteLine("\n\n\t\t╔══════════════════════════════════════════╗");
//       Console.WriteLine("\t\t║            📅 HIRING SUMMARY             ║");
//       Console.WriteLine("\t\t╚══════════════════════════════════════════╝");

//       Dictionary<string?, int?> AllEmployessHired = EmployeesBL.GetHiringSummary();

//       System.Console.WriteLine($"\n\n\t\t{"Year",-15} {"Employees Hired",-15}");
//       System.Console.WriteLine($"\t\t{new string('-', 33)}");

//       foreach (var item in AllEmployessHired)
//         System.Console.WriteLine($"\t\t{item.Key ?? " ",-15} {item.Value ?? 0,-15}");
   
//       System.Console.WriteLine($"\t\t{new string('-', 33)}");

//     }
    
//     private static void _EmployeesReport()
//     {


//       while (true)
//       {
//         Console.Clear();

//         Console.WriteLine("\n\n\t\t╔══════════════════════════════════════════╗");
//         Console.WriteLine("\t\t║             📊 EMPLOYEE REPORT           ║");
//         Console.WriteLine("\t\t╠══════════════════════════════════════════╣");
//         Console.WriteLine("\t\t║                                          ║");
//         Console.WriteLine("\t\t║ 1. Department Summary                    ║");
//         Console.WriteLine("\t\t║ 2. Salary Summary                        ║");
//         Console.WriteLine("\t\t║ 3. Employee Status Summary               ║");
//         Console.WriteLine("\t\t║ 4. Hiring Summary                        ║");
//         Console.WriteLine("\t\t║                                          ║");
//         Console.WriteLine("\t\t║ 0. 🔙 Back                               ║");
//         Console.WriteLine("\t\t╚══════════════════════════════════════════╝");

//         Console.Write("\n\n\t\tSelect: ");
//         byte Choice = 0;


//         while (!byte.TryParse(Console.ReadLine(), out Choice) || (Choice > 4))
//           System.Console.Write("\t\tInvalid Choice : ");

//         switch ((Enumerations.EnChoicesEmployeesReport)Choice)
//         {
//           case Enumerations.EnChoicesEmployeesReport._kDEPARTMENT_SUMMARY:
//             {
//               _DepartmentSammary();
//               break;
//             }

//           case Enumerations.EnChoicesEmployeesReport._kSALARY_SUMMARY:
//             {
//               _SalarySummary();
//               break;
//             }

//           case Enumerations.EnChoicesEmployeesReport._kBACK:
//             {
//               StartupEmployeesModule();
//               break;
//             }

//           case Enumerations.EnChoicesEmployeesReport._kEMPLOYEE_STATUS_SUMMARY:
//             {
//               _EmployeeStatus();
//               break;
//             }

//           case Enumerations.EnChoicesEmployeesReport._kHIRING_SUMMARY:
//             {
//               _HiringSummary();
//               break;
//             }
//         }

//         System.Console.WriteLine("\n\n\t\tPress any key to continue...");
//         Console.ReadKey();
//       }


//     }

//     public static void StartupEmployeesModule()
//     {

//       while (true)
//       {

//         Console.Clear();
//         PrintScreenMenuEmployeesModule(out byte ChoiseEmployeesModule);

//         switch ((Enumerations.EnCategoriesEmployees)ChoiseEmployeesModule)
//         {

//           case Enumerations.EnCategoriesEmployees._kLIST_EMPLOYEES:
//             _EmployeesList();
//             break;

//           case Enumerations.EnCategoriesEmployees._kGET_EMPLOYEES_BY_ID:
//             {
//               Console.Clear();

//               Console.WriteLine($"\t\t╔══════════════════════════════════════════╗");
//               Console.WriteLine($"\t\t║          🔎 GET EMPLOYEE BY ID           ║");
//               Console.WriteLine($"\t\t╚══════════════════════════════════════════╝");
//               Console.WriteLine();
//               Console.Write($"\n\n\t\tEnter Employee ID: ");
//               int.TryParse(Console.ReadLine(), out int EmployeeID);
//               Console.WriteLine("\n\t\t╚══════════════════════════════════════════╝\n\n");
//               _GetEmployeeBy(EmployeeID);
//               break;

//             }

//           case Enumerations.EnCategoriesEmployees._kADD_EMPLOYEE:
//             _AddNewEmployee();
//             break;

//           case Enumerations.EnCategoriesEmployees._kUPDATE_INFORMATION_EMPLOYEE:
//             {
//               _UpdateEmployee();
//               break;
//             }

//           case Enumerations.EnCategoriesEmployees._kDELETE_EMPLOYEE:
//             {
//               _DeleteEmployee();
//               break;
//             }

//           case Enumerations.EnCategoriesEmployees._kSEARCH_EMPLOYEES:
//             {
//               _SearchEmployee();
//               break;
//             }

//           case Enumerations.EnCategoriesEmployees._kEMPLOYEE_REPORT:
//             {
//               _EmployeesReport();
//               break;
//             }
//         }

//         System.Console.WriteLine("\n\n\t\tPress any key to continue...");
//         Console.ReadKey();

//       }
//     }


//   }

// }

==================================================
FILE: ./NovaBusinessSystemPL/NovaBusinessSystemPL.csproj
==================================================
﻿<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net10.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <ProjectReference Include="../NovaBusinessSystem.BL/NovaBusinessSystemBL.csproj" />
    <ProjectReference Include="../NovaBusinessSystem.DTOs/NovaBusinessSystemDTOs.csproj" />
  </ItemGroup>

</Project>


==================================================
FILE: ./NovaBusinessSystemPL/Program.cs
==================================================
﻿using NovaBusinessSystem.Modules.Products;
using NovaBusinessSystemPL.Modules.Customers;

namespace NovaBusinessSystem

{

    public class Program
    {

        private static async Task Main(string[] args)
        {
                

             //EmployeesPL.EmployeesPL.StartupEmployeesModule();
            //await CustomersPL.StartUpCustomersModule();
           await  ProductsMenu.StartupProductsSection();
        }

    }
}

==================================================
FILE: ./README.md
==================================================
# 💼 Nova Business System

> A training project built with **C# and .NET** to develop a simple business management system and apply programming concepts in practice.

## 🎯 About the Project

The project focuses on backend development, database management using **SQL Server** and **T-SQL**, and building **RESTful APIs** with **ASP.NET Core**.

## 🚀 Future Improvements

The project is designed to evolve over time, with opportunities to improve existing features and add new functionality.


## ⚡ Tech Stack

<p align="center">

<img src="https://img.shields.io/badge/C%23%2014-512BD4?style=for-the-badge&logo=csharp&logoColor=white"/>
<img src="https://img.shields.io/badge/.NET%2010-512BD4?style=for-the-badge&logo=dotnet&logoColor=white"/>
<img src="https://img.shields.io/badge/ASP.NET%20Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white"/>

<img src="https://img.shields.io/badge/RESTful%20API-0EA5E9?style=for-the-badge"/>
<img src="https://img.shields.io/badge/Swagger-85EA2D?style=for-the-badge&logo=swagger&logoColor=black"/>
<img src="https://img.shields.io/badge/Postman-FF6C37?style=for-the-badge&logo=postman&logoColor=white"/>

<img src="https://img.shields.io/badge/ADO.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white"/>
<img src="https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white"/>
<img src="https://img.shields.io/badge/T--SQL-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white"/>

<img src="https://img.shields.io/badge/OOP-7C3AED?style=for-the-badge"/>
<img src="https://img.shields.io/badge/Layered%20Architecture-334155?style=for-the-badge"/>

<img src="https://img.shields.io/badge/Visual%20Studio%20Code-007ACC?style=for-the-badge&logo=visualstudiocode&logoColor=white"/>

</p>
