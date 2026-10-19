# NovaBusinessSystem — Frontend API Handoff

> Generated from the local source tree. Verify every route against the actual running API.
> No endpoint, response, or business rule should be invented.

## 1. Workspace

- Root: `/home/ahmedjehad/Projects Dot Net/DotNet-Development/Training-TSQL-Practice/NovaBusinessSystem/CSharp/NovaBusinessSystem`
- C# source files found: 69
- .NET project/solution files found: 5

## 2. Project structure

- `NovaBusinessSystem.API/Controllers/ CustomerPurchasesController.cs`
- `NovaBusinessSystem.API/Controllers/CustomerReportsController.cs`
- `NovaBusinessSystem.API/Controllers/CustomersController.cs`
- `NovaBusinessSystem.API/Controllers/InventoryController.cs`
- `NovaBusinessSystem.API/Controllers/LoyaltyController.cs`
- `NovaBusinessSystem.API/Controllers/ProductsController.cs`
- `NovaBusinessSystem.API/Controllers/SalesController.cs`
- `NovaBusinessSystem.API/NovaBusinessSystem.API.csproj`
- `NovaBusinessSystem.API/Program.cs`
- `NovaBusinessSystem.API/Properties/launchSettings.json`
- `NovaBusinessSystem.API/appsettings.Development.json`
- `NovaBusinessSystem.API/appsettings.json`
- `NovaBusinessSystem.BL/Customers BL/CustomersBL.cs`
- `NovaBusinessSystem.BL/Customers BL/Loyalty/LoyaltyBL.cs`
- `NovaBusinessSystem.BL/Customers BL/Purchase/PurchasesBL.cs`
- `NovaBusinessSystem.BL/Customers BL/Report/ReportBL.cs`
- `NovaBusinessSystem.BL/Departments BL/DepartmentsBL.cs`
- `NovaBusinessSystem.BL/Employees BL/EmployeesBL.cs`
- `NovaBusinessSystem.BL/Enumerations/Enumerations.cs`
- `NovaBusinessSystem.BL/NovaBusinessSystemBL.csproj`
- `NovaBusinessSystem.BL/Products BL/Inventory/InventoryManagement.cs`
- `NovaBusinessSystem.BL/Products BL/Product BL/ProductBL.cs`
- `NovaBusinessSystem.BL/Products BL/Sales/SalesBL.cs`
- `NovaBusinessSystem.DAL/Customers DAL/CustomersDAL.cs`
- `NovaBusinessSystem.DAL/Customers DAL/Loyalty/LoyaltyDAL.cs`
- `NovaBusinessSystem.DAL/Customers DAL/Purchases/PurchasesDAL.cs`
- `NovaBusinessSystem.DAL/Customers DAL/Report/ReportDAL.cs`
- `NovaBusinessSystem.DAL/DataAccessLayer.csproj`
- `NovaBusinessSystem.DAL/Departments DAL/DepartmentDAL.cs`
- `NovaBusinessSystem.DAL/Employees DAL/EmployeesDAL.cs`
- `NovaBusinessSystem.DAL/Helpers/HelperDAL.cs`
- `NovaBusinessSystem.DAL/Products DAL/ Sales/SalesDAL.cs`
- `NovaBusinessSystem.DAL/Products DAL/Inventory Management/InventoryDAL.cs`
- `NovaBusinessSystem.DAL/Products DAL/ProductsDAL.cs`
- `NovaBusinessSystem.DTOs/Customer DTOs/CustomerAddDTO.cs`
- `NovaBusinessSystem.DTOs/Customer DTOs/CustomerDTO.cs`
- `NovaBusinessSystem.DTOs/Customer DTOs/CustomerPointsDTO.cs`
- `NovaBusinessSystem.DTOs/Customer DTOs/Report DTOs/CustomerStatusDTO.cs`
- `NovaBusinessSystem.DTOs/Customer DTOs/Report DTOs/CustomersByCityDTO.cs`
- `NovaBusinessSystem.DTOs/Customer DTOs/Report DTOs/LoyaltySummaryDTO.cs`
- `NovaBusinessSystem.DTOs/Customer DTOs/Report DTOs/RegistrationSummaryDTO.cs`
- `NovaBusinessSystem.DTOs/Customer Purchases DTOs/CustomerPurchaseDTO.cs`
- `NovaBusinessSystem.DTOs/Customer Purchases DTOs/CustomerRankingDTO.cs`
- `NovaBusinessSystem.DTOs/Customer Purchases DTOs/CustomerSpendingSummaryDTO.cs`
- `NovaBusinessSystem.DTOs/Customer Purchases DTOs/FavoriteProductDTO.cs`
- `NovaBusinessSystem.DTOs/Customer Purchases DTOs/MonthlyPurchaseDTO.cs`
- `NovaBusinessSystem.DTOs/Loyalty DTOs/LoyaltyStatisticsDTO.cs`
- `NovaBusinessSystem.DTOs/Loyalty DTOs/PointsTransactionResultDTO.cs`
- `NovaBusinessSystem.DTOs/Loyalty DTOs/TopLoyaltyCustomerDTO.cs`
- `NovaBusinessSystem.DTOs/NovaBusinessSystemDTOs.csproj`
- `NovaBusinessSystem.DTOs/Prodcuts DTOs/Inventory Management DTOs/AddStockResultDTO.cs`
- `NovaBusinessSystem.DTOs/Prodcuts DTOs/Inventory Management DTOs/AdjustStockResultDTO.cs`
- `NovaBusinessSystem.DTOs/Prodcuts DTOs/Inventory Management DTOs/InventoryValueDTO.cs`
- `NovaBusinessSystem.DTOs/Prodcuts DTOs/Inventory Management DTOs/LowStockProductDTO.cs`
- `NovaBusinessSystem.DTOs/Prodcuts DTOs/Inventory Management DTOs/OutOfStockProductDTO.cs`
- `NovaBusinessSystem.DTOs/Prodcuts DTOs/Inventory Management DTOs/ProductStockDTO.cs`
- `NovaBusinessSystem.DTOs/Prodcuts DTOs/Inventory Management DTOs/RemoveStockResultDTO.cs`
- `NovaBusinessSystem.DTOs/Prodcuts DTOs/Product DTOs/ProductDTO.cs`
- `NovaBusinessSystem.DTOs/Prodcuts DTOs/Product DTOs/ProductRequestDTO.cs`
- `NovaBusinessSystem.DTOs/Prodcuts DTOs/Product DTOs/ProductUpdateDTO.cs`
- `NovaBusinessSystem.DTOs/Prodcuts DTOs/Product Sales Analysis DTOs/ProductSalesHistoryDTO.cs`
- `NovaBusinessSystemPL/Helpers/ConsoleHelper.cs`
- `NovaBusinessSystemPL/Helpers/InputHelper.cs`
- `NovaBusinessSystemPL/Moduls/Customers Module/CustomersPL.cs`
- `NovaBusinessSystemPL/Moduls/Customers Module/Loyalty/LoyaltyMenu.cs`
- `NovaBusinessSystemPL/Moduls/Customers Module/Loyalty/LoyaltyOperations.cs`
- `NovaBusinessSystemPL/Moduls/Customers Module/Purchases/PurchasesMenu.cs`
- `NovaBusinessSystemPL/Moduls/Customers Module/Purchases/PurchasesOperations.cs`
- `NovaBusinessSystemPL/Moduls/Customers Module/Report/ReportMenu.cs`
- `NovaBusinessSystemPL/Moduls/Customers Module/Report/ReportOperations.cs`
- `NovaBusinessSystemPL/Moduls/Employees Module/Employees.cs`
- `NovaBusinessSystemPL/Moduls/Products Module/Inventory Management/InventoryManagementMenu.cs`
- `NovaBusinessSystemPL/Moduls/Products Module/Inventory Management/InventoryManagementOperations.cs`
- `NovaBusinessSystemPL/Moduls/Products Module/Products/ProductsMenu.cs`
- `NovaBusinessSystemPL/Moduls/Products Module/Products/ProductsOperations.cs`
- `NovaBusinessSystemPL/NovaBusinessSystemPL.csproj`
- `NovaBusinessSystemPL/Program.cs`
- `README.md`

## 3. Route and HTTP attribute scan

This is a source-code scan, not proof that a route is reachable at runtime.
Check controller-level `[Route]`, `[ApiController]`, conventions, and configuration.

### `NovaBusinessSystem.API/Controllers/ CustomerPurchasesController.cs`

- Line 9: `[Route("api/CustomersPurchases")]`
- Line 13: `[HttpGet("{id:int}", Name = "GetCustomerPurchaseHistory")]`
- Line 48: `[HttpGet("{id:int}/SpendingSummary", Name = "GetCustomerSpending")]`
- Line 84: `[HttpGet("{id:int}/FavoriteProducts", Name = "GetCustomerFavoriteProducts")]`
- Line 120: `[HttpGet("MonthlyPurchases", Name = "GetCustomerMonthlyPurchases")]`
- Line 146: `[HttpGet("CustomersRanking", Name = "GetCustomersRankingAsync")]`

### `NovaBusinessSystem.API/Controllers/CustomerReportsController.cs`

- Line 9: `[Route("api/CustomersReport")]`
- Line 12: `[HttpGet("Status", Name = "GetCustomerStatusSummary")]`
- Line 41: `[HttpGet("City", Name = "GetCustomersByCity")]`
- Line 68: `[HttpGet("Loyalty", Name = "GetLoyaltySummaryReport")]`
- Line 94: `[HttpGet("Registration", Name = "GetRegistrationSummary")]`

### `NovaBusinessSystem.API/Controllers/CustomersController.cs`

- Line 10: `[Route("api/Customers")]`
- Line 13: `[HttpGet("", Name = "GetAllCustomers")]`
- Line 28: `[HttpGet("{id:int}", Name = "GetCustomerByID")]`
- Line 58: `[HttpPost("")]`
- Line 104: `[HttpPut("{id:int}")]`
- Line 157: `[HttpDelete("{id:int}")]`

### `NovaBusinessSystem.API/Controllers/InventoryController.cs`

- Line 8: `[Route("api/Products/Inventory")]`
- Line 12: `[HttpGet("{id:int}")]`
- Line 43: `[HttpPatch("{id:int}/Add")]`
- Line 83: `[HttpPatch("{id:int}/Remove")]`
- Line 122: `[HttpPatch("{id:int}/Adjust")]`
- Line 161: `[HttpGet("LowStock")]`
- Line 188: `[HttpGet("OutStock")]`
- Line 208: `[HttpGet("Values")]`

### `NovaBusinessSystem.API/Controllers/LoyaltyController.cs`

- Line 9: `[Route("api/CustomersLoyalty")]`
- Line 13: `[HttpGet("{id:int}")]`
- Line 42: `[HttpPatch("{id:int}/{points:int}/AddPoints")]`
- Line 84: `[HttpPatch("{id:int}/{points:int}/RedeemPoints")]`
- Line 128: `[HttpGet("TopCustomers")]`
- Line 155: `[HttpGet("Statistics")]`

### `NovaBusinessSystem.API/Controllers/ProductsController.cs`

- Line 8: `[Route("api/Products")]`
- Line 12: `[HttpGet("", Name = "GetAllProductsAsync")]`
- Line 35: `[HttpGet("{id:int}", Name = "GetProductByID")]`
- Line 71: `[HttpPost]`
- Line 122: `[HttpPut("{id:int}")]`
- Line 173: `[HttpDelete("{id:int}")]`

### `NovaBusinessSystem.API/Controllers/SalesController.cs`

- Line 9: `[Route("api/Sales")]`
- Line 13: `[HttpGet("{id:int}")]`


## 4. .NET project and solution files

### `NovaBusinessSystem.API/NovaBusinessSystem.API.csproj`

```xml
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
  </ItemGroup>

</Project>
```

### `NovaBusinessSystem.BL/NovaBusinessSystemBL.csproj`

```xml
﻿<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net10.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <ProjectReference Include="../NovaBusinessSystem.DAL/DataAccessLayer.csproj" />
    <ProjectReference Include="../NovaBusinessSystem.DTOs/NovaBusinessSystemDTOs.csproj" />
  </ItemGroup>
</Project>
```

### `NovaBusinessSystem.DAL/DataAccessLayer.csproj`

```xml
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
    <ProjectReference Include="../NovaBusinessSystem.DTOs/NovaBusinessSystemDTOs.csproj" />
  </ItemGroup>

</Project>
```

### `NovaBusinessSystem.DTOs/NovaBusinessSystemDTOs.csproj`

```xml
﻿<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net10.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

</Project>
```

### `NovaBusinessSystemPL/NovaBusinessSystemPL.csproj`

```xml
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
```

## 5. C# source code

Source files are included below for inspection of routes, DTOs,
validation, authorization, response shapes, and business behavior.

### `NovaBusinessSystem.API/Controllers/ CustomerPurchasesController.cs`

```cs
using Microsoft.AspNetCore.Mvc;
using NovaBusinessSystem.BL.Customers.Purchases;
using NovaBusinessSystem.BL.Customers;
using NovaBusinessSystem.DTOs;

namespace NovaBusinessSystem.API
{
    [ApiController]
    [Route("api/CustomersPurchases")]
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

                List<CustomerPurchaseDTO> L_customerPurchases = (await PurchasesBL.GetPurchaseHistoryAsync(id)).ToList();

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

                CustomerSpendingSummaryDTO customerSpendingSummary = await PurchasesBL.GetCustomerSpendingAsync(id)!;

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
                (await PurchasesBL.GetCustomerFavoriteProductsAsync(id)!).ToList();

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
                List<MonthlyPurchaseDTO> monthlyPurchases = (await PurchasesBL.GetCustomerMonthlyPurchasesAsync()!).ToList();

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
                List<CustomerRankingDTO> customerRankings = (await PurchasesBL.GetCustomersRankingAsync()!).ToList();

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
```

### `NovaBusinessSystem.API/Controllers/CustomerReportsController.cs`

```cs
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
```

### `NovaBusinessSystem.API/Controllers/CustomersController.cs`

```cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using NovaBusinessSystem.BL.Customers;

using NovaBusinessSystem.DTOs;

namespace NovaBusinessSystem.API
{
    [ApiController]
    [Route("api/Customers")]
    public class CustomersController : ControllerBase
    {
        [HttpGet("", Name = "GetAllCustomers")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<CustomerDTO>> GetAllCustomers()
        {
            List<CustomerDTO> allCustomers =
                CustomersBL.GetCustomersList().ToList();

            if (allCustomers is null || !allCustomers.Any())
                return BadRequest("Not have any data");

            return Ok(allCustomers);
        }

        [HttpGet("{id:int}", Name = "GetCustomerByID")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<CustomerDTO> GetCustomerByID([FromRoute(Name = "id")] int id)
        {

            try
            {
                if (id <= 0)
                    return BadRequest("Invalid Data");

                CustomersBL? customer = CustomersBL.Find(id);

                if (customer is null)
                    return NotFound("The Customer not found");

                return Ok(customer.CDTO);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }


        }


        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult AddNewCustomer([FromBody] CustomerAddDTO customer)
        {

            try
            {

                if (customer is null)
                    return BadRequest("The Customer is null ");

                if (
                    CustomersBL.CheckStringIsValid(customer.FirstName) ||
                    CustomersBL.CheckStringIsValid(customer.LastName) ||
                    CustomersBL.CheckStringIsValid(customer.Email) ||
                    CustomersBL.CheckStringIsValid(customer.Phone) ||
                    CustomersBL.CheckStringIsValid(customer.City) ||
                    CustomersBL.CheckStringIsValid(customer.Status)
                   )
                    return BadRequest("Invalid Data");

                if (!CustomersBL.IsStatusValid(customer.Status))
                    return BadRequest("Invalid Data Status");


                CustomersBL customersBL = new CustomersBL();

                customersBL.ConvertAddDTOtoObject(customer);


                if (!customersBL.SaveModeCustomer())
                    return BadRequest("Connot Be Added This Customer");


                return CreatedAtAction(nameof(GetCustomerByID), new { Id = customersBL.CustomerID }, customersBL.CDTO);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        public ActionResult UpdateCustomer([FromRoute(Name = "id")] int id, [FromBody] CustomerAddDTO customer)
        {

            try {

            if (customer is null)
                return BadRequest("The Customer is null ");
            if (id < 0)
                return BadRequest("Invalid Data 1");

            if (CustomersBL.IsEmailExists(customer.Email))
                return BadRequest("Invalid Data Email");

            if (
                !CustomersBL.CheckStringIsValid(customer.FirstName) ||
                !CustomersBL.CheckStringIsValid(customer.LastName) ||
                !CustomersBL.CheckStringIsValid(customer.Email) ||
                !CustomersBL.CheckStringIsValid(customer.City) ||
                !CustomersBL.CheckStringIsValid(customer.Status)
                )

                return BadRequest("Invalid Data 2 ");

            if (!CustomersBL.IsStatusValid(customer.Status))
                return BadRequest("Invalid Data Status ");

            CustomersBL customersBL = CustomersBL.Find(id)!;

            if (customersBL is null)
                return NotFound("The Customer not found");

            customersBL.ConvertAddDTOtoObject(customer);


            if (!customersBL.SaveModeCustomer())
                return BadRequest("Connot Be Updated This Customer");

            return NoContent();

            }catch(Exception ex)
            {
                return BadRequest($"{ex.Message}");

            }
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public ActionResult DeleteCustomer([FromRoute(Name = "id")] int id)
        {

            if (id <= 0)
                return BadRequest("Invalid Customer ID.");

            CustomersBL? customersBL = CustomersBL.Find(id);

            if (customersBL is null)
                return NotFound("The Customer was not found.");
            try
            {
                if (!customersBL.DeleteCustomer())
                    return NotFound($"Customer with ID {id} was not found.");

                return NoContent();
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                return Conflict(
                    "This customer cannot be deleted because they have related sales."
                );
            }
            catch (SqlException)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "A database error occurred."
                );
            }

        }

    }
}
```

### `NovaBusinessSystem.API/Controllers/InventoryController.cs`

```cs
using Microsoft.AspNetCore.Mvc;
using NovaBusinessSystem.DTOs.Products.Inventory;
using NovaBusinessSystem.BL.Products.Inventory;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace NovaBusinessSystem.API.Controllers.Products.Inventory
{
    [Route("api/Products/Inventory")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<ProductStockDTO>> ViewProductStockAsync(
                    [FromRoute(Name = "id")] int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Invalid product ID.");

                ProductStockDTO? productStock =
                    await InventoryManagement.ViewProductStockAsync(id);

                if (productStock is null)
                    return NotFound($"Product with ID {id} was not found.");

                return Ok(productStock);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    ex.Message
                );
            }
        }

        [HttpPatch("{id:int}/Add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<AddStockResultDTO>> AddStockAsync(
             [FromRoute(Name = "id")] int id,
             [FromQuery] int quantity)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Invalid product ID.");

                if (quantity <= 0)
                    return BadRequest(
                        "Quantity must be greater than zero.");

                AddStockResultDTO? result =
                    await InventoryManagement.AddStockAsync(
                        id,
                        quantity
                    );

                if (result is null)
                    return NotFound(
                        $"Product with ID {id} was not found.");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    ex.Message
                );
            }
        }

        [HttpPatch("{id:int}/Remove")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<RemoveStockResultDTO>> RemoveStockAsync(
                [FromRoute(Name = "id")] int id,
                [FromQuery] int quantity)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Invalid product ID.");

                if (quantity <= 0)
                    return BadRequest(
                        "Quantity must be greater than zero.");

                RemoveStockResultDTO? result =
                    await InventoryManagement.RemoveStockAsync(
                        id,
                        quantity
                    );

                if (result is null)
                    return NotFound(
                        $"Product with ID {id} was not found.");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    ex.Message
                );
            }
        }

        [HttpPatch("{id:int}/Adjust")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<AdjustStockResultDTO>> AdjustStockAsync(
                    [FromRoute(Name = "id")] int id,
                    [FromQuery] int actualStock)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Invalid product ID.");

                if (actualStock < 0)
                    return BadRequest("Actual stock cannot be negative.");

                AdjustStockResultDTO? result =
                    await InventoryManagement.AdjustStockAsync(
                        id,
                        actualStock
                    );

                if (result is null)
                    return NotFound(
                        $"Product with ID {id} was not found."
                    );

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    ex.Message
                );
            }
        }

        [HttpGet("LowStock")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<LowStockProductDTO>>> GetLowStockProducts(
            [FromQuery] int threshold
        )
        {
            try
            {
                if (threshold < 0)
                    return BadRequest("Threshold cannot be negative.");

                List<LowStockProductDTO> lowStockProducts = (await InventoryManagement.GetLowStockProducts(threshold)!).ToList();

                if (lowStockProducts is null)
                    return NotFound("Not found any Data");

                return Ok(lowStockProducts);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("OutStock")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<OutOfStockProductDTO>>> GetOutOfStockProducts()
        {
            try
            {
                List<OutOfStockProductDTO> outOfStockProducts = (await InventoryManagement.GetOutOfStockProducts()).ToList();

                return Ok(outOfStockProducts);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpGet("Values")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<InventoryValueDTO>> GetInventoryValueAsync()
        {
            try
            {
                InventoryValueDTO? inventoryValue = await InventoryManagement.GetInventoryValueAsync()!;

                if (inventoryValue is null)
                    return NotFound("Not found any Data");

                return Ok(inventoryValue);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }

}
```

### `NovaBusinessSystem.API/Controllers/LoyaltyController.cs`

```cs
using Microsoft.AspNetCore.Mvc;
using NovaBusinessSystem.BL.Customers;
using NovaBusinessSystem.BL.Customers.Loyalty;
using NovaBusinessSystem.DTOs;

namespace NovaBusinessSystem.API
{
    [ApiController]
    [Route("api/CustomersLoyalty")]
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

                CustomerPointsDTO? customerPointsDTO = await LoyaltyBL.ViewCustomerPointsAsync(id)!;

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

                if (!await LoyaltyBL.AddPointsToCustomerAsync(id , points))
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

                if (!await LoyaltyBL.RedeemPointsToCustomerAsync(id , customer.LoyaltyPoints , points))
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
                    (await LoyaltyBL.GetTopLoyaltyCustomersAsync()!).ToList();

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
                    await LoyaltyBL.GetLoyaltyStatisticsAsync()!;

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
```

### `NovaBusinessSystem.API/Controllers/ProductsController.cs`

```cs
using Microsoft.AspNetCore.Mvc;
using NovaBusinessSystem.DTOs.Products;
using NovaBusinessSystem.BL.Products;

namespace NovaBusinessSystem.API
{

    [Route("api/Products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet("", Name = "GetAllProductsAsync")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProductsAsync()
        {
            try
            {
                List<ProductDTO> L_Products = (await Product.GetAllProductsAsync()!).ToList();
                if (!L_Products.Any() || L_Products.Count == 0)
                    return NotFound("Not found any Products");

                return Ok(L_Products);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpGet("{id:int}", Name = "GetProductByID")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<ProductDTO>> GetProductByIDAsync(
              [FromRoute] int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Invalid product id");

                Product? product = await Product.GetProductByIDAsync(id);

                if (product is null)
                    return NotFound("Product not found");

                ProductDTO productDto = product.ProductDto;

                if (productDto is null)
                    return NotFound("Product not found");

                return Ok(productDto);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    ex.Message
                );
            }
        }

        [HttpPost]

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<ProductDTO>> AddNewProductAsync(
                [FromBody] ProductRequestDTO product)
        {
            try
            {
                if (product is null)
                    return BadRequest("Product data is required.");

                if (string.IsNullOrWhiteSpace(product.ProductName) ||
                    string.IsNullOrWhiteSpace(product.Category) ||
                    string.IsNullOrWhiteSpace(product.Status))
                {
                    return BadRequest("Invalid product data.");
                }

                if (product.Price <= 0 ||
                    product.StockQuantity < 0)
                {
                    return BadRequest("Invalid product data.");
                }

                Product productObj = new Product(
                    product,
                    Enumeration.Enumerations.EnMode._kADD
                );

                if (!await productObj.SaveMode())
                    return BadRequest("Something went wrong.");

                return CreatedAtRoute(
                    "GetProductByID",
                    new { id = productObj.ProductID },
                    productObj.ProductDto
                     );
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    ex.Message
                );
            }
        }


        [HttpPut("{id:int}")]

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<ProductDTO>> UpdateProductAsync(
        [FromRoute(Name = "id")] int id,
        [FromBody] ProductUpdateDTO productUpdateDto)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Invalid product id.");

                if (productUpdateDto is null)
                    return BadRequest("Product data is required.");

                if (string.IsNullOrWhiteSpace(productUpdateDto.ProductName) ||
                    string.IsNullOrWhiteSpace(productUpdateDto.Category) ||
                    string.IsNullOrWhiteSpace(productUpdateDto.Status))
                {
                    return BadRequest("Invalid product data.");
                }

                if (productUpdateDto.Price <= 0)
                    return BadRequest("Invalid product data.");


                Product productObj = await Product.GetProductByIDAsync(id)!;

                if (productObj is null)
                    return NotFound("Product data is required.");

                productObj.Update(productUpdateDto);

                if (!await productObj.SaveMode())
                    return BadRequest("Something went wrong.");

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    ex.Message
                );
            }
        }

        [HttpDelete("{id:int}")]

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<ProductDTO>> DeleteProductAsync(
                [FromRoute(Name = "id")] int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Invalid product id.");

                Product productObj = await Product.GetProductByIDAsync(id)!;

                if (productObj is null)
                    return NotFound("Product data is required.");

                if (!await productObj.DeleteProduct()!)
                    return BadRequest("Something went wrong.");

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    ex.Message
                );
            }
        }

        
    }
}
```

### `NovaBusinessSystem.API/Controllers/SalesController.cs`

```cs
using Microsoft.AspNetCore.Mvc;
using NovaBusinessSystem.BL.Products;
using NovaBusinessSystem.BL.Products.Sales;
using NovaBusinessSystem.DTOs.Products.Sales;

namespace NovaBusinessSystem.API
{
    [ApiController]
    [Route("api/Sales")]
    public class SalesController : ControllerBase
    {

        [HttpGet("{id:int}")]

        public async Task<ActionResult<IEnumerable<ProductSalesHistoryDTO>>> GetProductSalesHistoriesAsync(
            [FromRoute(Name = "id")] int id
        )

        {

            try
            {
                if (id <= 0)
                    return BadRequest("Invalid product id");

                Product product = await Product.GetProductByIDAsync(id);

                if (product is null)
                    return NotFound($"The Product id [{id}] does not exists");

                List<ProductSalesHistoryDTO> L_ProductSalesHistories = (await Sales.GetProductSalesHistoriesAsync(id)!).ToList();

                return Ok(L_ProductSalesHistories);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
```

### `NovaBusinessSystem.API/Program.cs`

```cs
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwaggerUI(options =>
        options.SwaggerEndpoint(
            "/openapi/v1.json",
            "Nova Business System"));
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
```

### `NovaBusinessSystem.BL/Customers BL/CustomersBL.cs`

```cs
using NovaBusinessSystem.DAL.Customers;
using NovaBusinessSystem.Enumeration;
using NovaBusinessSystem.DTOs;

namespace NovaBusinessSystem.BL.Customers
{
    public class CustomersBL
    {


        public int CustomerID { get; set; }
        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public DateTime RegistrationDate { get; set; }
        public int LoyaltyPoints { get; set; }
        public string Status { get; set; }
        public string FullName  =>  this.FirstName + " " + this.LastName;

        public CustomerDTO CDTO
        {
            get
            {
                return new CustomerDTO(
                this.CustomerID,
                this.FirstName,
                this.LastName,
                this.Email,
                this.Phone,
                this.City,
                this.RegistrationDate,
                this.LoyaltyPoints,
                this.Status
                );
            }
        }
        public CustomerAddDTO CAddDTO
        {
            get
            {
                return new CustomerAddDTO(
                this.FirstName,
                this.LastName,
                this.Email,
                this.Phone,
                this.City,
                this.Status
                );
            }
        }

        public Enumerations.EnMode enMode { get; set; }
            = Enumerations.EnMode._kADD;

        public CustomersBL()
        {
            this.CustomerID = -1;
            this.FirstName = "";
            this.LastName = "";
            this.Email = "";
            this.Phone = "";
            this.City = "";
            this.RegistrationDate = DateTime.Now;
            this.LoyaltyPoints = 0;
            this.Status = "";
            this.enMode = Enumerations.EnMode._kADD;

        }

        private CustomersBL(
           CustomerDTO customerDTO
            )
        {
            this.CustomerID = customerDTO.CustomerID;
            this.FirstName = customerDTO.FirstName;
            this.LastName = customerDTO.LastName;
            this.Email = customerDTO.Email;
            this.Phone = customerDTO.Phone;
            this.City = customerDTO.City;
            this.RegistrationDate = customerDTO.RegistrationDate;
            this.LoyaltyPoints = customerDTO.LoyaltyPoints;
            this.Status = customerDTO.Status;

            this.enMode = Enumerations.EnMode._kUPDATE;
        }

        private CustomerDTO ConvertToDTO()
        {
            return new CustomerDTO(

                this.CustomerID,
                this.FirstName,
                this.LastName,
                this.Email,
                this.Phone,
                this.City,
                this.RegistrationDate,
                this.LoyaltyPoints,
                this.Status

            );
        }

        private CustomerAddDTO ConvertCustomerAddToDTO()
        {
            return new CustomerAddDTO(

                this.FirstName,
                this.LastName,
                this.Email,
                this.Phone,
                this.City,
                this.Status

            );
        }

        public void ConvertDTOtoObject(CustomerDTO customer)
        {
            if (customer is not null)
            {
                this.FirstName = customer.FirstName;
                this.LastName = customer.LastName;
                this.Email = customer.Email;
                this.Phone = customer.Phone;
                this.City = customer.City;
                this.Status = customer.Status;
            }
        }

        public CustomersBL? ConvertAddDTOtoObject(CustomerAddDTO customer)
        {
            if (customer is not null)
            {
                this.FirstName = customer.FirstName;
                this.LastName = customer.LastName;
                this.Email = customer.Email;
                this.Phone = customer.Phone;
                this.City = customer.City;
                this.Status = customer.Status;
            }

            return null;
        }

        public static CustomersBL? Find(int id)
        {

            CustomerDTO? infoCustomer = CustomersDAL.FindCustomerBy(id);
            if (infoCustomer is not null)
                return new CustomersBL(infoCustomer);

            return null;
        }

        private bool _AddNewCustomer()
        {
            this.CustomerID = CustomersDAL.AddNewCustomer(ConvertCustomerAddToDTO());
            return this.CustomerID > 0;
        }

        private bool _UpdateCustomer()
        {
            return CustomersDAL.UpdateCustomer(this.CustomerID, this.CAddDTO) > 0;
        }

        public static IEnumerable<CustomerDTO> GetCustomersList() => CustomersDAL.GetAllCustomersList();

        public bool SaveModeCustomer()
        {
            switch (this.enMode)
            {
                case Enumerations.EnMode._kADD:
                    {
                        if (_AddNewCustomer())
                        {
                            this.enMode = Enumerations.EnMode._kUPDATE;
                            return true;
                        }
                        else return false;
                    }
                case Enumerations.EnMode._kUPDATE:
                    return _UpdateCustomer();

                default: return false;

            }
        }

        public static bool CheckStringIsValid(string text)
        {
            bool isFound = true;

            if (text == "")
                return false;

            if (!string.IsNullOrWhiteSpace(text))
                foreach (char character in text)
                {
                    if (char.IsDigit(character) || char.IsPunctuation(character) || Char.IsNumber(character) || char.IsSymbol(character) || char.IsWhiteSpace(character))
                    {
                        isFound = false;
                        break;
                    }

                }

            return isFound;
        }

        public static bool IsEmailExists(string Email) => CustomersDAL.IsTheEmailExists(Email);

        public static bool IsStatusValid(string Status)
        {
            if (Status == "Active" || Status == "Inactive" || Status == "Blocked")
                return true;

            return false;
        }

        public bool DeleteCustomer() => CustomersDAL.DeleteCustomer(this.CustomerID);

        
    }

}
```

### `NovaBusinessSystem.BL/Customers BL/Loyalty/LoyaltyBL.cs`

```cs
using NovaBusinessSystem.DAL;
using NovaBusinessSystem.DAL.Customers.Loyalty;
using NovaBusinessSystem.DTOs;

namespace NovaBusinessSystem.BL.Customers.Loyalty
{

    public class LoyaltyBL
    {
        public static async Task<CustomerPointsDTO>? ViewCustomerPointsAsync(int id)
         => await LoyaltyDAL.ViewCustomerPoints(id)!;

        public static async Task<bool> AddPointsToCustomerAsync(int id, int pointsToAdd)
        => await LoyaltyDAL.AddPointsToCustomer(id, pointsToAdd)!;

        public static async Task<bool> RedeemPointsToCustomerAsync(int id, int loyaltyPointsint, int pointsToRedeem)
        {
            if (pointsToRedeem > loyaltyPointsint)
                throw new Exception("INSUFFICIENT POINTS");

            return await LoyaltyDAL.RedeemPointsToCustomer(id, pointsToRedeem)!;
        }

        public static async Task<IEnumerable<TopLoyaltyCustomerDTO>>? GetTopLoyaltyCustomersAsync()
        => await LoyaltyDAL.GetTopLoyaltyCustomers()!;

        public static async Task<LoyaltyStatisticsDTO>? GetLoyaltyStatisticsAsync()
        => await LoyaltyDAL.GetLoyaltyStatistics()!;
    }
}
```

### `NovaBusinessSystem.BL/Customers BL/Purchase/PurchasesBL.cs`

```cs
using NovaBusinessSystem.DTOs;
using NovaBusinessSystem.DAL.Customers.Purchases;

namespace NovaBusinessSystem.BL.Customers.Purchases
{

    public class PurchasesBL
    {
        public static async Task<IEnumerable<CustomerPurchaseDTO>> GetPurchaseHistoryAsync(int customerID)
        {
            if (customerID <= 0)
                throw new Exception("Invalid Data");

            return await PurchasesDAL.GetPurchaseHistoryAsync(customerID);
        }

        public static async Task<CustomerSpendingSummaryDTO>? GetCustomerSpendingAsync(int customerID)
        {
            if (customerID <= 0)
                throw new Exception("Invalid Data");

            return await PurchasesDAL.GetCustomerSpendingAsync(customerID)!;
        }

        public static async Task<IEnumerable<FavoriteProductDTO>> GetCustomerFavoriteProductsAsync(int customerID)
        {
            if (customerID <= 0)
                throw new Exception("Invalid Data");

            return await PurchasesDAL.GetCustomerFavoriteProductsAsync(customerID)!;
        }

        public static async Task<IEnumerable<MonthlyPurchaseDTO>> GetCustomerMonthlyPurchasesAsync()
        {
            return await PurchasesDAL.GetCustomerMonthlyPurchasesAsync()!;
        }
        public static async Task<IEnumerable<CustomerRankingDTO>> GetCustomersRankingAsync()
        {
            return await PurchasesDAL.GetGetCustomersRankingAsync()!;
        }
    }
}
```

### `NovaBusinessSystem.BL/Customers BL/Report/ReportBL.cs`

```cs
using NovaBusinessSystem.DAL.Customers.Reports;
using NovaBusinessSystem.DTOs.Customers.Reports;

namespace NovaBusinessSystem.BL.Customers.Reports
{

    public class ReportBL
    {

        public static async Task<IEnumerable<CustomerStatusDTO>>? GetCustomerStatusSummaryAsync() => await ReportDAL.GetCustomerStatusSummaryAsync()!;
        public static async Task<IEnumerable<CustomersByCityDTO>>? GetCustomersByCityAsync() => await ReportDAL.GetCustomersByCityAsync()!;
        public static async Task<IEnumerable<LoyaltySummaryDTO>>? GetLoyaltySummaryReportAsync() => await ReportDAL.GetLoyaltySummaryReportAsync()!;
        public static async Task<IEnumerable<RegistrationSummaryDTO>>? GetRegistrationSummaryAsync() => await ReportDAL.GetRegistrationSummaryAsync()!;

    }
}
```

### `NovaBusinessSystem.BL/Departments BL/DepartmentsBL.cs`

```cs
using DataAccessLayer;
namespace NovaBusinessSystem.BL.Departments;

public class DepartmentsBL
{
    public DepartmentsBL()
    {
        this.DepartmentID = default;
        this.DepartmentName = default;
        this.Budget = default;
        this.Location = default;
    }

    public int DepartmentID { get; set; }
    public string DepartmentName { get; set; }
    public string Location { get; set; }
    public decimal Budget { get; set; }
    public DepartmentsBL(
         int DepartmentID,
         string DepartmentName,
         string Location,
         decimal Budget)
    {
        this.DepartmentID = DepartmentID;
        this.DepartmentName = DepartmentName;
        this.Budget = Budget;
        this.Location = Location;
    }

    public static DepartmentsBL GetDepartmentBy(int DepartmentID)
    {
        string DepartmentName = "", Location = "";
        decimal Budget = 0.0m;

        bool IsFound = DepartmentsDAL.GetDepartmentBy(DepartmentID, ref DepartmentName, ref Location, ref Budget);

        if (IsFound)
            return new DepartmentsBL(DepartmentID, DepartmentName, Location, Budget);
        else return null;


    }

}
```

### `NovaBusinessSystem.BL/Employees BL/EmployeesBL.cs`

```cs
﻿using System.Data;
using DataAccessLayer;
using NovaBusinessSystem.BL.Departments;
using NovaBusinessSystem.Enumeration;

namespace NovaBusinessSystem.BL;

public class EmployeesBL
{

    public int ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int DepartmentID { get; set; }
    public int ManagerID { get; set; }
    public string JobTitle { get; set; }
    public decimal Salary { get; set; }
    public DateTime HireDate { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public Enumerations.EnStatus Status { get; set; }

    private EmployeesBL ? _InfoManager = null;
    public EmployeesBL ManagerInfo
    {
        get
        {
            if (_InfoManager is null)
                _InfoManager = FindEmployeeBy(this.ManagerID);

            return _InfoManager;
        }

    }
    private DepartmentsBL _DepartmentInfo = null;
    public DepartmentsBL DepartmentInfo
    {

        get
        {
            if (_DepartmentInfo is null)
                _DepartmentInfo = DepartmentsBL.GetDepartmentBy(DepartmentID);

            return _DepartmentInfo;
        }
    }

    public Enumerations.EnMode enMode { get; set; }

    public EmployeesBL()
    {
        this.ID = default;
        this.FirstName = default;
        this.LastName = default;
        this.DepartmentID = default;
        this.ManagerID = default;
        this.JobTitle = default;
        this.Salary = default;
        this.HireDate = default;
        this.Salary = default;
        this.Phone = default;
        this.Email = default;
        this.Status = default;
        this.enMode = Enumerations.EnMode._kADD;

    }

    public EmployeesBL(
        int EmployeeID,
        string FirstName,
        string lastName,
        int DepartmentID,
        int ManagerID,
        string jobTitle,
        decimal salary,
        DateTime hireDate,
        string phone,
        string email,
        Enumerations.EnStatus status)
    {
        this.ID = EmployeeID;
        this.FirstName = FirstName;
        this.LastName = lastName;
        this.DepartmentID = DepartmentID;
        this.ManagerID = ManagerID;
        this.JobTitle = jobTitle;
        this.Salary = salary;
        this.HireDate = hireDate;
        this.Phone = phone;
        this.Email = email;
        this.Status = status;
        this.enMode = Enumerations.EnMode._kUPDATE;
    }

    public static DataTable GetAllEmployees(

        string? FullName = null,
        string? DepartmentName = null,
        string? JobTitle = null,
        string? Status = null

        )
            => EmployeesDAL.GetListEmployees(FullName, DepartmentName, JobTitle, Status);


    public static EmployeesBL FindEmployeeBy(int EmployeeID)
    {

        string FirstName = "", LastName = "", JobTitle = "", Phone = "", Email = "";
        decimal Salary = 0.0m;
        DateTime HireDate = DateTime.Now;
        byte Status = 0;
        int DepartmentID = 0, ManagerID = 0;

        bool IsFound = EmployeesDAL.GetEmployeeBy(
            EmployeeID,
            ref FirstName,
            ref LastName,
            ref DepartmentID,
            ref ManagerID,
            ref JobTitle,
            ref Salary,
            ref HireDate,
            ref Phone,
            ref Email,
            ref Status
           );

        if (IsFound)
            return new EmployeesBL(
            EmployeeID,
            FirstName,
            LastName,
            DepartmentID,
            ManagerID,
            JobTitle,
            Salary,
            HireDate,
            Phone,
            Email,
            (Enumerations.EnStatus)Status);

        else return null;


    }

    private bool _AddNewEmployee()
    {

        this.ID = EmployeesDAL.AddNewEmployee(this.FirstName, this.LastName, this.DepartmentID, this.ManagerID, this.JobTitle, this.Salary, this.Phone, this.Email);
        return this.ID > 0;
    }

    private bool _UpdateEmployee()
    {
        string Status = "";

        switch (this.Status)
        {
            case Enumerations.EnStatus._kACTIVE:
                Status = "Active";
                break;
            case Enumerations.EnStatus._kINACTIVE:
                Status = "Inactive";
                break;
            case Enumerations.EnStatus._kSUSPENDED:
                Status = "Suspended";
                break;

        }
        return EmployeesDAL.UpdateEmployee(this.ID, this.FirstName, this.LastName, this.DepartmentID, this.ManagerID, this.JobTitle, this.Salary, this.Phone, this.Email, Status);
    }

    public static bool DeleteEmployee(int EmployeeID) => EmployeesDAL.DeleteEmployee(EmployeeID);

    public bool SaveModeEmployees()
    {
        switch (this.enMode)
        {
            case Enumerations.EnMode._kADD:
                {
                    if (_AddNewEmployee())
                    {
                        this.enMode = Enumerations.EnMode._kUPDATE;
                        return true;
                    }
                    else return false;

                }

            case Enumerations.EnMode._kUPDATE:
                return _UpdateEmployee();

            default: return false;
        }
    }

    public static DataTable GetDepartmentSammary() => EmployeesDAL.GetDepartmentSammary();


    public static DataTable GetSalarySummary() => EmployeesDAL.GetSalarySummary();

    public static Dictionary<string,int> GetEmployeeStatus() => EmployeesDAL.GetEmployeeStatus();
     public static Dictionary<string?,int?>  GetHiringSummary() => EmployeesDAL.GetHiringSummary();
}
```

### `NovaBusinessSystem.BL/Enumerations/Enumerations.cs`

```cs
namespace NovaBusinessSystem.Enumeration
{

    public class Enumerations
    {
        public enum EnStatus : byte
        {
            _kACTIVE = 1,
            _kINACTIVE = 0,
            _kSUSPENDED = 2
        }

        public enum EnMode : byte
        {
            _kADD = 1,
            _kUPDATE = 2
        }

        public enum EnCategoriesEmployees : byte
        {

            _kBACK = 0,
            _kLIST_EMPLOYEES = 1,
            _kGET_EMPLOYEES_BY_ID = 2,
            _kADD_EMPLOYEE = 3,
            _kUPDATE_INFORMATION_EMPLOYEE = 4,
            _kDELETE_EMPLOYEE = 5,
            _kSEARCH_EMPLOYEES = 6,
            _kEMPLOYEE_REPORT = 7


        }

        public enum EnChoicesSearchEmployees : byte
        {
            _kBACK_MAIN_MENU_EMPLOYEES = 0,
            _kSEARCH_BY_FULL_NAME = 1,
            _kSEARCH_BY_DEPARTMENT_NAME = 2,
            _kSEARCH_BY_JOB_TITLE = 3,
            _kSEARCH_BY_STATUS = 4
        }

        public enum EnChoicesEmployeesReport : byte
        {
            _kBACK = 0,
            _kDEPARTMENT_SUMMARY = 1,
            _kSALARY_SUMMARY = 2,
            _kEMPLOYEE_STATUS_SUMMARY = 3,
            _kHIRING_SUMMARY = 4
        }

        public enum EnChoicesCustomersModule : byte
        {
            _kBACK_MAIN_MENU = 0,
            _kLIST_CUSTOMERS = 1,
            _kGET_CUSTOMER_BY_ID = 2,
            _kADD_NEW_CUSTOMER = 3,
            _kUPDATE_INFORMATION_CUSTOMER = 4,
            _kDELETE_CUSTOMER = 5,
            _kSEARCH_CUSTOMERS = 6,
            _kLOYALTY_POINTS = 7,
            _kCUSTOMER_PURCHASES = 8,
            _kCUSTOMER_REPORT = 9

        }

        public enum EnChoicesLoyaltyPoints : byte
        {
            _kBACK = 0,
            _kVIEW_CUSTOMER_POINTS = 1,
            _kADD_POINTS = 2,
            _kREDEEM_POINTS = 3,
            _kTOP_LOYALTY_CUSTOMERS = 4,
            _kLOYALTY_STATISTICS = 5
        }

        public enum EnChoicesCustomerPurchases : byte
        {
            _kBACK = 0,
            _kPURCHASE_HISTORY = 1,
            _kCUSTOMER_SPENDING_SUMMARY = 2,
            _kCUSTOMER_FAVORITE_PRODUCTS = 3,
            _kCUSTOMER_MONTHLY_PURCHASES = 4,
            _kCUSTOMER_RANKING = 5
        }

        public enum EnChoicesCustomerReport : byte
        {

            _kBACK = 0,
            _kCUSTOMER_STATUS_SUMMARY = 1,
            _kCUSTOMERS_BY_CITY = 2,
            _kLOYALTY_SUMMARY = 3,
            _kREGISTRATION_SUMMARY = 4,
            _kCUSTOMER_GROWTH = 5,
            _kCUSTOMER_ACTIVITY_REPORT = 6


        }

        public enum EnChoicesProductsModule : byte
        {
            _kBACK = 0,
            _kLIST_PRODUCTS = 1,
            _kGET_PRODUCT_BY_ID = 2,
            _kADD_PRODUCT = 3,
            _kUPDATE_PRODUCT = 4,
            _kDELETE_PRODUCT = 5,
            _kSEARCH_AND_FILTER_PRODUCTS = 6,
            _kINVENTORY_MANAGEMENT = 7,
            _kPRODUCT_SALES_ANALYSIS = 8,
            _kPRODUCT_REPORTS = 9
        }

        public enum EnChoicesInventoryManagement : byte
        {
            _kBACK = 0,
            _kVIEW_PRODUCT_STOCK = 1,
            _kADD_STOCK = 2,
            _kREMOVE_STOCK = 3,
            _kADJUST_STOCK = 4,
            _kLOW_STOCK_PRODUCTS = 5,
            _kOUT_OF_STOCK_PRODUCTS = 6,
            _kINVENTORY_VALUE = 7,
            _kSTOCK_STATISTICS = 8
        }
    }
}
```

### `NovaBusinessSystem.BL/Products BL/Inventory/InventoryManagement.cs`

```cs
using NovaBusinessSystem.DAL.Products.Inventory;
using NovaBusinessSystem.DTOs.Products.Inventory;

namespace NovaBusinessSystem.BL.Products.Inventory
{
    public class InventoryManagement
    {
        public static async Task<ProductStockDTO?> ViewProductStockAsync(int productID)
        {
            return await InventoryDAL.ViewProductStockAsync(productID);
        }

        public static async Task<AddStockResultDTO?> AddStockAsync(int productID, int stockToAdded)
        {
            if (productID <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(productID),
                    "Invalid Product ID."
                    );

            if (stockToAdded <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(stockToAdded),
                    "Stock to add must be greater than zero.");

            return await InventoryDAL.AddStockAsync(
                productID,
                stockToAdded
            );
        }

        public static async Task<RemoveStockResultDTO?> RemoveStockAsync(
             int productID,
             int stockToBeRemove)
        {
            if (productID <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(productID),
                    "Product ID must be greater than zero.");

            if (stockToBeRemove <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(stockToBeRemove),
                    "Stock to remove must be greater than zero.");

            return await InventoryDAL.RemoveStockAsync(
                productID,
                stockToBeRemove
            );
        }

        public static async Task<AdjustStockResultDTO?> AdjustStockAsync(
            int productID,
            int actualStock)
        {
            if (productID <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(productID),
                    "Product ID must be greater than zero.");

            if (actualStock < 0)
                throw new ArgumentOutOfRangeException(
                    nameof(actualStock),
                    "Actual stock cannot be negative.");

            return await InventoryDAL.AdjustStockAsync(
                productID,
                actualStock
            );
        }

        public static async Task<IEnumerable<LowStockProductDTO>> GetLowStockProducts(int threshold)
        {
            if (threshold < 0)
                throw new ArgumentOutOfRangeException(
                    nameof(threshold),
                    "Threshold cannot be negative.");

            return await InventoryDAL.GetLowStockProducts(
                threshold
                );
        }

        public static async Task<IEnumerable<OutOfStockProductDTO>> GetOutOfStockProducts()
        {
            return await InventoryDAL.GetOutOfStockProducts();
        }

        public static async Task <InventoryValueDTO?>  ? GetInventoryValueAsync () => await InventoryDAL.GetInventoryValueAsync()!;
    
    }
}
```

### `NovaBusinessSystem.BL/Products BL/Product BL/ProductBL.cs`

```cs
using NovaBusinessSystem.DAL.Products;
using NovaBusinessSystem.DTOs.Products;
using NovaBusinessSystem.Enumeration;

namespace NovaBusinessSystem.BL.Products
{
    public class Product
    {
        public int ProductID { get; private set; }
        public string ProductName { get; private set; }
        public string Category { get; private set; }
        public decimal Price { get; private set; }
        public int StockQuantity { get; private set; }
        public string Status { get; private set; }
        public ProductDTO ProductDto
        {
            get
            {
                return new ProductDTO(
                    this.ProductID,
                    this.ProductName,
                    this.Category,
                    this.Price,
                    this.StockQuantity,
                    this.Status
                    );
            }


        }

        public Enumerations.EnMode enMode { get; private set; }


        public Product(ProductDTO productDto, Enumerations.EnMode mode)
        {
            this.ProductID = productDto.ProductID;
            this.ProductName = productDto.ProductName;
            this.Category = productDto.Category;
            this.Price = productDto.Price;
            this.StockQuantity = productDto.StockQuantity;
            this.Status = productDto.Status;
            this.enMode = mode;

        }

        public Product(ProductRequestDTO productDto, Enumerations.EnMode mode)
        {

            this.ProductName = productDto.ProductName;
            this.Category = productDto.Category;
            this.Price = productDto.Price;
            this.StockQuantity = productDto.StockQuantity;
            this.Status = productDto.Status;
            this.enMode = mode;

        }

        public void Update(ProductUpdateDTO productDto)
        {

            this.ProductName = productDto.ProductName;
            this.Category = productDto.Category;
            this.Price = productDto.Price;
            this.Status = productDto.Status;
        }

        public Product()
        {
            this.ProductID = -1;
            this.ProductName = string.Empty;
            this.Category = string.Empty;
            this.Price = 0.0m;
            this.StockQuantity = -1;
            this.Status = string.Empty;

            this.enMode = Enumerations.EnMode._kADD;
        }


        public async static Task<IEnumerable<ProductDTO>>? GetAllProductsAsync() => await ProductsDAL.GetAllProductsAsync()!;

        public async static Task<Product> GetProductByIDAsync(int productID)
        {
            if (productID <= 0)
                throw new Exception("Invalid Data");

            ProductDTO productDto = await ProductsDAL.GetProductByIDAsync(productID)!;

            if (productDto is null)
                return null!;

            return new Product(
                productDto,
                Enumerations.EnMode._kUPDATE
                );

        }

        private async Task<bool>? _AddNewProduct()
        {
            this.ProductID = await ProductsDAL.AddNewProductAsync(this.ProductDto)!;
            return this.ProductID > 0;
        }
        private async Task<bool>? _UpdateProduct()
        {
            ProductUpdateDTO productUpdate = new ProductUpdateDTO(this.ProductName, this.Category, this.Price, this.Status);

            int rowAffective = await ProductsDAL.UpdateProductAsync(this.ProductID, productUpdate)!;
            return rowAffective > 0;
        }

        public async Task<bool>  SaveMode()
        {
            switch (this.enMode)
            {
                case Enumerations.EnMode._kADD:
                    {
                        if (await _AddNewProduct()!)
                        {
                            this.enMode = Enumerations.EnMode._kUPDATE;
                            return true;
                        }
                        return false;
                    }

                case Enumerations.EnMode._kUPDATE:
                    return await _UpdateProduct()!;

                default: return false;
            }
        }

        public async Task<bool> ? DeleteProduct ()
        => await ProductsDAL.DeleteProductAsync(this.ProductID)!;
    }
}
```

### `NovaBusinessSystem.BL/Products BL/Sales/SalesBL.cs`

```cs
using NovaBusinessSystem.DAL.Products.Sales;
using NovaBusinessSystem.DTOs.Products.Sales;

namespace NovaBusinessSystem.BL.Products.Sales
{

    public class Sales
    {

        public static async Task<IEnumerable<ProductSalesHistoryDTO>> GetProductSalesHistoriesAsync(int productID)
        {

            if (productID <= 0)
                throw new ArgumentOutOfRangeException($"The product id = {productID} out of range");

            return await SalesDAL.GetProductSalesHistoriesAsync(productID);
        }
    }
}
```

### `NovaBusinessSystem.DAL/Customers DAL/CustomersDAL.cs`

```cs
using System.Data;
using Microsoft.Data.SqlClient;
using NovaBusinessSystem.DTOs;

namespace NovaBusinessSystem.DAL.Customers
{

    public class CustomersDAL
    {

        public static IEnumerable<CustomerDTO> GetAllCustomersList()
        {
            List<CustomerDTO> L_AllCustomers = new List<CustomerDTO>();


            using (SqlConnection connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString))
            using (SqlCommand command = new SqlCommand("[dbo].usp_GetCustomers", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                        while (reader.Read())
                        {
                            L_AllCustomers.Add(
                                new CustomerDTO(
                                    reader.GetInt32(reader.GetOrdinal("CustomerID")),
                                    reader.GetString(reader.GetOrdinal("FirstName")),
                                    reader.GetString(reader.GetOrdinal("LastName")),
                                    reader.GetString(reader.GetOrdinal("Email")),
                                    reader.GetString(reader.GetOrdinal("Phone")),
                                    reader.GetString(reader.GetOrdinal("City")),
                                    reader.GetDateTime(reader.GetOrdinal("RegistrationDate")),
                                    reader.GetInt32(reader.GetOrdinal("LoyaltyPoints")),
                                    reader.GetString(reader.GetOrdinal("Status"))

                                )

                            );
                        }


                }

                catch { throw; }
                ;
            }

            return L_AllCustomers;

        }
        
        public static CustomerDTO? FindCustomerBy(int CustomerID)
        {
            CustomerDTO? customerDTO = null;

            using (SqlConnection connection = new SqlConnection(
                HelperDAL.HelperDAL.ConnectionString))

            using (SqlCommand command = new SqlCommand(
                "dbo.usp_GetCustomerByID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parmID = command.Parameters.Add("@ID", SqlDbType.Int);
                parmID.Direction = ParameterDirection.Input;
                parmID.Value = CustomerID;

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            customerDTO = new CustomerDTO(
                            CustomerID,
                            (string)reader["FirstName"],
                            (string)reader["LastName"],
                            (string)reader["Email"],
                            (string)reader["Phone"],
                            (string)reader["City"],
                            (DateTime)reader["RegistrationDate"],
                            Convert.ToInt16(reader["LoyaltyPoints"]),
                            (string)reader["Status"]

                            );
                        }
                    }
                }
                catch
                {
                    throw;
                }
            }

            return customerDTO;
        }


        public static int AddNewCustomer(CustomerAddDTO customerDTO)
        {
            using (SqlConnection connection =
                   new SqlConnection(HelperDAL.HelperDAL.ConnectionString))
            using (SqlCommand command =
                   new SqlCommand("[dbo].usp_AddNewCustomer", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50)
                    .Value = customerDTO.FirstName;

                command.Parameters.Add("@LastName", SqlDbType.NVarChar, 50)
                    .Value = customerDTO.LastName;

                command.Parameters.Add("@Email", SqlDbType.NVarChar, 150)
                    .Value = customerDTO.Email;

                command.Parameters.Add("@Phone", SqlDbType.NVarChar, 11)
                    .Value = customerDTO.Phone.Trim();

                command.Parameters.Add("@City", SqlDbType.NVarChar, 100)
                    .Value = customerDTO.City;

                command.Parameters.Add("@Status", SqlDbType.NVarChar, 20)
                    .Value = customerDTO.Status;

                SqlParameter outputParaCustomerID =
                    new SqlParameter("@CustomerID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };

                command.Parameters.Add(outputParaCustomerID);

                try
                {
                    connection.Open();

                    command.ExecuteNonQuery();

                    return Convert.ToInt32(outputParaCustomerID.Value);
                }
                catch (SqlException)
                {
                    return -1;
                }
            }
        }

        public static bool IsTheEmailExists(string Email)
        {

            using (SqlConnection connection =
                   new SqlConnection(HelperDAL.HelperDAL.ConnectionString))
            using (SqlCommand command =
                   new SqlCommand("[dbo].usp_IsEmailExists", connection))
            {
                command.CommandType = CommandType.StoredProcedure;


                command.Parameters.Add("@Email", SqlDbType.NVarChar, 150)
                    .Value = Email;

                try
                {
                    connection.Open();
                    return Convert.ToInt32(command.ExecuteScalar()) > 0;
                }
                catch (SqlException)
                {
                    throw;
                }
            }
        }

        public static int UpdateCustomer(int customerID, CustomerAddDTO customerDTO)
        {

            using (SqlConnection connection =
                   new SqlConnection(HelperDAL.HelperDAL.ConnectionString))
            using (SqlCommand command =
                   new SqlCommand("[dbo].usp_UpdateCustomer", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50)
                    .Value = customerDTO.FirstName;

                command.Parameters.Add("@LastName", SqlDbType.NVarChar, 50)
                    .Value = customerDTO.LastName;

                command.Parameters.Add("@Email", SqlDbType.NVarChar, 150)
                    .Value = customerDTO.Email;

                command.Parameters.Add("@Phone", SqlDbType.NVarChar, 11)
                    .Value = customerDTO.Phone;

                command.Parameters.Add("@City", SqlDbType.NVarChar, 100)
                    .Value = customerDTO.City;

                command.Parameters.Add("@Status", SqlDbType.NVarChar, 20)
                    .Value = customerDTO.Status;

                command.Parameters.Add("@CustomerID", SqlDbType.Int).Value = customerID;


                try
                {
                    connection.Open();
                    return Convert.ToInt32(command.ExecuteScalar());
                }
                catch (SqlException)
                {
                    throw;
                }
            }
        }

        public static bool DeleteCustomer(int customerID)
        {

            using (SqlConnection connection =
                  new SqlConnection(HelperDAL.HelperDAL.ConnectionString))
            using (SqlCommand command =
                   new SqlCommand("[dbo].usp_DeleteCustomer", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@CustomerID", SqlDbType.Int).Value = customerID;


                try
                {
                    connection.Open();
                    return Convert.ToInt32(command.ExecuteScalar()) > 0;
                }
                catch (SqlException)
                {
                    throw;
                }

            }

        }


    }
}
```

### `NovaBusinessSystem.DAL/Customers DAL/Loyalty/LoyaltyDAL.cs`

```cs
using System.Data;
using Microsoft.Data.SqlClient;
using NovaBusinessSystem.DTOs;

namespace NovaBusinessSystem.DAL.Customers.Loyalty
{
    public class LoyaltyDAL
    {
        public static async Task<CustomerPointsDTO>? ViewCustomerPoints(int id)
        {
            CustomerPointsDTO? customerPointsDTO = null;

            using (SqlConnection connection =
                 new SqlConnection(HelperDAL.HelperDAL.ConnectionString))
            using (SqlCommand command =
                   new SqlCommand("[dbo].usp_ViewCustomerPoints", connection))
            {

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@CustomerID", SqlDbType.Int).Value = id;

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.Read())
                        {
                            customerPointsDTO = new CustomerPointsDTO(

                                 reader.GetInt32(reader.GetOrdinal("CustomerID")),
                                 reader.GetString(reader.GetOrdinal("FullName")),
                                 reader.GetInt32(reader.GetOrdinal("Current Points")),
                                 reader.GetString(reader.GetOrdinal("Loyalty Level"))

                             );


                        }
                    }

                }
                catch (SqlException)
                {
                    return null;
                }
            }

            return customerPointsDTO;
        }

        public static async Task<bool>? AddPointsToCustomer(int id, int pointsToAdd)
        {

            using (SqlConnection connection =
                 new SqlConnection(HelperDAL.HelperDAL.ConnectionString))
            using (SqlCommand command =
                   new SqlCommand("[dbo].usp_AddPoints", connection))
            {

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@CustomerID", SqlDbType.Int).Value = id;
                command.Parameters.Add("@PointsToAdd", SqlDbType.Int).Value = pointsToAdd;

                try
                {
                    connection.Open();

                    return Convert.ToInt32(await command.ExecuteScalarAsync()) > 0;

                }
                catch (SqlException)
                {
                    return false;
                }
            }
        }

        public static async Task<bool>? RedeemPointsToCustomer(int id, int pointsToRedeem)
        {

            using (SqlConnection connection =
                 new SqlConnection(HelperDAL.HelperDAL.ConnectionString))
            using (SqlCommand command =
                   new SqlCommand("[dbo].usp_RedeemPoints", connection))
            {

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@CustomerID", SqlDbType.Int).Value = id;
                command.Parameters.Add("@PointToRedeem", SqlDbType.Int).Value = pointsToRedeem;

                try
                {
                    connection.Open();

                    return Convert.ToInt32(await command.ExecuteScalarAsync()) > 0;

                }
                catch (SqlException)
                {
                    return false;
                }
            }
        }

        public static async Task<IEnumerable<TopLoyaltyCustomerDTO>>? GetTopLoyaltyCustomers()
        {

            List<TopLoyaltyCustomerDTO>? L_TopLoyaltyCustomerDTO = new();

            using (SqlConnection connection =
                 new SqlConnection(HelperDAL.HelperDAL.ConnectionString))

            using (SqlCommand command =
                   new SqlCommand("[dbo].usp_GetTopLoyaltyCustomers", connection))
            {

                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            L_TopLoyaltyCustomerDTO.Add(

                                new TopLoyaltyCustomerDTO(

                                 reader.GetInt64(reader.GetOrdinal("Rank")),
                                 reader.GetString(reader.GetOrdinal("FullName")),
                                 reader.GetInt32(reader.GetOrdinal("Points")),
                                 reader.GetString(reader.GetOrdinal("Level"))

                                )
                            );

                        }
                    }

                }
                catch (SqlException)
                {
                    return null!;
                }
            }

            return L_TopLoyaltyCustomerDTO;
        }

        public static async Task<LoyaltyStatisticsDTO>? GetLoyaltyStatistics()
        {

            LoyaltyStatisticsDTO LoyaltyStatisticsDTO = null;

            using (SqlConnection connection =
                 new SqlConnection(HelperDAL.HelperDAL.ConnectionString))

            using (SqlCommand command =
                   new SqlCommand("[dbo].[usp_GetLoyaltyStatistics]", connection))
            {

                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.Read())
                        {

                            LoyaltyStatisticsDTO = new LoyaltyStatisticsDTO(

                              reader.GetInt32(reader.GetOrdinal("Total Loyalty Points")),
                              reader.GetInt32(reader.GetOrdinal("Minimum Points")),
                              reader.GetInt32(reader.GetOrdinal("Maximum Points")),
                              reader.GetDecimal(reader.GetOrdinal("Average Points")),
                              reader.GetInt32(reader.GetOrdinal("Diamond Customers")),
                              reader.GetInt32(reader.GetOrdinal("Platinum Customers")),
                              reader.GetInt32(reader.GetOrdinal("Gold Customers")),
                              reader.GetInt32(reader.GetOrdinal("Silver Customers")),
                              reader.GetInt32(reader.GetOrdinal("Bronze Customers"))


                             );
                        }
                    }

                }
                catch (SqlException)
                {
                    return null!;
                }
            }

            return LoyaltyStatisticsDTO!;
        }
    }
}
```

### `NovaBusinessSystem.DAL/Customers DAL/Purchases/PurchasesDAL.cs`

```cs
using Microsoft.Data.SqlClient;
using NovaBusinessSystem.DTOs;

namespace NovaBusinessSystem.DAL.Customers.Purchases
{
    public class PurchasesDAL
    {

        public static async Task<IEnumerable<CustomerPurchaseDTO>> GetPurchaseHistoryAsync(int customerId)
        {

            List<CustomerPurchaseDTO> purchaseHistory = new();

            using (SqlConnection connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString))
            using (SqlCommand command = new SqlCommand("[dbo].usp_GetPurchaseHistory", connection))
            {

                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add("@CustomerID", System.Data.SqlDbType.Int).Value = customerId;

                try
                {
                    await connection.OpenAsync();

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            purchaseHistory.Add(

                                new CustomerPurchaseDTO(

                                    reader.GetInt32(reader.GetOrdinal("SaleID")),
                                    reader.GetString(reader.GetOrdinal("Date")),
                                    reader.GetDecimal(reader.GetOrdinal("Amount")),
                                    reader.GetString(reader.GetOrdinal("PaymentMethod")),
                                    reader.GetString(reader.GetOrdinal("Status"))
                                )
                            );

                        }
                    }

                }
                catch (SqlException ex)
                {
                    throw;
                }
            }

            return purchaseHistory;
        }

        public static async Task<CustomerSpendingSummaryDTO>? GetCustomerSpendingAsync(int customerId)
        {

            CustomerSpendingSummaryDTO customerSpendingSummary = null!;

            using (SqlConnection connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString))
            using (SqlCommand command = new SqlCommand("[dbo].usp_GetCustomerSpending", connection))
            {

                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add("@CustomerID", System.Data.SqlDbType.Int).Value = customerId;

                try
                {
                    await connection.OpenAsync();

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {

                            customerSpendingSummary = new CustomerSpendingSummaryDTO(

                                    reader.GetInt32(reader.GetOrdinal("TotalOrders")),
                                    reader.GetInt32(reader.GetOrdinal("Completed")),
                                    reader.GetInt32(reader.GetOrdinal("Pending")),
                                    reader.GetInt32(reader.GetOrdinal("Cancelled")),
                                    reader.GetString(reader.GetOrdinal("TotalSpent")),
                                    reader.GetString(reader.GetOrdinal("AverageOrder")),
                                    reader.GetString(reader.GetOrdinal("LargestOrder")),
                                    reader.GetString(reader.GetOrdinal("FirstPurchase")),
                                    reader.GetString(reader.GetOrdinal("LastPurchase"))
                             );

                        }
                    }

                }
                catch (SqlException ex)
                {
                    throw;
                }
            }

            return customerSpendingSummary!;
        }

        public static async Task<IEnumerable<FavoriteProductDTO>>? GetCustomerFavoriteProductsAsync(int customerId)
        {

            List<FavoriteProductDTO> L_FavoriteProducts = new();

            using (SqlConnection connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString))
            using (SqlCommand command = new SqlCommand("[dbo].usp_GetCustomerFavoriteProducts", connection))
            {

                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add("@CustomerID", System.Data.SqlDbType.Int).Value = customerId;

                try
                {
                    await connection.OpenAsync();

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            L_FavoriteProducts.Add(

                             new FavoriteProductDTO(


                            reader.GetInt64(reader.GetOrdinal("Rank")),
                            reader.GetString(reader.GetOrdinal("ProductName")),
                            reader.GetInt32(reader.GetOrdinal("Quantity"))


                          )
                        );

                        }

                    }

                }
                catch (SqlException ex)
                {
                    throw;
                }
            }

            return L_FavoriteProducts!;
        }

        public static async Task<IEnumerable<MonthlyPurchaseDTO>>? GetCustomerMonthlyPurchasesAsync()
        {

            List<MonthlyPurchaseDTO> monthlyPurchases = new();

            using (SqlConnection connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString))
            using (SqlCommand command = new SqlCommand("[dbo].usp_GetCustomerMonthlyPurchases", connection))
            {

                command.CommandType = System.Data.CommandType.StoredProcedure;

                try
                {
                    await connection.OpenAsync();

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            monthlyPurchases.Add(

                             new MonthlyPurchaseDTO(

                                    reader.GetString(reader.GetOrdinal("Month")),
                                    reader.GetInt32(reader.GetOrdinal("Orders")),
                                    reader.GetDecimal(reader.GetOrdinal("TotalSpent"))


                          )
                        );

                        }

                    }

                }
                catch (SqlException)
                {
                    throw;
                }
            }

            return monthlyPurchases!;
        }

        public static async Task<IEnumerable<CustomerRankingDTO>>? GetGetCustomersRankingAsync()
        {

            List<CustomerRankingDTO> customerRankings = new();

            using (SqlConnection connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString))
            using (SqlCommand command = new SqlCommand("[dbo].usp_GetCustomersRanking", connection))
            {

                command.CommandType = System.Data.CommandType.StoredProcedure;

                try
                {
                    await connection.OpenAsync();

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            customerRankings.Add(

                             new CustomerRankingDTO(

                                    reader.GetInt64(reader.GetOrdinal("Rank")),
                                    reader.GetString(reader.GetOrdinal("FullName")),
                                    reader.GetInt32(reader.GetOrdinal("Orders")),
                                    reader.GetDecimal(reader.GetOrdinal("Spending"))

                          )
                        );

                        }

                    }

                }
                catch (SqlException)
                {
                    throw;
                }
            }

            return customerRankings!;
        }

    }
}
```

### `NovaBusinessSystem.DAL/Customers DAL/Report/ReportDAL.cs`

```cs
using System.Data;
using Microsoft.Data.SqlClient;
using NovaBusinessSystem.DTOs.Customers.Reports;

namespace NovaBusinessSystem.DAL.Customers.Reports
{

    public class ReportDAL
    {
        public static async Task<IEnumerable<CustomerStatusDTO>>? GetCustomerStatusSummaryAsync()
        {

            List<CustomerStatusDTO> customerStatuses = new();


            using (SqlConnection connection =
                 new SqlConnection(HelperDAL.HelperDAL.ConnectionString))

            using (SqlCommand command =
                   new SqlCommand("usp_GetCustomerStatusSummary", connection))
            {

                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            customerStatuses.Add(
                             new CustomerStatusDTO(

                                    reader.GetString(reader.GetOrdinal("Status")),
                                    reader.GetInt32(reader.GetOrdinal("Customers"))


                             )
                            );
                        }
                    }

                }
                catch (SqlException)
                {
                    return null!;
                }
            }

            return customerStatuses!;
        }

        public static async Task<IEnumerable<CustomersByCityDTO>>? GetCustomersByCityAsync()
        {

            List<CustomersByCityDTO> L_CustomersByCities = new();


            using (SqlConnection connection =
                 new SqlConnection(HelperDAL.HelperDAL.ConnectionString))

            using (SqlCommand command =
                   new SqlCommand("[dbo].usp_GetCustomersByCity", connection))
            {

                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            L_CustomersByCities.Add(
                             new CustomersByCityDTO(

                                    reader.GetString(reader.GetOrdinal("City")),
                                    reader.GetInt32(reader.GetOrdinal("Customers"))


                             )
                            );
                        }
                    }

                }
                catch (SqlException)
                {
                    return null!;
                }
            }

            return L_CustomersByCities!;
        }

        public static async Task<IEnumerable<LoyaltySummaryDTO>>? GetLoyaltySummaryReportAsync()
        {

            List<LoyaltySummaryDTO> L_LoyaltySummaries = new();


            using (SqlConnection connection =
                 new SqlConnection(HelperDAL.HelperDAL.ConnectionString))

            using (SqlCommand command =
                   new SqlCommand("[dbo].usp_GetLoyaltySummaryReport", connection))
            {

                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            L_LoyaltySummaries.Add(

                             new LoyaltySummaryDTO(

                                    reader.GetString(reader.GetOrdinal("LoyaltyLevel")),
                                    reader.GetInt32(reader.GetOrdinal("Customers")),
                                    reader.GetInt32(reader.GetOrdinal("Total Points"))


                             )
                            );
                        }
                    }

                }
                catch (SqlException)
                {
                    return null!;
                }
            }

            return L_LoyaltySummaries!;
        }

        public static async Task<IEnumerable<RegistrationSummaryDTO>>? GetRegistrationSummaryAsync()
        {

            List<RegistrationSummaryDTO> L_RegistrationSummaries = new();


            using (SqlConnection connection =
                 new SqlConnection(HelperDAL.HelperDAL.ConnectionString))

            using (SqlCommand command =
                   new SqlCommand("[dbo].usp_GetRegistrationSummary", connection))
            {

                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            L_RegistrationSummaries.Add(

                             new RegistrationSummaryDTO(

                                    reader.GetInt32(reader.GetOrdinal("Year")),
                                    reader.GetInt32(reader.GetOrdinal("New Customers"))


                             )
                            );
                        }
                    }

                }
                catch (SqlException)
                {
                    return null!;
                }
            }

            return L_RegistrationSummaries!;
        }
    }
}
```

### `NovaBusinessSystem.DAL/Departments DAL/DepartmentDAL.cs`

```cs
using System.ComponentModel.DataAnnotations;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer;

public class DepartmentsDAL
{

    public static bool GetDepartmentBy(
        int DepartmentID,
        ref string DepartmentName,
        ref string Location,
        ref decimal Budget
        )
    {

        bool IsFound = false;

        using (SqlConnection connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString))
        using (SqlCommand command = new SqlCommand("[dbo].usp_GetDepartmentByID", connection))
        {

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = DepartmentID;

            SqlParameter paramDepartmentName = command.Parameters.Add("@DepartmentName", SqlDbType.NVarChar, 150);
            paramDepartmentName.Direction = ParameterDirection.Output;

            SqlParameter paramLocation = command.Parameters.Add("@Location", SqlDbType.NVarChar, 300);
            paramLocation.Direction = ParameterDirection.Output;

            SqlParameter paramBudget = command.Parameters.Add("@Budget", SqlDbType.Decimal);
            paramBudget.Precision = 10;
            paramBudget.Scale = 2;

            paramBudget.Direction = ParameterDirection.Output;

            try
            {
                connection.Open();

                command.ExecuteNonQuery();

                DepartmentName = (string)paramDepartmentName.Value;
                Location = (string)paramLocation.Value;
                Budget = (decimal)paramBudget.Value;

                IsFound = true;

            }
            catch (SqlException SEX)
            {
                if (SEX.Number >= 50001)
                    IsFound = false;

                throw;


            }
        }
        return IsFound;
    }
}
```

### `NovaBusinessSystem.DAL/Employees DAL/EmployeesDAL.cs`

```cs
﻿using System.ComponentModel.DataAnnotations;
using System.Data;
using System.IO.Pipelines;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer;

public class EmployeesDAL
{

    public static DataTable GetListEmployees(

        string? FullName = null,
        string? DepartmentName = null,
        string? JobTitle = null,
        string? Status = null

        )
    {

        DataTable DT_AllEmployees = new DataTable();

        using (SqlConnection connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString))
        {


            using (SqlCommand command = new SqlCommand("[dbo].[usp_ListEmployees]", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@FullName", FullName is not null ? FullName : DBNull.Value);
                command.Parameters.AddWithValue("@DepartmentName", DepartmentName is not null ? DepartmentName : DBNull.Value);
                command.Parameters.AddWithValue("@JobTitle", JobTitle is not null ? JobTitle : DBNull.Value);
                command.Parameters.AddWithValue("@Status", Status is not null ? Status : DBNull.Value);

                try
                {
                    connection.Open();
                    // way one useing Data Adapter (DOn't use SqlConnection ) 
                    //Way Two using Data Reader (Must declare SqlConnection )

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                            DT_AllEmployees.Load(reader);
                    }

                }
                catch (SqlException SEX)
                {
                    throw;
                }
            }
        }

        return DT_AllEmployees;
    }

    public static bool GetEmployeeBy(

        int employeeID,
        ref string firstName,
        ref string lastName,
        ref int departmentID,
        ref int managerID,
        ref string jobTitle,
        ref decimal salary,
        ref DateTime hireDate,
        ref string phone,
        ref string email,
        ref byte status

     )
    {

        bool isFound = false;

        using (SqlConnection connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString))
        using (SqlCommand command = new SqlCommand("[dbo].[usp_GetEmployeeByID]", connection))
        {
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@EmployeeID", employeeID);

            //output parameters 

            SqlParameter paramFirstName = command.Parameters.Add("@FirstName", SqlDbType.NVarChar, 200);
            paramFirstName.Direction = ParameterDirection.Output;

            SqlParameter paramLastName = command.Parameters.Add("@LastName", SqlDbType.NVarChar, 200);
            paramLastName.Direction = ParameterDirection.Output;

            SqlParameter paramDepartmentID = command.Parameters.Add("@DepartmentID", SqlDbType.Int);
            paramDepartmentID.Direction = ParameterDirection.Output;

            SqlParameter paramManagerID = command.Parameters.Add("@ManagerID", SqlDbType.Int);
            paramManagerID.Direction = ParameterDirection.Output;

            SqlParameter paramJobTitle = command.Parameters.Add("@JobTitle", SqlDbType.NVarChar, 200);
            paramJobTitle.Direction = ParameterDirection.Output;

            SqlParameter paramSalary = command.Parameters.Add("@Salary", SqlDbType.Decimal);
            paramSalary.Precision = 10;
            paramSalary.Scale = 2;
            paramSalary.Direction = ParameterDirection.Output;

            SqlParameter paramHireDate = command.Parameters.Add("@HireDate", SqlDbType.Date);
            paramHireDate.Direction = ParameterDirection.Output;

            SqlParameter paramPhone = command.Parameters.Add("@Phone", SqlDbType.Char, 11);
            paramPhone.Direction = ParameterDirection.Output;

            SqlParameter paramEmail = command.Parameters.Add("@Email", SqlDbType.VarChar, -1);
            paramEmail.Direction = ParameterDirection.Output;

            SqlParameter paramStatus = command.Parameters.Add("@Status", SqlDbType.TinyInt);
            paramStatus.Direction = ParameterDirection.Output;


            try
            {

                connection.Open();

                command.ExecuteNonQuery();


                firstName = (string)paramFirstName.Value;
                lastName = (string)paramLastName.Value;
                departmentID = (int)paramDepartmentID.Value;
                managerID = (int)(paramManagerID.Value ?? -1);
                jobTitle = (string)paramJobTitle.Value;
                salary = (decimal)paramSalary.Value;
                hireDate = (DateTime)paramHireDate.Value;
                phone = (string)paramPhone.Value;
                email = (string)paramEmail.Value;
                status = (byte)paramStatus.Value;

                isFound = true;

            }
            catch (SqlException SEX)
            {

                if (SEX.Number == 50001)
                    isFound = false;
                else
                    throw;

            }
        }

        return isFound;
    }


    public static int AddNewEmployee(
         string firstName,
         string lastName,
         int departmentID,
         int managerID,
         string jobTitle,
         decimal salary,
         string phone,
         string email
    )
    {
        int EmployeeID = -1;

        using (SqlConnection connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString))
        using (SqlCommand command = new SqlCommand("[dbo].usp_AddNewEmployee", connection))
        {
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@FirstName", SqlDbType.NVarChar, 100).Value = firstName;
            command.Parameters.Add("@LastName", SqlDbType.NVarChar, 100).Value = lastName;
            command.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = departmentID;
            command.Parameters.Add("@ManagerID", SqlDbType.Int).Value = managerID;
            command.Parameters.Add("@JobTitle", SqlDbType.NVarChar, 200).Value = jobTitle;

            SqlParameter paramSalary =
                command.Parameters.Add("@Salary", SqlDbType.Decimal);

            paramSalary.Precision = 10;
            paramSalary.Scale = 2;
            paramSalary.Value = salary;

            command.Parameters.Add("@Phone", SqlDbType.Char, 11).Value = phone;
            command.Parameters.Add("@Email", SqlDbType.VarChar, -1).Value = email;

            SqlParameter paramEmployeeID =
                command.Parameters.Add("@EmployeeID", SqlDbType.Int);

            paramEmployeeID.Direction = ParameterDirection.Output;

            try
            {
                connection.Open();

                command.ExecuteNonQuery();

                EmployeeID = Convert.ToInt32(paramEmployeeID.Value);
            }
            catch (SqlException SEX)
            {
                if (SEX.Number >= 50001)
                    EmployeeID = -1;

                throw;
            }
        }

        return EmployeeID;
    }


    public static bool UpdateEmployee(
        int EmployeeID,
         string firstName,
         string lastName,
         int departmentID,
         int managerID,
         string jobTitle,
         decimal salary,
         string phone,
         string email,
         string Status
    )
    {

        bool IsUpdated = false;

        using (SqlConnection connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString))
        using (SqlCommand command = new SqlCommand("[dbo].usp_UpdateEmployee", connection))
        {
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = EmployeeID;
            command.Parameters.Add("@FirstName", SqlDbType.NVarChar, 100).Value = firstName;
            command.Parameters.Add("@LastName", SqlDbType.NVarChar, 100).Value = lastName;
            command.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = departmentID;
            command.Parameters.Add("@ManagerID", SqlDbType.Int).Value = managerID;
            command.Parameters.Add("@JobTitle", SqlDbType.NVarChar, 200).Value = jobTitle;
            command.Parameters.Add("@Salary", SqlDbType.Decimal).Value = salary;
            command.Parameters.Add("@Phone", SqlDbType.Char, 11).Value = phone;
            command.Parameters.Add("@Email", SqlDbType.VarChar, -1).Value = email;
            command.Parameters.Add("@Status", SqlDbType.VarChar, 20).Value = Status;


            try
            {
                connection.Open();

                command.ExecuteNonQuery();

                IsUpdated = true;
            }
            catch (SqlException SEX)
            {
                if (SEX.Number >= 50001)
                    IsUpdated = false;

                throw;
            }
        }

        return IsUpdated;
    }

    public static bool DeleteEmployee(int EmployeeID)
    {

        using (SqlConnection connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString))
        using (SqlCommand command = new SqlCommand("[dbo].usp_DeleteEmployee", connection))
        {
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@EmployeeID", EmployeeID);

            try
            {
                connection.Open();

                command.ExecuteNonQuery();

                return true;
            }
            catch (SqlException SEX)
            {
                if (SEX.Number == 50001)
                    return false;

                throw;
            }


        }

    }

    public static DataTable GetDepartmentSammary()
    {
        DataTable DT_GetAllDepartmentSammary = new DataTable();

        using (SqlConnection connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString))
        using (SqlCommand command = new SqlCommand("[dbo].usp_DepartmentSummary", connection))
        {
            command.CommandType = CommandType.StoredProcedure;


            try
            {
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                    if (reader.HasRows)
                        DT_GetAllDepartmentSammary.Load(reader);


            }
            catch { }

        }

        return DT_GetAllDepartmentSammary;
    }

    public static DataTable GetSalarySummary()
    {
        DataTable DT_SalarySummary = new DataTable();

        using (SqlConnection connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString))
        using (SqlCommand command = new SqlCommand("[dbo].usp_SalarySummary", connection))
        {

            command.CommandType = CommandType.StoredProcedure;
            try
            {
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                    if (reader.HasRows)
                        DT_SalarySummary.Load(reader);
            }
            catch { }
            ;

        }

        return DT_SalarySummary;
    }


    public static Dictionary<string, int> GetEmployeeStatus()
    {
        Dictionary<string, int> AllStatusEmployees = new Dictionary<string, int>();

        using (SqlConnection connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString))
        using (SqlCommand command = new SqlCommand("[dbo].usp_EmployeeStatus", connection))
        {

            command.CommandType = CommandType.StoredProcedure;

            try
            {

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        AllStatusEmployees.Add(reader["Status"].ToString()!, Convert.ToInt32(reader["Count"]));
                }

            }
            catch
            {

            }
            ;

        }

        return AllStatusEmployees;
    }

    public static Dictionary<string?, int?> GetHiringSummary()
    {
        Dictionary<string?, int?> AllHiringSummary = new Dictionary<string?, int?>();

        using (SqlConnection connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString))
        using (SqlCommand command = new SqlCommand("[dbo].usp_HiringSummary", connection))
        {
            command.CommandType = CommandType.StoredProcedure;


            try
            {
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                    while (reader.Read())
                        AllHiringSummary.Add(reader["HireYear"].ToString()!, Convert.ToInt32(reader["Employees Hired"]));

            }catch
            {
                
            };
        }

        return AllHiringSummary; 

    }
}
```

### `NovaBusinessSystem.DAL/Helpers/HelperDAL.cs`

```cs

namespace HelperDAL 
{

    public sealed class HelperDAL
    {
    public static readonly string ConnectionString =
    @"Server=.;Database=TrainingDB;User Id=sa;Password=Test12345;TrustServerCertificate=True;";
    }
    
}
```

### `NovaBusinessSystem.DAL/Products DAL/ Sales/SalesDAL.cs`

```cs
using Microsoft.Data.SqlClient;
using NovaBusinessSystem.DTOs.Products.Sales;

namespace NovaBusinessSystem.DAL.Products.Sales
{

    public class SalesDAL
    {


        public static async Task<IEnumerable<ProductSalesHistoryDTO>> GetProductSalesHistoriesAsync(int productID)
        {

            List<ProductSalesHistoryDTO> L_ProductSalesHistories = new();

            using SqlConnection connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
            using SqlCommand command = new SqlCommand("[dbo].[usp_GetProductSalesHistory]", connection);

            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add("@ProductID", System.Data.SqlDbType.Int).Value = productID;

            try
            {
                await connection.OpenAsync();

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    while (await reader.ReadAsync())
                    {
                        L_ProductSalesHistories.Add(

                            new ProductSalesHistoryDTO(

                            reader.GetInt32(reader.GetOrdinal("SaleID")),
                            reader.GetString(reader.GetOrdinal("Date")),
                            reader.GetString(reader.GetOrdinal("Customer")),
                            reader.GetInt32(reader.GetOrdinal("Quantity")),
                            reader.GetDecimal(reader.GetOrdinal("UnitPrice")),
                            reader.GetString(reader.GetOrdinal("Status"))

                            )

                        );
                    }

            }
            catch (SqlException)
            {

                throw;

            }

            return L_ProductSalesHistories;

        }
    }
}
```

### `NovaBusinessSystem.DAL/Products DAL/Inventory Management/InventoryDAL.cs`

```cs


using System.Data;
using Microsoft.Data.SqlClient;
using NovaBusinessSystem.DTOs.Products.Inventory;

namespace NovaBusinessSystem.DAL.Products.Inventory
{
    public class InventoryDAL
    {

        public static async Task<ProductStockDTO?> ViewProductStockAsync(int productID)
        {
            ProductStockDTO? productStock = null;

            using (SqlConnection connection =
                new SqlConnection(HelperDAL.HelperDAL.ConnectionString))
            using (SqlCommand command =
                new SqlCommand("[dbo].[usp_ViewProductStock]", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(
                    "@ProductID",
                    SqlDbType.Int
                ).Value = productID;

                try
                {
                    await connection.OpenAsync();

                    using (SqlDataReader reader =
                        await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            productStock = new ProductStockDTO(
                                reader.GetInt32(
                                    reader.GetOrdinal("ProductID")),

                                reader.GetString(
                                    reader.GetOrdinal("ProductName")),

                                reader.GetString(
                                    reader.GetOrdinal("Category")),

                                reader.GetDecimal(
                                    reader.GetOrdinal("Price")),

                                reader.GetInt32(
                                    reader.GetOrdinal("StockQuantity")),

                                reader.GetDecimal(
                                    reader.GetOrdinal("Stock Value")),

                                reader.GetString(
                                    reader.GetOrdinal("Status"))
                            );
                        }
                    }

                    return productStock;
                }
                catch (SqlException)
                {
                    throw;
                }
            }
        }

        public static async Task<AddStockResultDTO?> AddStockAsync(int productID, int stockToAdded)
        {

            using SqlConnection connection =
                new SqlConnection(HelperDAL.HelperDAL.ConnectionString);

            using SqlCommand command =
                new SqlCommand("[dbo].[usp_AddStock]", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(
                "@ProductID",
                SqlDbType.Int
            ).Value = productID;

            command.Parameters.Add(
                "@StockToAdded",
                SqlDbType.Int
            ).Value = stockToAdded;


            await connection.OpenAsync();

            using SqlDataReader reader =
                await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return new AddStockResultDTO(
                    reader.GetInt32(reader.GetOrdinal("ProductID")),
                    reader.GetString(reader.GetOrdinal("ProductName")),
                    reader.GetInt32(reader.GetOrdinal("PreviousStock")),
                    reader.GetInt32(reader.GetOrdinal("AddedStock")),
                    reader.GetInt32(reader.GetOrdinal("NewStock"))
                );
            }

            return null;
        }

        public static async Task<RemoveStockResultDTO?> RemoveStockAsync(
                int productID,
                int stockToBeRemove)
        {
            using SqlConnection connection =
                new SqlConnection(HelperDAL.HelperDAL.ConnectionString);

            using SqlCommand command =
                new SqlCommand("[dbo].[usp_RemoveStock]", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(
                "@ProductID",
                SqlDbType.Int
            ).Value = productID;

            command.Parameters.Add(
                "@StockToBeRemove",
                SqlDbType.Int
            ).Value = stockToBeRemove;

            await connection.OpenAsync();

            using SqlDataReader reader =
                await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return new RemoveStockResultDTO(
                    reader.GetInt32(
                        reader.GetOrdinal("ProductID")),

                    reader.GetString(
                        reader.GetOrdinal("ProductName")),

                    reader.GetInt32(
                        reader.GetOrdinal("PreviousStock")),

                    reader.GetInt32(
                        reader.GetOrdinal("RemovedStock")),

                    reader.GetInt32(
                        reader.GetOrdinal("NewStock"))
                );
            }

            return null;
        }

        public static async Task<AdjustStockResultDTO?> AdjustStockAsync(
                    int productID,
                    int actualStock)
        {
            using SqlConnection connection =
                new SqlConnection(HelperDAL.HelperDAL.ConnectionString);

            using SqlCommand command =
                new SqlCommand("[dbo].[usp_AdjustStock]", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;
            command.Parameters.Add("@ActualStock", SqlDbType.Int).Value = actualStock;

            await connection.OpenAsync();

            using SqlDataReader reader =
                await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return new AdjustStockResultDTO(
                    reader.GetInt32(reader.GetOrdinal("ProductID")),
                    reader.GetString(reader.GetOrdinal("ProductName")),
                    reader.GetInt32(reader.GetOrdinal("PreviousStock")),
                    reader.GetInt32(reader.GetOrdinal("ActualStock")),
                    reader.GetInt32(reader.GetOrdinal("Adjustment"))
                );
            }

            return null;
        }

        public static async Task<IEnumerable<LowStockProductDTO>> GetLowStockProducts(int threshold)
        {
            List<LowStockProductDTO> lowStockProducts = new();

            using SqlConnection connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
            using SqlCommand command = new SqlCommand("[dbo].[usp_GetLowStockProducts]", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Threshold", SqlDbType.Int).Value = threshold;

            try
            {
                await connection.OpenAsync();

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        lowStockProducts.Add(
                            new LowStockProductDTO(

                                reader.GetInt32(reader.GetOrdinal("ProductID")),
                                reader.GetString(reader.GetOrdinal("ProductName")),
                                reader.GetString(reader.GetOrdinal("Category")),
                                reader.GetInt32(reader.GetOrdinal("StockQuantity")),
                                reader.GetString(reader.GetOrdinal("Status"))

                            )
                        );
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return lowStockProducts;
        }

        public static async Task<IEnumerable<OutOfStockProductDTO>> GetOutOfStockProducts()
        {

            List<OutOfStockProductDTO> outOfStockProducts = new();

            using SqlConnection connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);
            using SqlCommand command = new SqlCommand("[dbo].[GetOutOfStockProducts]", connection);

            command.CommandType = CommandType.StoredProcedure;

            try
            {
                await connection.OpenAsync();

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        outOfStockProducts.Add(
                            new OutOfStockProductDTO(

                        reader.GetInt32(reader.GetOrdinal("ProductID")),
                        reader.GetString(reader.GetOrdinal("ProductName")),
                        reader.GetString(reader.GetOrdinal("Category")),
                        reader.GetString(reader.GetOrdinal("Status"))

                            )
                        );
                    }
                }

            }
            catch (SqlException)
            {
                throw;
            }

            return outOfStockProducts;
        }


        public static async Task<InventoryValueDTO?>  ? GetInventoryValueAsync()
        {

            using SqlConnection connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString);

            using SqlCommand command = new SqlCommand("[dbo].[usp_GetInventoryValue]", connection);


            command.CommandType = CommandType.StoredProcedure;


            try
            {
                await connection.OpenAsync();


                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    if (await reader.ReadAsync())
                    {
                        return new InventoryValueDTO(
                            reader.GetInt32(reader.GetOrdinal("TotalProducts")),
                            Convert.ToInt32(reader["TotalStockUnits"]),
                            Convert.ToDecimal(reader["TotalInventoryValue"]),
                            Convert.ToDecimal(reader["AverageProductPrice"]),
                            Convert.ToDecimal(reader["AverageStock"]),
                            reader["ProductName"].ToString()!,
                            Convert.ToDecimal(reader["StockValue"])
                        );
                    }

            }
            catch (SqlException)
            {
                throw;
            }
            return null ; 
        }
    }
}
```

### `NovaBusinessSystem.DAL/Products DAL/ProductsDAL.cs`

```cs
using System.Data;
using Microsoft.Data.SqlClient;
using NovaBusinessSystem.DTOs.Products;

namespace NovaBusinessSystem.DAL.Products
{

    public class ProductsDAL
    {

        public async static Task<IEnumerable<ProductDTO>>? GetAllProductsAsync()
        {
            List<ProductDTO> L_Products = new List<ProductDTO>();


            using (SqlConnection connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString))
            using (SqlCommand command = new SqlCommand("[dbo].usp_GetAllProducts", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    await connection.OpenAsync();

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        while (await reader.ReadAsync())
                        {
                            L_Products.Add(

                                 new ProductDTO(
                                     reader.GetInt32(reader.GetOrdinal("ProductID")),
                                     reader.GetString(reader.GetOrdinal("ProductName")),
                                     reader.GetString(reader.GetOrdinal("Category")),
                                     reader.GetDecimal(reader.GetOrdinal("Price")),
                                     reader.GetInt32(reader.GetOrdinal("StockQuantity")),
                                     reader.GetString(reader.GetOrdinal("Status"))
                                 )

                            );
                        }


                }

                catch (SqlException) { throw; }
                ;
            }

            return L_Products;

        }

        public async static Task<ProductDTO>? GetProductByIDAsync(int productID)
        {
            ProductDTO productInformation = null!;


            using (SqlConnection connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString))
            using (SqlCommand command = new SqlCommand("[dbo].[usp_GetProductByID]", connection))
            {

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;


                try
                {
                    await connection.OpenAsync();

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        while (await reader.ReadAsync())
                        {

                            productInformation = new ProductDTO(
                                 reader.GetInt32(reader.GetOrdinal("ProductID")),
                                 reader.GetString(reader.GetOrdinal("ProductName")),
                                 reader.GetString(reader.GetOrdinal("Category")),
                                 reader.GetDecimal(reader.GetOrdinal("Price")),
                                 reader.GetInt32(reader.GetOrdinal("StockQuantity")),
                                 reader.GetString(reader.GetOrdinal("Status"))
                             );

                        }


                }

                catch (SqlException) { throw; }
                ;
            }

            return productInformation!;

        }

        public async static Task<int>? AddNewProductAsync(ProductDTO product)
        {

            using (SqlConnection connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString))
            using (SqlCommand command = new SqlCommand("[dbo].[usp_AddNewProduct]", connection))
            {

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@ProductName", SqlDbType.VarChar, 100).Value = product.ProductName;
                command.Parameters.Add("@Category", SqlDbType.VarChar, 100).Value = product.Category;

                SqlParameter priceParameter =
                    command.Parameters.Add("@Price", SqlDbType.Decimal);

                priceParameter.Precision = 18;
                priceParameter.Scale = 2;
                priceParameter.Value = product.Price;

                command.Parameters.Add("@StockQuantity", SqlDbType.Int).Value = product.StockQuantity;
                command.Parameters.Add("@Status", SqlDbType.VarChar, 50).Value = product.Status;

                SqlParameter paramProductID = new SqlParameter("@ProductID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };

                command.Parameters.Add(paramProductID);



                try
                {
                    await connection.OpenAsync();

                    await command.ExecuteNonQueryAsync();

                    return Convert.ToInt32(paramProductID.Value);

                }

                catch (SqlException) { throw; }
                ;
            }
        }

        public async static Task<int>? UpdateProductAsync(int productID, ProductUpdateDTO product)
        {

            using (SqlConnection connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString))
            using (SqlCommand command = new SqlCommand("[dbo].[usp_UpdateProduct]", connection))
            {

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@ProductName", SqlDbType.VarChar, 100).Value = product.ProductName;
                command.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;

                command.Parameters.Add("@Category", SqlDbType.VarChar, 100).Value = product.Category;

                SqlParameter priceParameter =
                    command.Parameters.Add("@Price", SqlDbType.Decimal);

                priceParameter.Precision = 18;
                priceParameter.Scale = 2;
                priceParameter.Value = product.Price;

                command.Parameters.Add("@Status", SqlDbType.VarChar, 50).Value = product.Status;





                try
                {
                    await connection.OpenAsync();
                    return Convert.ToInt32(await command.ExecuteScalarAsync());

                }

                catch (SqlException) { throw; }
                ;
            }
        }

        public async static Task<bool>? DeleteProductAsync(int productID)
        {

            using (SqlConnection connection = new SqlConnection(HelperDAL.HelperDAL.ConnectionString))
            using (SqlCommand command = new SqlCommand("[dbo].[usp_DeleteProduct]", connection))
            {

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;

                try
                {
                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                    return true;

                }

                catch (SqlException) { throw; }
                ;
            }
        }
    }

}
```

### `NovaBusinessSystem.DTOs/Customer DTOs/CustomerAddDTO.cs`

```cs
namespace NovaBusinessSystem.DTOs;

public class CustomerAddDTO
{
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string Phone { get; private set; } = string.Empty;
    public string City { get; private set; } = string.Empty;
    public string Status { get; private set; }
    
    public CustomerAddDTO(
        string firstName,
        string lastName,
        string email,
        string phone,
        string city,
        string status
        )
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Email = email;
        this.Phone = phone;
        this.City = city;
        this.Status = status;
    }
}
```

### `NovaBusinessSystem.DTOs/Customer DTOs/CustomerDTO.cs`

```cs
﻿namespace NovaBusinessSystem.DTOs;

public class CustomerDTO
{
    public int CustomerID { get; private set; }
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string Phone { get; private set; } = string.Empty;
    public string City { get; private set; } = string.Empty;
    public DateTime RegistrationDate { get; private set; }
    public int LoyaltyPoints { get; private set; }
    public string Status { get; private set; }
    
    public CustomerDTO(
        int customerID,
        string firstName,
        string lastName,
        string email,
        string phone,
        string city,
        DateTime registrationDate,
        int loyaltyPoints,
        string status)
    {
        this.CustomerID = customerID;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Email = email;
        this.Phone = phone;
        this.City = city;
        this.RegistrationDate = registrationDate;
        this.LoyaltyPoints = loyaltyPoints;
        this.Status = status;
    }
}
```

### `NovaBusinessSystem.DTOs/Customer DTOs/CustomerPointsDTO.cs`

```cs
namespace NovaBusinessSystem.DTOs
{

    public class CustomerPointsDTO
    {
        public int CustomerID { get; private set; }
        public string CustomerName { get; private set; } = string.Empty;
        public int CurrentPoints { get; private set; }
        public string LoyaltyLevel { get; private set; } = string.Empty;

        public CustomerPointsDTO(
            int customerID ,
            string customerName,
            int currentPoints,
            string loyaltyLevel)
        {
            this.CustomerID = customerID ;
            this.CustomerName = customerName;
            this.CurrentPoints = currentPoints;
            this.LoyaltyLevel = loyaltyLevel;
        }
    }
}
```

### `NovaBusinessSystem.DTOs/Customer DTOs/Report DTOs/CustomerStatusDTO.cs`

```cs
namespace NovaBusinessSystem.DTOs.Customers.Reports
{
    public class CustomerStatusDTO
    {
        public string Status { get; set; }
        public int Customers { get; set; }

        public CustomerStatusDTO(string status, int customers)
        {
            this.Status = status;
            this.Customers = customers;
        }
    }
}
```

### `NovaBusinessSystem.DTOs/Customer DTOs/Report DTOs/CustomersByCityDTO.cs`

```cs
namespace NovaBusinessSystem.DTOs.Customers.Reports
{
    public class CustomersByCityDTO
    {
        public string City { get; private set; }
        public int Customers { get; private set; }

        public CustomersByCityDTO(string city, int customers)
        {
            this.City = city;
            this.Customers = customers;
        }
    }
}
```

### `NovaBusinessSystem.DTOs/Customer DTOs/Report DTOs/LoyaltySummaryDTO.cs`

```cs
namespace NovaBusinessSystem.DTOs.Customers.Reports
{
    public class LoyaltySummaryDTO
    {
        public string LoyaltyLevel { get; private set; }
        public int Customers { get; private set; }
        public int TotalPoints { get; private set; }

        public LoyaltySummaryDTO(
            string loyaltyLevel,
            int customers,
            int totalPoints)
        {
            this.LoyaltyLevel = loyaltyLevel;
            this.Customers = customers;
            this.TotalPoints = totalPoints;
        }
    }
}
```

### `NovaBusinessSystem.DTOs/Customer DTOs/Report DTOs/RegistrationSummaryDTO.cs`

```cs
namespace NovaBusinessSystem.DTOs.Customers.Reports
{
    public class RegistrationSummaryDTO
    {
        public int Year { get; private set; }
        public int NewCustomers { get; private set; }

        public RegistrationSummaryDTO(int year, int newCustomers)
        {
            this.Year = year;
            this.NewCustomers = newCustomers;
        }
    }
}
```

### `NovaBusinessSystem.DTOs/Customer Purchases DTOs/CustomerPurchaseDTO.cs`

```cs
namespace NovaBusinessSystem.DTOs
{

    public class CustomerPurchaseDTO
    {
        public int SaleID { get; private set; }
        public string SaleDate { get; private set; }
        public decimal Amount { get; private set; }
        public string PaymentMethod { get; private set; }
        public string Status { get; private set; }

        public CustomerPurchaseDTO(
            int saleID,
            string saleDate,
            decimal amount,
            string paymentMethod,
            string status)
        {
            this.SaleID = saleID;
            this.SaleDate = saleDate;
            this.Amount = amount;
            this.PaymentMethod = paymentMethod;
            this.Status = status;
        }
    }
}
```

### `NovaBusinessSystem.DTOs/Customer Purchases DTOs/CustomerRankingDTO.cs`

```cs
namespace NovaBusinessSystem.DTOs
{
    public class CustomerRankingDTO
    {
        public long Rank { get; private set; }
        public string FullName { get; private set; }
        public int Orders { get; private set; }
        public decimal Spending { get; private set; }

        public CustomerRankingDTO(
            long rank,
            string fullName,
            int orders,
            decimal spending)
        {
            this.Rank = rank;
            this.FullName = fullName;
            this.Orders = orders;
            this.Spending = spending;
        }
    }
}
```

### `NovaBusinessSystem.DTOs/Customer Purchases DTOs/CustomerSpendingSummaryDTO.cs`

```cs
namespace NovaBusinessSystem.DTOs
{

    public class CustomerSpendingSummaryDTO
    {
        public int TotalOrders { get; private set; }
        public int Completed { get; private set; }
        public int Pending { get; private set; }
        public int Cancelled { get; private set; }
        public string TotalSpent { get; private set; }
        public string AverageOrder { get; private set; }
        public string LargestOrder { get; private set; }
        public string FirstPurchase { get; private set; }
        public string LastPurchase { get; private set; }

        public CustomerSpendingSummaryDTO(

            int totalOrders,
            int completed,
            int pending,
            int cancelled,
            string totalSpent,
            string averageOrder,
            string largestOrder,
            string firstPurchase,
            string lastPurchase

            )
        {
            this.TotalOrders = totalOrders;
            this.Completed = completed;
            this.Pending = pending;
            this.Cancelled = cancelled;
            this.TotalSpent = totalSpent;
            this.AverageOrder = averageOrder;
            this.LargestOrder = largestOrder;
            this.FirstPurchase = firstPurchase;
            this.LastPurchase = lastPurchase;
        }
    }
}
```

### `NovaBusinessSystem.DTOs/Customer Purchases DTOs/FavoriteProductDTO.cs`

```cs
namespace NovaBusinessSystem.DTOs
{

    public class FavoriteProductDTO
    {
        public long Rank { get; private set; }
        public string ProductName { get; private set; }
        public int Quantity { get; private set; }

        public FavoriteProductDTO(
            long rank,
            string productName,
            int quantity)
        {
            this.Rank = rank;
            this.ProductName = productName;
            this.Quantity = quantity;
        }
    }

}
```

### `NovaBusinessSystem.DTOs/Customer Purchases DTOs/MonthlyPurchaseDTO.cs`

```cs
namespace NovaBusinessSystem.DTOs
{

    public class MonthlyPurchaseDTO
    {
        public string Month { get; private set; }
        public int Orders { get; private set; }
        public decimal TotalSpent { get; private set; }

        public MonthlyPurchaseDTO(
            string month,
            int orders,
            decimal totalSpent)
        {
            this.Month = month;
            this.Orders = orders;
            this.TotalSpent = totalSpent;
        }
    }
}
```

### `NovaBusinessSystem.DTOs/Loyalty DTOs/LoyaltyStatisticsDTO.cs`

```cs
namespace NovaBusinessSystem.DTOs
{

    public class LoyaltyStatisticsDTO
    {
        public long TotalLoyaltyPoints { get; private set; }

        public int MinimumPoints { get; private set; }

        public int MaximumPoints { get; private set; }

        public decimal AveragePoints { get; private set; }

        public int DiamondCustomers { get; private set; }

        public int PlatinumCustomers { get; private set; }

        public int GoldCustomers { get; private set; }

        public int SilverCustomers { get; private set; }

        public int BronzeCustomers { get; private set; }

        public LoyaltyStatisticsDTO(
            long totalLoyaltyPoints,
            int minimumPoints,
            int maximumPoints,
            decimal averagePoints,
            int diamondCustomers,
            int platinumCustomers,
            int goldCustomers,
            int silverCustomers,
            int bronzeCustomers)
        {
            this.TotalLoyaltyPoints = totalLoyaltyPoints;
            this.MinimumPoints = minimumPoints;
            this.MaximumPoints = maximumPoints;
            this.AveragePoints = averagePoints;
            this.DiamondCustomers = diamondCustomers;
            this.PlatinumCustomers = platinumCustomers;
            this.GoldCustomers = goldCustomers;
            this.SilverCustomers = silverCustomers;
            this.BronzeCustomers = bronzeCustomers;
        }
    }
}
```

### `NovaBusinessSystem.DTOs/Loyalty DTOs/PointsTransactionResultDTO.cs`

```cs
namespace NovaBusinessSystem.DTOs
{

    public class PointsTransactionResultDTO
    {
        public string CustomerName { get; private set; } = string.Empty;
        public int PreviousPoints { get; private set; }
        public int Points { get; private set; }
        public int NewBalance { get; private set; }

        public PointsTransactionResultDTO(
            string customerName,
            int previousPoints,
            int points ,
            int newBalance
            
            )
        {
            this.CustomerName = customerName;
            this.PreviousPoints = previousPoints;
            this.Points = points;
            this.NewBalance = newBalance ; 

        }
    }
}
```

### `NovaBusinessSystem.DTOs/Loyalty DTOs/TopLoyaltyCustomerDTO.cs`

```cs
namespace NovaBusinessSystem.DTOs
{


    public class TopLoyaltyCustomerDTO
    {
        public long Rank { get; }
        public string CustomerName { get; }
        public int Points { get; }
        public string Level { get; }

        public TopLoyaltyCustomerDTO(
            long rank,
            string customerName,
            int points,
            string level)
        {
            this.Rank = rank;
            this.CustomerName = customerName;
            this.Points = points;
            this.Level = level;
        }
    }
}
```

### `NovaBusinessSystem.DTOs/Prodcuts DTOs/Inventory Management DTOs/AddStockResultDTO.cs`

```cs
namespace NovaBusinessSystem.DTOs.Products.Inventory
{
    public class AddStockResultDTO
    {
        public int ProductID { get; private set; }
        public string ProductName { get; private set; }
        public int PreviousStock { get; private set; }
        public int AddedStock { get; private set; }
        public int NewStock { get; private set; }

        public AddStockResultDTO(
            int productID,
            string productName,
            int previousStock,
            int addedStock,
            int newStock)
        {
            this.ProductID = productID;
            this.ProductName = productName;
            this.PreviousStock = previousStock;
            this.AddedStock = addedStock;
            this.NewStock = newStock;
        }
    }
}
```

### `NovaBusinessSystem.DTOs/Prodcuts DTOs/Inventory Management DTOs/AdjustStockResultDTO.cs`

```cs
namespace NovaBusinessSystem.DTOs.Products.Inventory
{
    public class AdjustStockResultDTO
    {
        public int ProductID { get; private set; }
        public string ProductName { get; private set; }
        public int PreviousStock { get; private set; }
        public int ActualStock { get; private set; }
        public int Adjustment { get; private set; }

        public AdjustStockResultDTO(
            int productID,
            string productName,
            int previousStock,
            int actualStock,
            int adjustment)
        {
            this.ProductID = productID;
            this.ProductName = productName;
            this.PreviousStock = previousStock;
            this.ActualStock = actualStock;
            this.Adjustment = adjustment;
        }
    }
}
```

### `NovaBusinessSystem.DTOs/Prodcuts DTOs/Inventory Management DTOs/InventoryValueDTO.cs`

```cs
namespace NovaBusinessSystem.DTOs.Products.Inventory
{
    public class InventoryValueDTO
    {
        public int TotalProducts { get; private set; }
        public int TotalStockUnits { get; private set; }
        public decimal TotalInventoryValue { get; private set; }
        public decimal AverageProductPrice { get; private set; }
        public decimal AverageStock { get; private set; }
        public string MostValuableStock { get; private set; }
        public decimal StockValue { get; private set; }

        public InventoryValueDTO(
            int totalProducts,
            int totalStockUnits,
            decimal totalInventoryValue,
            decimal averageProductPrice,
            decimal averageStock,
            string mostValuableStock,
            decimal stockValue)
        {
            this.TotalProducts = totalProducts;
            this.TotalStockUnits = totalStockUnits;
            this.TotalInventoryValue = totalInventoryValue;
            this.AverageProductPrice = averageProductPrice;
            this.AverageStock = averageStock;
            this.MostValuableStock = mostValuableStock;
            this.StockValue = stockValue;
        }
    }
}
```

### `NovaBusinessSystem.DTOs/Prodcuts DTOs/Inventory Management DTOs/LowStockProductDTO.cs`

```cs
namespace NovaBusinessSystem.DTOs.Products.Inventory
{
    public class LowStockProductDTO
    {
        public int ProductID { get; private set; }
        public string ProductName { get; private set; }
        public string Category { get; private set; }
        public int StockQuantity { get; private set; }
        public string Status { get; private set; }

        public LowStockProductDTO(
            int productID,
            string productName,
            string category,
            int stockQuantity,
            string status)
        {
            this.ProductID = productID;
            this.ProductName = productName;
            this.Category = category;
            this.StockQuantity = stockQuantity;
            this.Status = status;
        }
    }
}
```

### `NovaBusinessSystem.DTOs/Prodcuts DTOs/Inventory Management DTOs/OutOfStockProductDTO.cs`

```cs
namespace NovaBusinessSystem.DTOs.Products.Inventory
{
    public class OutOfStockProductDTO
    {

        public int ProductID { get; private set; }
        public string ProductName { get; private set; }
        public string Category { get; private set; }
        public string Status { get; private set; }

        public OutOfStockProductDTO(
            int productID,
            string productName,
            string category,
            string status)
        {
            this.ProductID = productID;
            this.ProductName = productName;
            this.Category = category;
            this.Status = status;
        }
    }
}
```

### `NovaBusinessSystem.DTOs/Prodcuts DTOs/Inventory Management DTOs/ProductStockDTO.cs`

```cs
namespace NovaBusinessSystem.DTOs.Products.Inventory
{
    public class ProductStockDTO
    {
        public int ProductID { get; private set; }
        public string ProductName { get; private set; }
        public string Category { get; private set; }
        public decimal Price { get; private set; }
        public int StockQuantity { get; private set; }
        public decimal StockValue { get; private set; }
        public string Status { get; private set; }

        public ProductStockDTO(
            int productID,
            string productName,
            string category,
            decimal price,
            int stockQuantity,
            decimal stockValue,
            string status)
        {
            this.ProductID = productID;
            this.ProductName = productName;
            this.Category = category;
            this.Price = price;
            this.StockQuantity = stockQuantity;
            this.StockValue = stockValue;
            this.Status = status;
        }
    }
}
```

### `NovaBusinessSystem.DTOs/Prodcuts DTOs/Inventory Management DTOs/RemoveStockResultDTO.cs`

```cs
namespace NovaBusinessSystem.DTOs.Products.Inventory
{
    public class RemoveStockResultDTO
    {
        public int ProductID { get; private set; }
        public string ProductName { get; private set; }
        public int PreviousStock { get; private set; }
        public int RemovedStock { get; private set; }
        public int NewStock { get; private set; }

        public RemoveStockResultDTO(
            int productID,
            string productName,
            int previousStock,
            int removedStock,
            int newStock)
        {
            this.ProductID = productID;
            this.ProductName = productName;
            this.PreviousStock = previousStock;
            this.RemovedStock = removedStock;
            this.NewStock = newStock;
        }
    }
}
```

### `NovaBusinessSystem.DTOs/Prodcuts DTOs/Product DTOs/ProductDTO.cs`

```cs
namespace NovaBusinessSystem.DTOs.Products
{
    public class ProductDTO
    {
        public int ProductID { get; private set; }
        public string ProductName { get; private set; }
        public string Category { get; private set; }
        public decimal Price { get; private set; }
        public int StockQuantity { get; private set; }
        public string Status { get; private set; }

        public ProductDTO(
            int productID,
            string productName,
            string category,
            decimal price,
            int stockQuantity,
            string status)
        {
            this.ProductID = productID;
            this.ProductName = productName;
            this.Category = category;
            this.Price = price;
            this.StockQuantity = stockQuantity;
            this.Status = status;
        }
    }
}
```

### `NovaBusinessSystem.DTOs/Prodcuts DTOs/Product DTOs/ProductRequestDTO.cs`

```cs
namespace NovaBusinessSystem.DTOs.Products
{
    public class ProductRequestDTO
    {
        public string ProductName { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string Status { get; set; }

        public ProductRequestDTO(
            string productName,
            string category,
            decimal price,
            int stockQuantity,
            string status)
        {
            this.ProductName = productName;
            this.Category = category;
            this.Price = price;
            this.StockQuantity = stockQuantity;
            this.Status = status;
        }
    }

}
```

### `NovaBusinessSystem.DTOs/Prodcuts DTOs/Product DTOs/ProductUpdateDTO.cs`

```cs
namespace NovaBusinessSystem.DTOs.Products
{
    public class ProductUpdateDTO
    {
        public string ProductName { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }

        public ProductUpdateDTO(
            string productName,
            string category,
            decimal price,
            string status)
        {
            this.ProductName = productName;
            this.Category = category;
            this.Price = price;
            this.Status = status;
        }
    }
}
```

### `NovaBusinessSystem.DTOs/Prodcuts DTOs/Product Sales Analysis DTOs/ProductSalesHistoryDTO.cs`

```cs

namespace NovaBusinessSystem.DTOs.Products.Sales
{
    public class ProductSalesHistoryDTO
    {
        public int SaleID { get; private set; }
        public string SaleDate { get; private set; }
        public string CustomerName { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public string Status { get; private set; }

        public ProductSalesHistoryDTO(
            int saleID,
            string saleDate,
            string customerName,
            int quantity,
            decimal unitPrice,
            string status)
        {
            SaleID = saleID;
            SaleDate = saleDate;
            CustomerName = customerName;
            Quantity = quantity;
            UnitPrice = unitPrice;
            Status = status;
        }
    }
}
```

### `NovaBusinessSystemPL/Helpers/ConsoleHelper.cs`

```cs
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
```

### `NovaBusinessSystemPL/Helpers/InputHelper.cs`

```cs
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
```

### `NovaBusinessSystemPL/Moduls/Customers Module/CustomersPL.cs`

```cs
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
```

### `NovaBusinessSystemPL/Moduls/Customers Module/Loyalty/LoyaltyMenu.cs`

```cs
using NovaBusinessSystem.Helpers;
using NovaBusinessSystem.Enumeration;
using NovaBusinessSystemPL.Modules.Customers;

namespace NovaBusinessSystem.Modules.Customers.Loyalty
{

    public class LoyaltyMenu
    {

        private static void _PrintMenuLoyaltyPoints()
        {
            System.Console.WriteLine("\n\n\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}╔══════════════════════════════════════════╗\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║            ⭐ LOYALTY POINTS             ║\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}╠══════════════════════════════════════════╣\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║                                          ║\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║  1. View Customer Points                 ║\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║  2. Add Points                           ║\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║  3. Redeem Points                        ║\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║  4. Top Loyalty Customers                ║\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║  5. Loyalty Statistics                   ║\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║                                          ║\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║  0. 🔙 Back                              ║\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}╚══════════════════════════════════════════╝\n\n\n");


        }

        public static async Task StartUpLoyaltyPointsSection()
        {
            while (true)
            {

                Console.Clear();
                _PrintMenuLoyaltyPoints();

                Console.Write($"{ConsoleHelper.GenarateTabs(7)}Select: ");
                byte choice = 0;
                while (!byte.TryParse(Console.ReadLine(), out choice) || choice > 5)
                    Console.Write($"{ConsoleHelper.GenarateTabs(7)}Invalid Choive Select another choice : ");

                switch ((Enumerations.EnChoicesLoyaltyPoints)choice)
                {
                    case Enumerations.EnChoicesLoyaltyPoints._kVIEW_CUSTOMER_POINTS:
                        {
                            await LoyaltyOperations.ViewCustomerPointsAsync();
                            break;
                        }

                    case Enumerations.EnChoicesLoyaltyPoints._kBACK:
                        {
                            await CustomersPL.StartUpCustomersModule();
                            break;
                        }

                    case Enumerations.EnChoicesLoyaltyPoints._kADD_POINTS:
                        {
                            await LoyaltyOperations.AddPointsAsync();
                            break;
                        }

                    case Enumerations.EnChoicesLoyaltyPoints._kREDEEM_POINTS:
                        {
                            await LoyaltyOperations.RedeemPointsAsync();
                            break;
                        }

                    case Enumerations.EnChoicesLoyaltyPoints._kTOP_LOYALTY_CUSTOMERS:
                        {
                            await LoyaltyOperations.GetTopLoyaltyCustomersAsync();
                            break;

                        }

                    case Enumerations.EnChoicesLoyaltyPoints._kLOYALTY_STATISTICS:
                        {
                            await LoyaltyOperations.GetLoyaltyStatisticsAsync();
                            break;
                        }
                }


                Console.WriteLine($"\n\n{ConsoleHelper.GenarateTabs(7)}Press any key to continue...");
                Console.ReadKey();
            }
        }



    }
}
```

### `NovaBusinessSystemPL/Moduls/Customers Module/Loyalty/LoyaltyOperations.cs`

```cs

using System.Net.Http.Json;
using NovaBusinessSystem.DTOs;
using NovaBusinessSystem.Helpers;

namespace NovaBusinessSystem.Modules.Customers.Loyalty
{

    public class LoyaltyOperations
    {


        public static async Task ViewCustomerPointsAsync()
        {
            try
            {
                int id = InputHelper.ReadTheID("🔎 GET CUSTOMER BY ID" , "Enter Customer ID: ");
                System.Console.WriteLine("\n\n\n");

                HttpClient httpClient = new HttpClient();

                httpClient.BaseAddress =
                    new Uri("http://localhost:5276/api/Loyalty/");

                var response = await httpClient.GetAsync($"{id}");


                if (response.IsSuccessStatusCode)
                {
                    var jsonCustomer =
                        await response.Content.ReadFromJsonAsync<CustomerPointsDTO>();

                    if (jsonCustomer is not null)
                    {
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}╔══════════════════════════════════════════╗\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}║             ⭐ CUSTOMER POINTS           ║\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}╠══════════════════════════════════════════╣\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}║ Customer ID    : {jsonCustomer.CustomerID,-24}║\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}║ Customer Name  : {jsonCustomer.CustomerName,-24}║\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}║ Current Points : {jsonCustomer.CurrentPoints,-24}║\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}║ Loyalty Level  : {jsonCustomer.LoyaltyLevel,-24}║\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}╚══════════════════════════════════════════╝\n");
                    }
                }
                else
                {


                    if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        System.Console.Write($"{ConsoleHelper.GenarateTabs(7)}");
                        Console.Write(await response.Content.ReadAsStringAsync());
                    }
                }
            }
            catch (Exception ex)
            {
                ConsoleHelper.ShowNotFoundMessage("❌ NOT FOUND", ex.Message, "Customer could not be found.");
            }
        }

        public static async Task AddPointsAsync()
        {

            try
            {
                int ID =   InputHelper.ReadTheID("🔎 GET CUSTOMER BY ID" , "Enter Customer ID: ");

                if (ID > 0)
                {

                    int pointsToAdd = 0;

                    System.Console.WriteLine("\n\n");
                    ConsoleHelper.PrintHeader("⭐ ADD POINTS", 7);
                    System.Console.WriteLine("\n\n");
                    System.Console.Write($"{ConsoleHelper.GenarateTabs(7)}Points To Add  : ");

                    while (!int.TryParse(Console.ReadLine(), out pointsToAdd) || pointsToAdd <= 0)
                        System.Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}Invalid Data Try Add valid points : ");

                    HttpClient httpClient = new HttpClient();

                    httpClient.BaseAddress = new Uri("http://localhost:5276/api/Loyalty/");

                    var respone = await httpClient.PostAsync($"{ID}/{pointsToAdd}", null);

                    if (respone.IsSuccessStatusCode)
                    {

                        var content = await respone.Content.ReadFromJsonAsync<PointsTransactionResultDTO>();
                        System.Console.WriteLine("\n\n");

                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}╔══════════════════════════════════════════╗\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}║          ✅ POINTS ADDED                 ║\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}╠══════════════════════════════════════════╣\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}║ Customer      : {content.CustomerName,-25}║\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}║ Previous      : {content.PreviousPoints,-25}║\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}║ Added         : {content.Points,-25}║\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}║ New Balance   : {content.NewBalance,-25}║\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}╚══════════════════════════════════════════╝\n");

                        return;

                    }

                    ConsoleHelper.ShowNotFoundMessage("❌ POINTS DEDUCTED", $"{await respone.Content.ReadAsStringAsync()}");
                }
                else
                    ConsoleHelper.ShowNotFoundMessage("❌ NOT FOUND", "Customer could not be found.");
            }
            catch (Exception ex)
            {
                ConsoleHelper.ShowNotFoundMessage("❌ NOT FOUND", ex.Message, "Customer could not be found.");
            }
        }

        public static async Task RedeemPointsAsync()
        {

            try
            {
                int ID = InputHelper.ReadTheID("🔎 GET CUSTOMER BY ID" , "Enter Customer ID: ");

                if (ID > 0)
                {

                    int pointsToAdd = 0;
                    System.Console.WriteLine("\n\n");
                    ConsoleHelper.PrintHeader("🎁 REDEEM POINTS", 7);
                    System.Console.WriteLine("\n\n");
                    System.Console.Write($"{ConsoleHelper.GenarateTabs(7)}Points To Redeem  : ");

                    while (!int.TryParse(Console.ReadLine(), out pointsToAdd) || pointsToAdd <= 0)
                        System.Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}Invalid Data Try Add valid points : ");

                    HttpClient httpClient = new HttpClient();

                    httpClient.BaseAddress = new Uri("http://localhost:5276/api/Loyalty/");

                    var respone = await httpClient.PatchAsync($"{ID}/{pointsToAdd}", null);

                    if (respone.IsSuccessStatusCode)
                    {
                        var content = await respone.Content.ReadFromJsonAsync<PointsTransactionResultDTO>();

                        System.Console.WriteLine("\n\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}╔══════════════════════════════════════════╗\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}║            ✅ POINTS REDEEMED            ║\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}╠══════════════════════════════════════════╣\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}║ Customer      : {content.CustomerName,-25}║\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}║ Previous      : {content.PreviousPoints,-25}║\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}║ Redeemed      : {content.Points,-25}║\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}║ New Balance   : {content.NewBalance,-25}║\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}╚══════════════════════════════════════════╝\n");

                        return;

                    }

                    ConsoleHelper.ShowNotFoundMessage("❌ INSUFFICIENT POINTS", $"{await respone.Content.ReadAsStringAsync()}");
                }
                else
                    ConsoleHelper.ShowNotFoundMessage("❌ NOT FOUND", "Customer could not be found.");
            }
            catch (Exception ex)
            {
                ConsoleHelper.ShowNotFoundMessage("❌ NOT FOUND", ex.Message, "Customer could not be found.");
            }
        }

        public static async Task GetTopLoyaltyCustomersAsync()
        {

            try
            {

                HttpClient httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("http://localhost:5276/api/Loyalty/");

                var respone = await httpClient.GetAsync("TopCustomers/");
                Console.Clear();

                ConsoleHelper.PrintHeader("🏆 TOP LOYALTY CUSTOMERS", 7);
                if (respone.IsSuccessStatusCode)
                {
                    var topLoyaltyCustomerPoints = await respone.Content.ReadFromJsonAsync<List<TopLoyaltyCustomerDTO>>();
                    if (topLoyaltyCustomerPoints is not null)
                    {
                        System.Console.WriteLine($"\n\n{ConsoleHelper.GenarateTabs(6)}{"Rank",-15} {"Customer Name",-25} {"Points",-15} {"Level",-15}");
                        System.Console.WriteLine($"{ConsoleHelper.GenarateTabs(6)}{new string('-', 70)}");


                        foreach (var item in topLoyaltyCustomerPoints)
                            System.Console.WriteLine($"{ConsoleHelper.GenarateTabs(6)}{item.Rank,-15} {item.CustomerName,-25} {item.Points,-15} {item.Level,-15}");

                        System.Console.WriteLine($"{ConsoleHelper.GenarateTabs(6)}{new string('-', 70)}");

                    }

                    return;
                }

                ConsoleHelper.ShowNotFoundMessage("⚠️ NO DATA FOUND", $"{await respone.Content.ReadAsStringAsync()}");

            }
            catch (Exception ex)
            {
                ConsoleHelper.ShowNotFoundMessage("❌ SYSTEM ERROR", ex.Message, "your request. Please try again.");
            }

        }

        public static async Task GetLoyaltyStatisticsAsync()
        {

            try
            {

                HttpClient httpClient = new HttpClient();
                //http://localhost:5276/api/CustomersLoyalty/Statistics
                httpClient.BaseAddress = new Uri("http://localhost:5276/api/Loyalty/");

                var respone = await httpClient.GetAsync("Statistics/");
                Console.Clear();
                System.Console.WriteLine("\n\n\n");
                ConsoleHelper.PrintHeader("⭐ LOYALTY STATISTICS", 7);

                if (respone.IsSuccessStatusCode)
                {
                    var loyaltyStatistics = await respone.Content.ReadFromJsonAsync<LoyaltyStatisticsDTO>();

                    if (loyaltyStatistics is not null)
                    {
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}║ Total Loyalty Points : {loyaltyStatistics.TotalLoyaltyPoints,-18}║\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}║ Minimum Points       : {loyaltyStatistics.MinimumPoints,-18}║\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}║ Maximum Points       : {loyaltyStatistics.MaximumPoints,-18}║\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}║ Average Points       : {loyaltyStatistics.AveragePoints,-18:F2}║\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}║ Diamond Customers    : {loyaltyStatistics.DiamondCustomers,-18}║\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}║ Platinum Customers   : {loyaltyStatistics.PlatinumCustomers,-18}║\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}║ Gold Customers       : {loyaltyStatistics.GoldCustomers,-18}║\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}║ Silver Customers     : {loyaltyStatistics.SilverCustomers,-18}║\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}║ Bronze Customers     : {loyaltyStatistics.BronzeCustomers,-18}║\n");
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}╚══════════════════════════════════════════╝\n");
                    }

                    return;
                }

                ConsoleHelper.ShowNotFoundMessage("⚠️ NO DATA FOUND", $"{await respone.Content.ReadAsStringAsync()}");

            }
            catch (Exception ex)
            {
                ConsoleHelper.ShowNotFoundMessage("❌ SYSTEM ERROR", ex.Message, "your request. Please try again.");
            }

        }

    }
}
```

### `NovaBusinessSystemPL/Moduls/Customers Module/Purchases/PurchasesMenu.cs`

```cs

using NovaBusinessSystem.Helpers;
using NovaBusinessSystem.Enumeration;
using NovaBusinessSystemPL.Modules.Customers;

namespace NovaBusinessSystem.Modules.Customers.Purchases
{
    public static class PurchasesMenu
    {
        private static void _PrintMenuPurchasesCustomers()
        {
            System.Console.WriteLine("\n\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}╔══════════════════════════════════════════╗\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║            🛒 CUSTOMER PURCHASES         ║\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}╠══════════════════════════════════════════╣\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║                                          ║\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║  1. Purchase History                     ║\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║  2. Customer Spending Summary            ║\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║  3. Customer Favorite Products           ║\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║  4. Customer Monthly Purchases           ║\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║  5. Customer Ranking                     ║\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║                                          ║\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║  0. 🔙 Back                              ║\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}╚══════════════════════════════════════════╝\n\n");

        }

        public static async Task StartupPurchasesCustomers()
        {
            while (true)
            {
                Console.Clear();
                _PrintMenuPurchasesCustomers();
                Console.Write($"{ConsoleHelper.GenarateTabs(7)}Select: ");
                byte choice = 0;
                while (!byte.TryParse(Console.ReadLine(), out choice) || choice > 5)
                    Console.Write($"{ConsoleHelper.GenarateTabs(7)}Incorrect choice try agian : ");

                switch ((Enumerations.EnChoicesCustomerPurchases)choice)
                {
                    case Enumerations.EnChoicesCustomerPurchases._kBACK:
                        {
                            await CustomersPL.StartUpCustomersModule();
                            break;
                        }

                    case Enumerations.EnChoicesCustomerPurchases._kPURCHASE_HISTORY:
                        {
                            await PurchasesOperations.GetPurchaseHistory();
                            break;
                        }

                    case Enumerations.EnChoicesCustomerPurchases._kCUSTOMER_SPENDING_SUMMARY:
                        {
                            await PurchasesOperations.GetCustomerSpendingSummary();
                            break;
                        }

                    case Enumerations.EnChoicesCustomerPurchases._kCUSTOMER_MONTHLY_PURCHASES:
                        {
                            await PurchasesOperations.GetCustomerMonthlyPurchases();
                            break;
                        }

                    case Enumerations.EnChoicesCustomerPurchases._kCUSTOMER_RANKING:
                        {
                            await PurchasesOperations.GetCustomersRankingAsync();
                            break;
                        }

                }


                Console.WriteLine($"\n\n{ConsoleHelper.GenarateTabs(7)}Press any key to continue...");
                Console.ReadKey();
            }
        }

    }
}
```

### `NovaBusinessSystemPL/Moduls/Customers Module/Purchases/PurchasesOperations.cs`

```cs
using System.Net.Http.Json;
using NovaBusinessSystem.Helpers;
using NovaBusinessSystem.DTOs;
using NovaBusinessSystem.BL.Customers;

namespace NovaBusinessSystem.Modules.Customers.Purchases
{

    public static class PurchasesOperations
    {
       
        public static async Task GetPurchaseHistory()
        {
            try
            {
                int ID =  InputHelper.ReadTheID("🔎 GET CUSTOMER BY ID" , "Enter Customer ID: ");

                if (ID > 0)
                {
                    ConsoleHelper.PrintHeader("🛒 PURCHASE HISTORY", 7);
                    System.Console.WriteLine("\n\n");
                    CustomersBL? customer = CustomersBL.Find(ID)!;

                    if (customer is not null)
                    {
                        HttpClient httpClient = new HttpClient();

                        httpClient.BaseAddress = new Uri("http://localhost:5276/api/CustomersPurchases/");

                        var respone = await httpClient.GetAsync($"{ID}");

                        if (respone.IsSuccessStatusCode)
                        {
                            var L_PurchaseHistoryCustomer = await respone.Content.ReadFromJsonAsync<List<CustomerPurchaseDTO>>();

                            if (!L_PurchaseHistoryCustomer!.Any() || L_PurchaseHistoryCustomer!.Count == 0)
                            {
                                ConsoleHelper.ShowNotFoundMessage("⚠️ NO PURCHASE HISTORY ", "This customer has no purchase history.");
                                return;
                            }

                            Console.WriteLine($"{ConsoleHelper.GenarateTabs(5)}{"Sale ID",-15} {"Date",-20} {"Amount",-15} {"Payment",-15} {"Status",-15}");
                            Console.Write($"{ConsoleHelper.GenarateTabs(5)}{new string('-', 80)}{Environment.NewLine}");

                            foreach (var item in L_PurchaseHistoryCustomer!)
                                Console.WriteLine($"{ConsoleHelper.GenarateTabs(5)}{item.SaleID,-15} {item.SaleDate,-20} {item.Amount.ToString("C"),-15} {item.PaymentMethod,-15} {item.Status,-15}");

                            Console.Write($"{ConsoleHelper.GenarateTabs(5)}{new string('-', 80)}{Environment.NewLine}");

                            return;
                        }

                        ConsoleHelper.ShowNotFoundMessage("⚠️ NO DATA FOUND", $"{await respone.Content.ReadAsStringAsync()}");

                    }

                    else
                        ConsoleHelper.ShowNotFoundMessage("❌ NOT FOUND", "Customer could not be found.");

                }
                else
                    ConsoleHelper.ShowNotFoundMessage("❌ ERROR", "Invalid Data Customer ID");
            }

            catch (Exception ex)
            {
                ConsoleHelper.ShowNotFoundMessage("❌ SYSTEM ERROR", ex.Message, "your request. Please try again.");

            }
        }

        public static async Task GetCustomerSpendingSummary()
        {
            try
            {
                int ID =  InputHelper.ReadTheID("🔎 GET CUSTOMER BY ID" , "Enter Customer ID: ");

                if (ID > 0)
                {
                    ConsoleHelper.PrintHeader("💰 CUSTOMER SPENDING", 7);
                    System.Console.WriteLine("\n\n");
                    CustomersBL? customer = CustomersBL.Find(ID)!;

                    if (customer is not null)
                    {
                        HttpClient httpClient = new HttpClient();

                        httpClient.BaseAddress = new Uri("http://localhost:5276/api/CustomersPurchases/");

                        var respone = await httpClient.GetAsync($"{ID}/SpendingSummary");
                        if (respone.IsSuccessStatusCode)
                        {
                            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}{"Customer ",-15} : {customer?.FullName}");

                            var customerSpendingSummary = await respone.Content.ReadFromJsonAsync<CustomerSpendingSummaryDTO>();

                            if (customerSpendingSummary is null)
                            {
                                ConsoleHelper.ShowNotFoundMessage("⚠️ NO PURCHASE HISTORY ", "This customer has no purchase history.");
                                return;
                            }
                            System.Console.WriteLine("\n\n");
                            Console.Write($"{ConsoleHelper.GenarateTabs(7)}╔══════════════════════════════════════════╗\n");
                            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║       💰 CUSTOMER SPENDING SUMMARY       ║\n");
                            Console.Write($"{ConsoleHelper.GenarateTabs(7)}╠══════════════════════════════════════════╣\n");
                            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║ Total Orders   : {customerSpendingSummary.TotalOrders,-24}║\n");
                            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║ Completed      : {customerSpendingSummary.Completed,-24}║\n");
                            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║ Pending        : {customerSpendingSummary.Pending,-24}║\n");
                            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║ Cancelled      : {customerSpendingSummary.Cancelled,-24}║\n");
                            Console.Write($"{ConsoleHelper.GenarateTabs(7)}╠══════════════════════════════════════════╣\n");
                            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║ Total Spent    : {"$" + customerSpendingSummary.TotalSpent,-24}║\n");
                            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║ Average Order  : {"$" + customerSpendingSummary.AverageOrder,-24}║\n");
                            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║ Largest Order  : {"$" + customerSpendingSummary.LargestOrder,-24}║\n");
                            Console.Write($"{ConsoleHelper.GenarateTabs(7)}╠══════════════════════════════════════════╣\n");
                            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║ First Purchase : {customerSpendingSummary.FirstPurchase,-24}║\n");
                            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║ Last Purchase  : {customerSpendingSummary.LastPurchase,-24}║\n");
                            Console.Write($"{ConsoleHelper.GenarateTabs(7)}╚══════════════════════════════════════════╝\n");
                            return;
                        }

                        ConsoleHelper.ShowNotFoundMessage("⚠️ NO DATA FOUND", $"{await respone.Content.ReadAsStringAsync()}");

                    }

                    else
                        ConsoleHelper.ShowNotFoundMessage("❌ NOT FOUND", "Customer could not be found.");

                }
                else
                    ConsoleHelper.ShowNotFoundMessage("❌ ERROR", "Invalid Data Customer ID");
            }

            catch (Exception ex)
            {
                ConsoleHelper.ShowNotFoundMessage("❌ SYSTEM ERROR", ex.Message, "your request. Please try again.");

            }
        }

        public static async Task GetCustomerMonthlyPurchases()
        {
            try
            {

                Console.Clear();
                System.Console.WriteLine("\n\n\n");
                ConsoleHelper.PrintHeader("📅 MONTHLY PURCHASE SUMMARY", 7);
                System.Console.WriteLine("\n\n");

                HttpClient httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("http://localhost:5276/api/CustomersPurchases/");

                var respone = await httpClient.GetAsync($"MonthlyPurchases");
                if (respone.IsSuccessStatusCode)
                {

                    var monthlyPurchases = await respone.Content.ReadFromJsonAsync<List<MonthlyPurchaseDTO>>();
                    if (monthlyPurchases == null || !monthlyPurchases.Any())
                    {
                        ConsoleHelper.ShowNotFoundMessage(
                            "⚠️ NO PURCHASE DATA",
                            "No monthly purchase data found.");

                        return;
                    }
                    System.Console.WriteLine("\n\n");
                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}{"Month",-20} {"Orders",-15} {"Total Spent",-25}");

                    Console.Write($"{ConsoleHelper.GenarateTabs(7)}{new string('-', 55)}{Environment.NewLine}");

                    foreach (var item in monthlyPurchases)
                    {
                        Console.WriteLine(
                            $"{ConsoleHelper.GenarateTabs(7)}{item.Month,-20} {item.Orders,-15} {item.TotalSpent.ToString("C"),-25}");
                    }

                    Console.Write($"{ConsoleHelper.GenarateTabs(7)}{new string('-', 55)}{Environment.NewLine}");

                    return;
                }

                ConsoleHelper.ShowNotFoundMessage("⚠️ NO DATA FOUND", $"{await respone.Content.ReadAsStringAsync()}");


            }

            catch (Exception ex)
            {
                ConsoleHelper.ShowNotFoundMessage("❌ SYSTEM ERROR", ex.Message, "your request. Please try again.");

            }
        }

        public static async Task GetCustomersRankingAsync()
        {
            try
            {

                Console.Clear();
                System.Console.WriteLine("\n\n\n");
                ConsoleHelper.PrintHeader("🏆 CUSTOMER RANKING", 7);
                System.Console.WriteLine("\n\n");

                HttpClient httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("http://localhost:5276/api/CustomersPurchases/");

                var respone = await httpClient.GetAsync($"CustomersRanking");
                if (respone.IsSuccessStatusCode)
                {

                    var customersRanking = await respone.Content.ReadFromJsonAsync<List<CustomerRankingDTO>>();
                    if (customersRanking == null || !customersRanking.Any())
                    {
                        ConsoleHelper.ShowNotFoundMessage(
                            "⚠️ NO PURCHASE DATA",
                            "No monthly purchase data found.");

                        return;
                    }
                    System.Console.WriteLine("\n\n");
                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(6)}{"Rank",-15} {"Customer",-30} {"Orders",-10} {"Spending",-25}");

                    Console.Write($"{ConsoleHelper.GenarateTabs(6)}{new string('-', 70)}{Environment.NewLine}");

                    foreach (var item in customersRanking)
                    {
                        Console.WriteLine(
                            $"{ConsoleHelper.GenarateTabs(6)}{item.Rank,-15} {item.FullName,-30} {item.Orders,-10} {item.Spending.ToString("C"),-25}");
                    }

                    Console.Write($"{ConsoleHelper.GenarateTabs(6)}{new string('-', 70)}{Environment.NewLine}");

                    return;
                }

                ConsoleHelper.ShowNotFoundMessage("⚠️ NO DATA FOUND", $"{await respone.Content.ReadAsStringAsync()}");


            }

            catch (Exception ex)
            {
                ConsoleHelper.ShowNotFoundMessage("❌ SYSTEM ERROR", ex.Message, "your request. Please try again.");

            }
        }
    
    }
}
```

### `NovaBusinessSystemPL/Moduls/Customers Module/Report/ReportMenu.cs`

```cs
using NovaBusinessSystem.Helpers;
using NovaBusinessSystem.Enumeration;
using NovaBusinessSystemPL.Modules.Customers;

namespace NovaBusinessSystem.Modules.Customers.Reports
{

    public class ReportMenu
    {
        private static void _PrintReportMenu()
        {
            System.Console.WriteLine("\n\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}╔══════════════════════════════════════════╗\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║             📊 CUSTOMER REPORT           ║\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}╠══════════════════════════════════════════╣\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║                                          ║\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║  1. 👥 Customer Status Summary           ║\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║  2. 🌍 Customers By City                 ║\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║  3. ⭐ Loyalty Summary                   ║\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║  4. 📅 Registration Summary              ║\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║  5. 📈 Customer Growth                   ║\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║  6. 🔥 Customer Activity Report          ║\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║                                          ║\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}║  0. 🔙 Back                              ║\n");
            Console.Write($"{ConsoleHelper.GenarateTabs(7)}╚══════════════════════════════════════════╝\n");
        }


        public static async Task StartupReportSection()
        {
            while (true)
            {
                Console.Clear();
                _PrintReportMenu();
                Console.Write($"\n\n{ConsoleHelper.GenarateTabs(7)}Select: ");
                byte choice = 0;
                while (!byte.TryParse(Console.ReadLine(), out choice) || choice > 6)
                    Console.Write($"{ConsoleHelper.GenarateTabs(7)}Incorrect choice try agian : ");

                switch ((Enumerations.EnChoicesCustomerReport)choice)
                {

                    case Enumerations.EnChoicesCustomerReport._kBACK:
                        {
                            await CustomersPL.StartUpCustomersModule();
                            break;
                        }

                    case Enumerations.EnChoicesCustomerReport._kCUSTOMER_STATUS_SUMMARY:
                        {
                            await ReportOperations.GetCustomerStatusSummaryAsync();
                            break;
                        }

                    case Enumerations.EnChoicesCustomerReport._kCUSTOMERS_BY_CITY:
                        {
                            await ReportOperations.GetCustomersByCityAsync();
                            break;
                        }

                    case Enumerations.EnChoicesCustomerReport._kLOYALTY_SUMMARY:
                        {
                            await ReportOperations.GetLoyaltySummaryReportAsync();
                            break;
                        }

                    case Enumerations.EnChoicesCustomerReport._kREGISTRATION_SUMMARY :
                        {
                            await ReportOperations.GetRegistrationSummaryAsync() ;
                            break;
                        }
                }


                Console.WriteLine($"\n\n{ConsoleHelper.GenarateTabs(7)}Press any key to continue...");
                Console.ReadKey();
            }
        }

    }
}
```

### `NovaBusinessSystemPL/Moduls/Customers Module/Report/ReportOperations.cs`

```cs
using System.Net.Http.Json;
using NovaBusinessSystem.DTOs.Customers.Reports;
using NovaBusinessSystem.Helpers;

namespace NovaBusinessSystem.Modules.Customers.Reports
{
    public class ReportOperations
    {
        public static async Task GetCustomerStatusSummaryAsync()
        {
            try
            {
                System.Console.WriteLine("\n\n");
                ConsoleHelper.PrintHeader("👥 CUSTOMER STATUS", 7);
                System.Console.WriteLine("\n\n");

                HttpClient httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("http://localhost:5276/api/CustomersReport/");

                var respone = await httpClient.GetAsync($"Status");

                if (respone.IsSuccessStatusCode)
                {
                    var L_CustomersStatus =
                                 await respone.Content.ReadFromJsonAsync<List<CustomerStatusDTO>>();

                    if (L_CustomersStatus == null || !L_CustomersStatus.Any())
                    {
                        ConsoleHelper.ShowNotFoundMessage(
                            "⚠️ NO CUSTOMER STATUS DATA",
                            "No customer status data was found.");

                        return;
                    }

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}{"Status",-20} {"Customers",-15}");

                    Console.Write(
                        $"{ConsoleHelper.GenarateTabs(7)}{new string('-', 35)}{Environment.NewLine}");

                    foreach (var item in L_CustomersStatus)
                    {
                        Console.WriteLine(
                            $"{ConsoleHelper.GenarateTabs(7)}{item.Status,-20} {item.Customers,-15}");
                    }

                    Console.Write(
                        $"{ConsoleHelper.GenarateTabs(7)}{new string('-', 35)}{Environment.NewLine}");

                    return;
                }

                ConsoleHelper.ShowNotFoundMessage("⚠️ NO DATA FOUND", $"{await respone.Content.ReadAsStringAsync()}");

            }

            catch (Exception ex)
            {
                ConsoleHelper.ShowNotFoundMessage("❌ SYSTEM ERROR", ex.Message, "your request. Please try again.");

            }
        }

        public static async Task GetCustomersByCityAsync()
        {
            try
            {
                System.Console.WriteLine("\n\n");
                ConsoleHelper.PrintHeader("🌍 CUSTOMERS BY CITY", 7);
                System.Console.WriteLine("\n\n");

                HttpClient httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("http://localhost:5276/api/CustomersReport/");

                var respone = await httpClient.GetAsync($"City");

                if (respone.IsSuccessStatusCode)
                {
                    var L_CustomersByCity =
                        await respone.Content.ReadFromJsonAsync<List<CustomersByCityDTO>>();

                    if (L_CustomersByCity == null || !L_CustomersByCity.Any())
                    {
                        ConsoleHelper.ShowNotFoundMessage(
                            "⚠️ NO CUSTOMER CITY DATA",
                            "No customer city data was found.");

                        return;
                    }

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}{"City",-20} {"Customers",-15}");

                    Console.Write(
                        $"{ConsoleHelper.GenarateTabs(7)}{new string('-', 35)}{Environment.NewLine}");

                    foreach (var item in L_CustomersByCity)
                    {
                        Console.WriteLine(
                            $"{ConsoleHelper.GenarateTabs(7)}{item.City,-20} {item.Customers,-15}");
                    }

                    Console.Write(
                        $"{ConsoleHelper.GenarateTabs(7)}{new string('-', 35)}{Environment.NewLine}");

                    return;
                }

                ConsoleHelper.ShowNotFoundMessage("⚠️ NO DATA FOUND", $"{await respone.Content.ReadAsStringAsync()}");

            }

            catch (Exception ex)
            {
                ConsoleHelper.ShowNotFoundMessage("❌ SYSTEM ERROR", ex.Message, "your request. Please try again.");

            }
        }

        public static async Task GetLoyaltySummaryReportAsync()
        {
            try
            {
                System.Console.WriteLine("\n\n");
                ConsoleHelper.PrintHeader("⭐ LOYALTY SUMMARY", 7);
                System.Console.WriteLine("\n\n");

                HttpClient httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("http://localhost:5276/api/CustomersReport/");

                var respone = await httpClient.GetAsync($"Loyalty");

                if (respone.IsSuccessStatusCode)
                {
                    var L_LoyaltySummary =
                        await respone.Content.ReadFromJsonAsync<List<LoyaltySummaryDTO>>();

                    if (L_LoyaltySummary == null || !L_LoyaltySummary.Any())
                    {
                        ConsoleHelper.ShowNotFoundMessage(
                            "⚠️ NO LOYALTY SUMMARY DATA",
                            "No loyalty summary data was found.");

                        return;
                    }

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}{"Level",-20} {"Customers",-15} {"Total Points",-15}");

                    Console.Write(
                        $"{ConsoleHelper.GenarateTabs(7)}{new string('-', 50)}{Environment.NewLine}");

                    foreach (var item in L_LoyaltySummary)
                    {
                        Console.WriteLine(
                            $"{ConsoleHelper.GenarateTabs(7)}{item.LoyaltyLevel,-20} {item.Customers,-15} {item.TotalPoints,-15}");
                    }

                    Console.Write(
                        $"{ConsoleHelper.GenarateTabs(7)}{new string('-', 50)}{Environment.NewLine}");

                    System.Console.WriteLine($"\n\n{ConsoleHelper.GenarateTabs(7)}Average Points : {(L_LoyaltySummary.Average(x => x.TotalPoints)).ToString("N2")}");
                    return;
                }

                ConsoleHelper.ShowNotFoundMessage("⚠️ NO DATA FOUND", $"{await respone.Content.ReadAsStringAsync()}");

            }

            catch (Exception ex)
            {
                ConsoleHelper.ShowNotFoundMessage("❌ SYSTEM ERROR", ex.Message, "your request. Please try again.");

            }
        }

        public static async Task GetRegistrationSummaryAsync()
        {
            try
            {
                System.Console.WriteLine("\n\n");
                ConsoleHelper.PrintHeader("📅 REGISTRATION SUMMARY", 7);
                System.Console.WriteLine("\n\n");

                HttpClient httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("http://localhost:5276/api/CustomersReport/");

                var respone = await httpClient.GetAsync($"Registration");

                if (respone.IsSuccessStatusCode)
                {
                    var L_RegistrationSummary =
                        await respone.Content.ReadFromJsonAsync<List<RegistrationSummaryDTO>>();

                    if (L_RegistrationSummary == null || !L_RegistrationSummary.Any())
                    {
                        ConsoleHelper.ShowNotFoundMessage(
                            "⚠️ NO REGISTRATION SUMMARY DATA",
                            "No registration summary data was found.");

                        return;
                    }

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}{"Year",-15} {"New Customers",-20}");

                    Console.Write(
                        $"{ConsoleHelper.GenarateTabs(7)}{new string('-', 35)}{Environment.NewLine}");

                    foreach (var item in L_RegistrationSummary)
                    {
                        Console.WriteLine(
                            $"{ConsoleHelper.GenarateTabs(7)}{item.Year,-15} {item.NewCustomers,-20}");
                    }

                    Console.Write(
                        $"{ConsoleHelper.GenarateTabs(7)}{new string('-', 35)}{Environment.NewLine}");

                    return;
                }
                ConsoleHelper.ShowNotFoundMessage("⚠️ NO DATA FOUND", $"{await respone.Content.ReadAsStringAsync()}");

            }

            catch (Exception ex)
            {
                ConsoleHelper.ShowNotFoundMessage("❌ SYSTEM ERROR", ex.Message, "your request. Please try again.");

            }
        }

    }


}
```

### `NovaBusinessSystemPL/Moduls/Employees Module/Employees.cs`

```cs
using System.Data;
using NovaBusinessSystem.BL;
using NovaBusinessSystem.Enumeration;
using Microsoft.Data.SqlClient;

namespace EmployeesPL
{

  public class EmployeesPL
  {


    private static void _ShowNotFoundMessage(string MessageReason, string MessageHeader, string MessageBody)
    {
      Console.WriteLine("\n\n\t\t╔════════════════════════════════════════════════════════════════════════╗");
      Console.WriteLine($"\t\t║                  {MessageHeader}                                 ║");
      Console.WriteLine("\t\t╠════════════════════════════════════════════════════════════════════════╣");
      Console.WriteLine($"\t\t║ {MessageBody,-50}                             ║");
      Console.WriteLine($"\t\t║ Reason: {MessageReason,-50}  ║");
      Console.WriteLine("\t\t╚════════════════════════════════════════════════════════════════════════╝");
    }

    private static void PrintDetail(string label, object? value)
    {
      const int ContentWidth = 50;

      string Text = $"{label,-13} : {value ?? " "}";

      if (Text.Length > ContentWidth)
        Text = Text[..ContentWidth];


      Console.WriteLine($"\t\t║ {Text,-48}║");
    }

    private static void _ShowSccessMessageAndShowInformationEmployee(EmployeesBL informationEmployee, string message)
    {

      int width = 50;
      int contentWidth = width - 2;

      int paddingLeft = (contentWidth - message.Length) / 2;
      int paddingRight = contentWidth - message.Length - paddingLeft - 1;


      Console.WriteLine("\n\n\t\t╔═════════════════════════════════════════════════╗");
      Console.WriteLine($"\t\t║{new string(' ', paddingLeft)}{message}{new string(' ', paddingRight)} ║");
      Console.WriteLine("\t\t╚═════════════════════════════════════════════════╝");

      PrintDetail("ID", informationEmployee.ID);
      PrintDetail("First Name", informationEmployee.FirstName);
      PrintDetail("Last Name", informationEmployee.LastName);
      PrintDetail("Department ID", informationEmployee.DepartmentID);
      PrintDetail("Manager ID", informationEmployee.ManagerID);
      PrintDetail("Job Title", informationEmployee.JobTitle.Trim());
      PrintDetail("Salary", $"{informationEmployee.Salary:N2}");
      PrintDetail("Hire Date", DateTime.Now.ToString("dd/MM/yyyy"));
      PrintDetail("Phone", informationEmployee.Phone);
      PrintDetail("Email", informationEmployee.Email);
      PrintDetail("Status", _GetStatusEmployee(informationEmployee.Status));

      Console.WriteLine("\t\t╚═════════════════════════════════════════════════╝");
    }

    private static void PrintScreenMenuEmployeesModule(out byte ChoiseEmployeesModule)
    {
      System.Console.WriteLine("\n\n\n\n");
      Console.WriteLine("\t\t╔══════════════════════════════════════════╗");
      Console.WriteLine("\t\t║              👨‍💼 EMPLOYEES              ║");
      Console.WriteLine("\t\t╠══════════════════════════════════════════╣");
      Console.WriteLine("\t\t║                                          ║");
      Console.WriteLine("\t\t║  1. 📋 List Employees                    ║");
      Console.WriteLine("\t\t║  2. 🔎 Get Employee By ID                ║");
      Console.WriteLine("\t\t║  3. ➕ Add Employee                      ║");
      Console.WriteLine("\t\t║  4. ✏️  Update Employee                   ║");
      Console.WriteLine("\t\t║  5. 🗑️  Delete Employee                   ║");
      Console.WriteLine("\t\t║  6. 🔍 Search Employees                  ║");
      Console.WriteLine("\t\t║  7. 📊 Employee Report                   ║");
      Console.WriteLine("\t\t║                                          ║");
      Console.WriteLine("\t\t║  0. 🔙 Back                              ║");
      Console.WriteLine("\t\t║                                          ║");
      Console.WriteLine("\t\t╚══════════════════════════════════════════╝");

      System.Console.Write("\n\n\t\tSelect : ");

      while (!Byte.TryParse(Console.ReadLine(), out ChoiseEmployeesModule) || ChoiseEmployeesModule > 7)
        System.Console.Write("\t\tInvalid Choice Employees : ");

    }

    private static void _EmployeesList(string? FullName = null, string? DepartmentName = null, string? JobTitle = null, string? Status = null)
    {

      Console.Clear();
      DataTable DT_AllEmployees = EmployeesBL.GetAllEmployees(FullName, DepartmentName, JobTitle, Status);

      if (DT_AllEmployees is null || DT_AllEmployees.Rows.Count == 0)
      {
        Console.WriteLine("\t\t╔══════════════════════════════════════════╗");
        Console.WriteLine("\t\t║             ❌ NO RESULTS                ║");
        Console.WriteLine("\t\t╠══════════════════════════════════════════╣");
        Console.WriteLine("\t\t║ No employees matched your search.        ║");
        Console.WriteLine("\t\t╚══════════════════════════════════════════╝\n\n");

        return;
      }


      System.Console.WriteLine($"\n\n\t\t {"ID",-10} {"Name",-35} {"Department",-20} {"Job Title",-30} {"Salary",-20} {"Status",-15}");
      System.Console.WriteLine("\t\t" + new string('-', 125));

      foreach (DataRow DR_Employee in DT_AllEmployees.Rows)
      {

        System.Console.WriteLine(
          $"\t\t {Convert.ToInt32(DR_Employee["EmployeeID"]),-10} {DR_Employee["FullName"].ToString(),-35} {DR_Employee["DepartmentName"].ToString(),-20} {DR_Employee["JobTitle"].ToString(),-30} {(Convert.ToDouble(DR_Employee["Salary"])).ToString("C"),-20} {DR_Employee["Status"].ToString(),-15}");
      }

      System.Console.WriteLine("\t\t" + new string('-', 125));

      System.Console.WriteLine($"\n\n\t\tTotal Employees : {DT_AllEmployees.Rows.Count}");

    }

    private static EmployeesBL? _GetEmployeeBy(int EmployeeID)
    {

      EmployeesBL EmployeeInfo = EmployeesBL.FindEmployeeBy(EmployeeID);

      if (EmployeeInfo is not null)
      {
        System.Console.WriteLine("\n\n\n");
        _ShowSccessMessageAndShowInformationEmployee(EmployeeInfo, "EMPLOYEE DETAILS");
        return EmployeeInfo;
      }
      else
      {
        _ShowNotFoundMessage($"Employee with ID {EmployeeID} was not found.", "❌ NOT FOUND", "Employee could not be found.");
      }

      return null;

    }

    private static void ReadInformationEmployees(EmployeesBL NewEmployee)
    {

      Console.Write($"\n\n\t\t{"First Name",-16}: ");

      string? FirstName = Console.ReadLine()!;
      string Test = Console.ReadLine()!;
      
      while (true)
      {
        bool isPass = true;

        if (string.IsNullOrWhiteSpace(FirstName))
          isPass = false;
        else
        {
          foreach (char c in FirstName)
            if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
            {
              isPass = false;
              break;
            }
        }

        if (!isPass)
        {
          Console.Write($"\t\t{"Invalid! First Name",-16}: ");
          FirstName = Console.ReadLine()!;
        }
        else
          break;
      }

      NewEmployee.FirstName = FirstName!;

      Console.Write($"\t\t{"Last Name",-16}: ");

      string? LastName = Console.ReadLine();
      while (true)
      {
        bool isPass = true;

        if (string.IsNullOrWhiteSpace(LastName))
          isPass = false;
        else
        {
          foreach (char c in LastName)
            if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
            {
              isPass = false;
              break;
            }
        }

        if (!isPass)
        {
          Console.Write($"\t\t{"Invalid! Last Name",-16}: ");
          LastName = Console.ReadLine();
        }
        else
          break;
      }

      NewEmployee.LastName = LastName!;


      Console.Write($"\t\t{"Department ID",-16}: ");
      int deptID = 0;

      while (!int.TryParse(Console.ReadLine(), out deptID))
      {
        Console.Write($"\t\t{"Invalid! Department ID",-16}: ");
      }

      NewEmployee.DepartmentID = deptID;

      Console.Write($"\t\t{"Manager ID",-16}: ");
      int mangeID = 0;

      while (!int.TryParse(Console.ReadLine(), out mangeID))
        Console.Write($"\t\t{"Invalid! Manager ID",-16}: ");

      NewEmployee.ManagerID = mangeID;

      Console.Write($"\t\t{"Job Title",-16}: ");

      string? JobTitle = Console.ReadLine()!;

      while (true)
      {
        bool isPass = true;

        if (string.IsNullOrWhiteSpace(JobTitle))
          isPass = false;
        else
        {
          foreach (char c in JobTitle)
            if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
            {
              isPass = false;
              break;
            }
        }

        if (!isPass)
        {
          Console.Write($"\t\t{"Invalid! Job Title",-16}: ");
          JobTitle = Console.ReadLine();
        }
        else
          break;
      }


      NewEmployee.JobTitle = JobTitle!;

      Console.Write($"\t\t{"Salary",-16}: ");
      decimal newSalary = 0.0m;

      while (!decimal.TryParse(Console.ReadLine(), out newSalary) || newSalary < 0)
        Console.Write($"\t\t{"Invalid! Salary ",-16}: ");

      NewEmployee.Salary = newSalary;

      Console.Write($"\t\t{"Phone",-16}: ");

      string? Phone = Console.ReadLine()!;

      while (true)
      {
        bool isPass = true;

        if (string.IsNullOrWhiteSpace(Phone))
          isPass = false;
        else
        {
          foreach (char c in Phone)
            if (!char.IsDigit(c))
            {
              isPass = false;
              break;
            }
        }

        if (!isPass)
        {
          Console.Write($"\t\t{"Invalid! Phone",-16}: ");
          Phone = Console.ReadLine();
        }
        else
          break;
      }


      NewEmployee.Phone = Phone!;

      Console.Write($"\t\t{"Email",-16}: ");

      string Email = Console.ReadLine()!;

      while (true)
      {
        bool isPass = true;

        if (string.IsNullOrWhiteSpace(Email))
          isPass = false;
        else
        {
          if (!Email.Contains(".com") || !Email.Contains("@"))
            isPass = false;
        }

        if (!isPass)
        {
          Console.Write($"\t\t{"Invalid! Email ",-16}: ");
          Email = Console.ReadLine()!;
        }
        else
          break;
      }

      NewEmployee.Email = Email;

    }

    private static void _AddNewEmployee()
    {

      Console.WriteLine("\n\n\t\t╔══════════════════════════════════════════╗");
      Console.WriteLine("\t\t║              ➕ ADD EMPLOYEE             ║");
      Console.WriteLine("\t\t╚══════════════════════════════════════════╝");

      EmployeesBL NewEmployee = new EmployeesBL();

      ReadInformationEmployees(NewEmployee);
      try
      {

        if (NewEmployee.SaveModeEmployees())
        {
          _ShowSccessMessageAndShowInformationEmployee(NewEmployee, "✅ EMPLOYEE ADDED");
        }
      }
      catch (SqlException SEX)
      {
        _ShowNotFoundMessage($"Employee with ID {SEX.Message} was not found.", "❌ EMPLOYEE NOT ADDED", "Employee could not be added.");
      }

    }

    private static string _GetStatusEmployee(Enumerations.EnStatus Status)
    {

      switch (Status)
      {
        case Enumerations.EnStatus._kACTIVE:
          return "Active";
        case Enumerations.EnStatus._kINACTIVE:
          return "Inactive";
        case Enumerations.EnStatus._kSUSPENDED:
          return "Suspended";
        default: return "";
      }

    }

    private static void _UpdateEmployee()
    {
      Console.WriteLine("\n\n\t\t╔══════════════════════════════════════════╗");
      Console.WriteLine("\t\t║            ✏️ UPDATE EMPLOYEE            ║");
      Console.WriteLine("\t\t╚══════════════════════════════════════════╝");

      int EmployeeID = 0;

      System.Console.Write("\n\n\t\tEnter Employee ID: ");

      while (!int.TryParse(Console.ReadLine(), out EmployeeID))
        Console.Write($"\t\t{"Invalid! Employee ID",-16}: ");

      EmployeesBL InfoEmployee = _GetEmployeeBy(EmployeeID)!;

      if (InfoEmployee is not null)
      {
        ReadInformationEmployees(InfoEmployee);

        Console.Write($"\n\t\t{"Enter Status(Active:1 , Inactive:0 , Suspended:2)",-16}: ");
        byte status = 0;

        while (!byte.TryParse(Console.ReadLine(), out status) || (status > 2))
          Console.Write($"\t\t{"Invalid! Status Employee",-16}: ");

        InfoEmployee.Status = (Enumerations.EnStatus)status;

        try
        {

          if (InfoEmployee.SaveModeEmployees())
          {
            _ShowSccessMessageAndShowInformationEmployee(InfoEmployee, "✅ EMPLOYEE UPDATED");
          }

        }
        catch (SqlException SEX)
        {
          _ShowNotFoundMessage($"{SEX.Message}", "❌ NOT FOUND", "Employee could not be found.");
        }
      }
    }

    private static void _DeleteEmployee()
    {
      Console.WriteLine("\n\n\t\t╔══════════════════════════════════════════╗");
      Console.WriteLine("\t\t║            🗑️ DELETE EMPLOYEE             ║");
      Console.WriteLine("\t\t╚══════════════════════════════════════════╝\n");

      Console.Write("\n\t\tEnter Employee ID to delete: ");

      int EmployeeID = 0;

      while (!int.TryParse(Console.ReadLine(), out EmployeeID))
        System.Console.WriteLine("\n\t\tInvalid!! Employee ID");


      EmployeesBL InfoEmployee = EmployeesBL.FindEmployeeBy(EmployeeID);

      if (InfoEmployee is null)
        _ShowNotFoundMessage($"Employee with ID {EmployeeID} was not found.", "❌ NOT FOUND", "Employee could not be found.");
      else
      {

        EmployeesBL CopyInfoEmployee = InfoEmployee;

        _GetEmployeeBy(EmployeeID);
        System.Console.WriteLine("\n\n");

        Console.Write("\t\tAre you sure you want to delete this employee?\n");
        System.Console.Write("\t\t(Y = Yes, N = No)\n");
        System.Console.Write("\t\tChoice: ");

        char choice = 'N';

        while (!char.TryParse(Console.ReadLine(), out choice))
          System.Console.Write("\t\tInvalid!! Choice");

        if (char.ToLower(choice) == 'y')
        {
          try
          {
            if (EmployeesBL.DeleteEmployee(EmployeeID))
            {
              string FullNameManager = string.Join(" ", CopyInfoEmployee.FirstName, CopyInfoEmployee.LastName);

              Console.WriteLine("\n\n\t\t╔══════════════════════════════════════════╗");
              Console.WriteLine("\t\t║          ✅ EMPLOYEE DELETED             ║");
              Console.WriteLine("\t\t╠══════════════════════════════════════════╣");
              Console.WriteLine($"\t\t║ Employee ID : {CopyInfoEmployee.ID,-27} ║");
              Console.WriteLine($"\t\t║ Name        : {FullNameManager,-27}║");
              Console.WriteLine("\t\t╚══════════════════════════════════════════╝");

            }
          }
          catch
          {
            _ShowNotFoundMessage($"Employee with ID {EmployeeID} was not found.", "❌ ERROR", "Employee could not be found. ");
          }


        }
        else
        {
          Console.WriteLine("\n\n\t\t╔══════════════════════════════════════════╗");
          Console.WriteLine("\t\t║          ℹ️ DELETE CANCELLED              ║");
          Console.WriteLine("\t\t╠══════════════════════════════════════════╣");
          Console.WriteLine("\t\t║ No changes were made.                    ║");
          Console.WriteLine("\t\t╚══════════════════════════════════════════╝");
        }
      }


    }

    private static void _SearchEmployee()
    {
      while (true)
      {
        Console.Clear();

        Console.WriteLine("\t\t╔══════════════════════════════════════════╗");
        Console.WriteLine("\t\t║             🔍 SEARCH EMPLOYEES          ║");
        Console.WriteLine("\t\t╚══════════════════════════════════════════╝");

        Console.WriteLine();
        Console.WriteLine("\t\tSearch by:\n\n");
        Console.WriteLine("\t\t1. Name");
        Console.WriteLine("\t\t2. Department");
        Console.WriteLine("\t\t3. Job Title");
        Console.WriteLine("\t\t4. Status");

        Console.WriteLine("\t\t0. Back\n\n");

        Console.Write("\t\tSelect: ");
        byte Choice = 0;

        while (!byte.TryParse(Console.ReadLine(), out Choice) || Choice > 4)
          System.Console.Write("\t\tInvalid!! Choice Search Employee");


        Enumerations.EnChoicesSearchEmployees ChoiceSearchEmployee = (Enumerations.EnChoicesSearchEmployees)Choice;

        switch (ChoiceSearchEmployee)
        {
          case Enumerations.EnChoicesSearchEmployees._kSEARCH_BY_FULL_NAME:
            {

              System.Console.Write("\n\n\t\tEnter Full Name : ");
              string? FullName = Console.ReadLine()!;

              _EmployeesList(FullName);
              break;
            }

          case Enumerations.EnChoicesSearchEmployees._kSEARCH_BY_DEPARTMENT_NAME:
            {

              System.Console.Write("\n\n\t\tEnter Department Name : ");
              string? DepartmentName = Console.ReadLine()!;

              _EmployeesList(null, DepartmentName);

              break;
            }

          case Enumerations.EnChoicesSearchEmployees._kSEARCH_BY_JOB_TITLE:
            {

              System.Console.Write("\n\n\t\tEnter Job Title : ");
              string? JobTitle = Console.ReadLine()!;

              _EmployeesList(null, null, JobTitle);

              break;
            }

          case Enumerations.EnChoicesSearchEmployees._kSEARCH_BY_STATUS:
            {

              Console.Write($"\n\t\t{"Enter Status(Active:1 , Inactive:0 , Suspended:2)",-16}: ");

              byte status = 0;
              while (!byte.TryParse(Console.ReadLine(), out status) || status > 2)
                System.Console.Write("\t\tInvalid!! Status Employee");


              _EmployeesList(null, null, null, _GetStatusEmployee((Enumerations.EnStatus)status));

              break;
            }

          case Enumerations.EnChoicesSearchEmployees._kBACK_MAIN_MENU_EMPLOYEES:
            {
              StartupEmployeesModule();
              break;
            }
        }

        System.Console.WriteLine("\n\n\t\tPress any key to continue...");
        Console.ReadKey();
      }

    }

    private static void _DepartmentSammary()
    {
      Console.Clear();

      Console.WriteLine("\n\n\t\t╔══════════════════════════════════════════╗");
      Console.WriteLine("\t\t║         📊 DEPARTMENT SUMMARY            ║");
      Console.WriteLine("\t\t╚══════════════════════════════════════════╝");

      System.Console.WriteLine($"\n\n\t\t{"Department",-25} {"Employees",-15} {"Avg Salary",-20}");
      System.Console.WriteLine("\t\t" + new string('-', 55));

      DataTable DT_DepartmentSummary = EmployeesBL.GetDepartmentSammary();
      int CountEmployees = 0;

      foreach (DataRow DR in DT_DepartmentSummary.Rows)
      {

        CountEmployees += Convert.ToInt32(DR["TotalEmployees"]);

        System.Console.WriteLine($"\t\t{DR["DepartmentName"].ToString(),-25} {Convert.ToInt32(DR["TotalEmployees"]).ToString(),-15} {(Convert.ToDouble(DR["Avg Salary"])).ToString("C2"),-20}");


      }

      System.Console.WriteLine("\t\t" + new string('-', 55));
      System.Console.WriteLine("\n\n");


      System.Console.WriteLine($"\t\tTotal Employees: {CountEmployees}\n\n");



    }

    private static void _SalarySummary()
    { 
      
      Console.Clear();
      Console.WriteLine("\n\n\t\t╔══════════════════════════════════════════╗");
      Console.WriteLine("\t\t║            💰 SALARY SUMMARY             ║");
      Console.WriteLine("\t\t╚══════════════════════════════════════════╝\n\n");

      DataTable DT_SalarySummary = EmployeesBL.GetSalarySummary();

      if (DT_SalarySummary.Rows.Count > 0)
      {
        DataRow DR_SalarySummary = DT_SalarySummary.Rows[0];

        System.Console.WriteLine($"\t\tMinimum Salary : {Convert.ToDouble(DR_SalarySummary["MinimumSalary"]).ToString("C2")}");
        System.Console.WriteLine($"\t\tMaximum Salary : {Convert.ToDouble(DR_SalarySummary["MaximumSalary"]).ToString("C2")}");
        System.Console.WriteLine($"\t\tAverage Salary : {Convert.ToDouble(DR_SalarySummary["AverageSalary"]).ToString("C2")}");
        System.Console.WriteLine($"\t\tTotal Salary   : {Convert.ToDouble(DR_SalarySummary["TotalSalary"]).ToString("C2")}");
      }
      else
      {
        Console.WriteLine("\n\n\t\t╔══════════════════════════════════════════╗");
        Console.WriteLine("\t\t║             ❌ NO SALARY DATA            ║");
        Console.WriteLine("\t\t╠══════════════════════════════════════════╣");
        Console.WriteLine("\t\t║ No salary data is available.             ║");
        Console.WriteLine("\t\t╚══════════════════════════════════════════╝");
      }
    }

    private static void _EmployeeStatus()
    {

      Console.Clear();

      Console.WriteLine("\n\n\t\t╔══════════════════════════════════════════╗");
      Console.WriteLine("\t\t║          👥 EMPLOYEE STATUS             ║");
      Console.WriteLine("\t\t╚══════════════════════════════════════════╝\n\n");


      Dictionary<string, int> AllEmployeeStatus = EmployeesBL.GetEmployeeStatus();

      System.Console.WriteLine($"\t\t{"Status",-15} {"Count",-15}");
      System.Console.WriteLine($"\t\t{new string('-', 25)}");



      foreach (var item in AllEmployeeStatus)
      {
        Console.WriteLine($"\t\t{item.Key,-15} {item.Value,-15}");
      }

      System.Console.WriteLine($"\t\t{new string('-', 25)}");
    }

    private static void _HiringSummary()
    {
      Console.Clear();

      Console.WriteLine("\n\n\t\t╔══════════════════════════════════════════╗");
      Console.WriteLine("\t\t║            📅 HIRING SUMMARY             ║");
      Console.WriteLine("\t\t╚══════════════════════════════════════════╝");

      Dictionary<string?, int?> AllEmployessHired = EmployeesBL.GetHiringSummary();

      System.Console.WriteLine($"\n\n\t\t{"Year",-15} {"Employees Hired",-15}");
      System.Console.WriteLine($"\t\t{new string('-', 33)}");

      foreach (var item in AllEmployessHired)
        System.Console.WriteLine($"\t\t{item.Key ?? " ",-15} {item.Value ?? 0,-15}");
   
      System.Console.WriteLine($"\t\t{new string('-', 33)}");

    }
    
    private static void _EmployeesReport()
    {


      while (true)
      {
        Console.Clear();

        Console.WriteLine("\n\n\t\t╔══════════════════════════════════════════╗");
        Console.WriteLine("\t\t║             📊 EMPLOYEE REPORT           ║");
        Console.WriteLine("\t\t╠══════════════════════════════════════════╣");
        Console.WriteLine("\t\t║                                          ║");
        Console.WriteLine("\t\t║ 1. Department Summary                    ║");
        Console.WriteLine("\t\t║ 2. Salary Summary                        ║");
        Console.WriteLine("\t\t║ 3. Employee Status Summary               ║");
        Console.WriteLine("\t\t║ 4. Hiring Summary                        ║");
        Console.WriteLine("\t\t║                                          ║");
        Console.WriteLine("\t\t║ 0. 🔙 Back                               ║");
        Console.WriteLine("\t\t╚══════════════════════════════════════════╝");

        Console.Write("\n\n\t\tSelect: ");
        byte Choice = 0;


        while (!byte.TryParse(Console.ReadLine(), out Choice) || (Choice > 4))
          System.Console.Write("\t\tInvalid Choice : ");

        switch ((Enumerations.EnChoicesEmployeesReport)Choice)
        {
          case Enumerations.EnChoicesEmployeesReport._kDEPARTMENT_SUMMARY:
            {
              _DepartmentSammary();
              break;
            }

          case Enumerations.EnChoicesEmployeesReport._kSALARY_SUMMARY:
            {
              _SalarySummary();
              break;
            }

          case Enumerations.EnChoicesEmployeesReport._kBACK:
            {
              StartupEmployeesModule();
              break;
            }

          case Enumerations.EnChoicesEmployeesReport._kEMPLOYEE_STATUS_SUMMARY:
            {
              _EmployeeStatus();
              break;
            }

          case Enumerations.EnChoicesEmployeesReport._kHIRING_SUMMARY:
            {
              _HiringSummary();
              break;
            }
        }

        System.Console.WriteLine("\n\n\t\tPress any key to continue...");
        Console.ReadKey();
      }


    }

    public static void StartupEmployeesModule()
    {

      while (true)
      {

        Console.Clear();
        PrintScreenMenuEmployeesModule(out byte ChoiseEmployeesModule);

        switch ((Enumerations.EnCategoriesEmployees)ChoiseEmployeesModule)
        {

          case Enumerations.EnCategoriesEmployees._kLIST_EMPLOYEES:
            _EmployeesList();
            break;

          case Enumerations.EnCategoriesEmployees._kGET_EMPLOYEES_BY_ID:
            {
              Console.Clear();

              Console.WriteLine($"\t\t╔══════════════════════════════════════════╗");
              Console.WriteLine($"\t\t║          🔎 GET EMPLOYEE BY ID           ║");
              Console.WriteLine($"\t\t╚══════════════════════════════════════════╝");
              Console.WriteLine();
              Console.Write($"\n\n\t\tEnter Employee ID: ");
              int.TryParse(Console.ReadLine(), out int EmployeeID);
              Console.WriteLine("\n\t\t╚══════════════════════════════════════════╝\n\n");
              _GetEmployeeBy(EmployeeID);
              break;

            }

          case Enumerations.EnCategoriesEmployees._kADD_EMPLOYEE:
            _AddNewEmployee();
            break;

          case Enumerations.EnCategoriesEmployees._kUPDATE_INFORMATION_EMPLOYEE:
            {
              _UpdateEmployee();
              break;
            }

          case Enumerations.EnCategoriesEmployees._kDELETE_EMPLOYEE:
            {
              _DeleteEmployee();
              break;
            }

          case Enumerations.EnCategoriesEmployees._kSEARCH_EMPLOYEES:
            {
              _SearchEmployee();
              break;
            }

          case Enumerations.EnCategoriesEmployees._kEMPLOYEE_REPORT:
            {
              _EmployeesReport();
              break;
            }
        }

        System.Console.WriteLine("\n\n\t\tPress any key to continue...");
        Console.ReadKey();

      }
    }


  }

}
```

### `NovaBusinessSystemPL/Moduls/Products Module/Inventory Management/InventoryManagementMenu.cs`

```cs
using NovaBusinessSystem.Helpers;
using NovaBusinessSystem.Enumeration;

namespace NovaBusinessSystem.Modules.Products.Inventory
{
    public class InventoryManagementMenu
    {
        private static void _PrintInventoryManagementMenu()
        {
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}╔══════════════════════════════════════════════╗");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║          📦 INVENTORY MANAGEMENT             ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}╠══════════════════════════════════════════════╣");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║                                              ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║  1. 📦 View Product Stock                    ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║  2. ➕ Add Stock                             ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║  3. ➖ Remove Stock                          ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║  4. 🔧 Adjust Stock                          ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║  5. ⚠️  Low Stock Products                    ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║  6. ❌ Out Of Stock Products                 ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║  7. 💰 Inventory Value                       ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║  8. 📊 Stock Statistics                      ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║                                              ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║  0. 🔙 Back                                  ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║                                              ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}╚══════════════════════════════════════════════╝");
        }


        public static async Task StartupInventoryManagementSection()
        {
            while (true)
            {
                Console.Clear();

                _PrintInventoryManagementMenu();

                Console.Write(
                    $"\n\n{ConsoleHelper.GenarateTabs(7)}Select: ");

                byte choice = 0;

                while (!byte.TryParse(Console.ReadLine(), out choice) ||
                       choice > 8)
                {
                    Console.Write(
                        $"{ConsoleHelper.GenarateTabs(7)}Incorrect choice try again : ");
                }


                switch ((Enumerations.EnChoicesInventoryManagement)choice)
                {
                    case Enumerations.EnChoicesInventoryManagement._kVIEW_PRODUCT_STOCK:
                        {
                            await InventoryOperations.ViewProductStockAsync();
                            break;
                        }

                    case Enumerations.EnChoicesInventoryManagement._kADD_STOCK:
                        {
                            await InventoryOperations.AddStockAsync();
                            break;
                        }

                    case Enumerations.EnChoicesInventoryManagement._kREMOVE_STOCK:
                        {
                            await InventoryOperations.RemoveStockAsync();
                            break;
                        }

                    case Enumerations.EnChoicesInventoryManagement._kADJUST_STOCK:
                        {
                            await InventoryOperations.AdjustStockAsync();
                            break;
                        }

                    case Enumerations.EnChoicesInventoryManagement._kLOW_STOCK_PRODUCTS:
                        {
                            await InventoryOperations.GetLowStockProductsAsync();
                            break;
                        }

                    case Enumerations.EnChoicesInventoryManagement._kOUT_OF_STOCK_PRODUCTS:
                        {
                            await InventoryOperations.GetOutOfStockProductsAsync();
                            break;
                        }

                    case Enumerations.EnChoicesInventoryManagement._kINVENTORY_VALUE:
                        {
                            await InventoryOperations.GetInventoryValueAsync();
                            break;
                        }

                    case Enumerations.EnChoicesInventoryManagement._kSTOCK_STATISTICS:
                        {
                            break;
                        }

                    case Enumerations.EnChoicesInventoryManagement._kBACK:
                        return;
                }


                Console.WriteLine(
                    $"\n\n{ConsoleHelper.GenarateTabs(7)}Press any key to continue...");

                Console.ReadKey();
            }
        }
    }
}
```

### `NovaBusinessSystemPL/Moduls/Products Module/Inventory Management/InventoryManagementOperations.cs`

```cs
using System.Net.Http.Json;
using NovaBusinessSystem.DTOs.Products.Inventory;
using NovaBusinessSystem.Helpers;

namespace NovaBusinessSystem.Modules.Products.Inventory
{
    public class InventoryOperations
    {
        public static async Task ViewProductStockAsync()
        {
            try
            {
                Console.Clear();

                int productID = InputHelper.ReadTheID(
                    "🔎 VIEW PRODUCT STOCK",
                    "Enter Product ID: "
                );


                using HttpClient httpClient = new HttpClient();

                httpClient.BaseAddress =
                    new Uri("http://localhost:5276/api/Products/Inventory/");


                var respone =
                    await httpClient.GetAsync($"{productID}");


                if (respone.IsSuccessStatusCode)
                {
                    ProductStockDTO? productStock =
                        await respone.Content
                            .ReadFromJsonAsync<ProductStockDTO>();

                    if (productStock == null)
                    {
                        ConsoleHelper.ShowNotFoundMessage(
                            "❌ PRODUCT NOT FOUND",
                            $"Product with ID {productID} was not found.");

                        return;
                    }


                    Console.WriteLine("\n\n");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}╔══════════════════════════════════════════════╗");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║              📦 PRODUCT STOCK                ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}╠══════════════════════════════════════════════╣");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ Product ID       : {productStock.ProductID,-25} ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ Product Name     : {productStock.ProductName,-25} ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ Category         : {productStock.Category,-25} ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ Price            : {productStock.Price.ToString("N2"),-25} ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ Stock Quantity   : {productStock.StockQuantity,-25} ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ Stock Value      : {productStock.StockValue.ToString("N2"),-25} ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ Status           : {productStock.Status,-25} ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}╚══════════════════════════════════════════════╝");

                    return;
                }


                if (respone.StatusCode ==
                    System.Net.HttpStatusCode.NotFound)
                {
                    ConsoleHelper.ShowNotFoundMessage(
                        "❌ PRODUCT NOT FOUND",
                        $"Product with ID {productID} was not found.");

                    return;
                }


                ConsoleHelper.ShowNotFoundMessage(
                    "❌ REQUEST FAILED",
                    await respone.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                ConsoleHelper.ShowNotFoundMessage(
                    "❌ SYSTEM ERROR",
                    ex.Message,
                    "your request. Please try again.");
            }
        }

        public static async Task AddStockAsync()
        {
            try
            {
                Console.Clear();

                int productID = InputHelper.ReadTheID(
                    "➕ ADD STOCK",
                    "Enter Product ID: "
                );

                Console.Write(
                    $"{ConsoleHelper.GenarateTabs(7)}Quantity To Add : ");

                int quantityToAdd;

                while (!int.TryParse(
                           Console.ReadLine(),
                           out quantityToAdd) ||
                       quantityToAdd <= 0)
                {
                    Console.Write(
                        $"{ConsoleHelper.GenarateTabs(7)}Invalid! Quantity To Add : ");
                }


                using HttpClient httpClient = new HttpClient();

                httpClient.BaseAddress =
                    new Uri("http://localhost:5276/api/Products/Inventory/");


                var respone =
                    await httpClient.PatchAsync(
                        $"{productID}/Add?quantity={quantityToAdd}",
                        null
                    );


                if (respone.IsSuccessStatusCode)
                {
                    AddStockResultDTO? result =
                        await respone.Content
                            .ReadFromJsonAsync<AddStockResultDTO>();

                    if (result == null)
                    {
                        ConsoleHelper.ShowNotFoundMessage(
                            "❌ STOCK NOT ADDED",
                            "Failed to read stock result.");

                        return;
                    }


                    Console.WriteLine("\n\n");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}╔══════════════════════════════════════════════╗");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║             ✅ STOCK ADDED                   ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}╠══════════════════════════════════════════════╣");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ Product       : {result.ProductName,-28} ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ Previous      : {result.PreviousStock,-28} ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ Added         : {result.AddedStock,-28} ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ New Stock     : {result.NewStock,-28} ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}╚══════════════════════════════════════════════╝");

                    return;
                }


                if (respone.StatusCode ==
                    System.Net.HttpStatusCode.NotFound)
                {
                    ConsoleHelper.ShowNotFoundMessage(
                        "❌ PRODUCT NOT FOUND",
                        $"Product with ID {productID} was not found.");

                    return;
                }


                ConsoleHelper.ShowNotFoundMessage(
                    "❌ STOCK NOT ADDED",
                    await respone.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                ConsoleHelper.ShowNotFoundMessage(
                    "❌ SYSTEM ERROR",
                    ex.Message,
                    "your request. Please try again.");
            }
        }


        public static async Task RemoveStockAsync()
        {
            try
            {
                Console.Clear();

                int productID = InputHelper.ReadTheID(
                    "➖ REMOVE STOCK",
                    "Enter Product ID: "
                );

                Console.Write(
                    $"{ConsoleHelper.GenarateTabs(7)}Quantity To Remove : ");

                int quantityToRemove;

                while (!int.TryParse(
                           Console.ReadLine(),
                           out quantityToRemove) ||
                       quantityToRemove <= 0)
                {
                    Console.Write(
                        $"{ConsoleHelper.GenarateTabs(7)}Invalid! Quantity To Remove : ");
                }


                using HttpClient httpClient = new HttpClient();

                httpClient.BaseAddress =
                    new Uri("http://localhost:5276/api/Products/Inventory/");


                var respone =
                    await httpClient.PatchAsync(
                        $"{productID}/Remove?quantity={quantityToRemove}",
                        null
                    );


                if (respone.IsSuccessStatusCode)
                {
                    RemoveStockResultDTO? result =
                        await respone.Content
                            .ReadFromJsonAsync<RemoveStockResultDTO>();

                    if (result == null)
                    {
                        ConsoleHelper.ShowNotFoundMessage(
                            "❌ STOCK NOT REMOVED",
                            "Failed to read stock result.");

                        return;
                    }


                    Console.WriteLine("\n\n");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}╔══════════════════════════════════════════════╗");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║            ✅ STOCK REMOVED                  ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}╠══════════════════════════════════════════════╣");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ Product       : {result.ProductName,-28} ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ Previous      : {result.PreviousStock,-28} ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ Removed       : {result.RemovedStock,-28} ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ New Stock     : {result.NewStock,-28} ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}╚══════════════════════════════════════════════╝");

                    return;
                }


                if (respone.StatusCode ==
                    System.Net.HttpStatusCode.NotFound)
                {
                    ConsoleHelper.ShowNotFoundMessage(
                        "❌ PRODUCT NOT FOUND",
                        $"Product with ID {productID} was not found.");

                    return;
                }


                ConsoleHelper.ShowNotFoundMessage(
                    "❌ STOCK NOT REMOVED",
                    await respone.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                ConsoleHelper.ShowNotFoundMessage(
                    "❌ SYSTEM ERROR",
                    ex.Message,
                    "your request. Please try again.");
            }
        }

        public static async Task AdjustStockAsync()
        {
            try
            {
                Console.Clear();

                int productID = InputHelper.ReadTheID(
                    "🔧 STOCK ADJUSTMENT",
                    "Enter Product ID: "
                );

                using HttpClient httpClient = new HttpClient();

                httpClient.BaseAddress =
                    new Uri("http://localhost:5276/api/Products/Inventory/");

                // Get current system stock
                var stockResponse =
                    await httpClient.GetAsync($"{productID}");

                if (stockResponse.StatusCode ==
                    System.Net.HttpStatusCode.NotFound)
                {
                    ConsoleHelper.ShowNotFoundMessage(
                        "❌ PRODUCT NOT FOUND",
                        $"Product with ID {productID} was not found."
                    );

                    return;
                }

                if (!stockResponse.IsSuccessStatusCode)
                {
                    ConsoleHelper.ShowNotFoundMessage(
                        "❌ FAILED TO GET STOCK",
                        await stockResponse.Content.ReadAsStringAsync()
                    );

                    return;
                }

                ProductStockDTO? productStock =
                    await stockResponse.Content
                        .ReadFromJsonAsync<ProductStockDTO>();

                if (productStock == null)
                {
                    ConsoleHelper.ShowNotFoundMessage(
                        "❌ FAILED TO GET STOCK",
                        "Failed to read product stock."
                    );

                    return;
                }

                Console.WriteLine();
                Console.WriteLine(
                    $"{ConsoleHelper.GenarateTabs(7)}System Stock      : {productStock.StockQuantity}"
                );

                Console.Write(
                    $"{ConsoleHelper.GenarateTabs(7)}Actual Stock      : "
                );

                int actualStock;

                while (!int.TryParse(
                           Console.ReadLine(),
                           out actualStock) ||
                       actualStock < 0)
                {
                    Console.Write(
                        $"{ConsoleHelper.GenarateTabs(7)}Invalid! Actual Stock      : "
                    );
                }

                int difference =
                    actualStock - productStock.StockQuantity;

                Console.WriteLine();
                Console.WriteLine(
                    $"{ConsoleHelper.GenarateTabs(7)}Difference        : {difference}"
                );

                Console.WriteLine();
                Console.WriteLine(
                    $"{ConsoleHelper.GenarateTabs(7)}Adjust stock from " +
                    $"{productStock.StockQuantity} to {actualStock}?"
                );

                Console.Write(
                    $"\n{ConsoleHelper.GenarateTabs(7)}Y / N: "
                );

                string? confirmation =
                    Console.ReadLine()?.Trim().ToUpper();

                if (confirmation != "Y")
                {
                    Console.WriteLine(
                        $"\n{ConsoleHelper.GenarateTabs(7)}Adjustment cancelled."
                    );

                    return;
                }

                var respone =
                    await httpClient.PatchAsync(
                        $"{productID}/Adjust?actualStock={actualStock}",
                        null
                    );

                if (respone.IsSuccessStatusCode)
                {
                    AdjustStockResultDTO? result =
                        await respone.Content
                            .ReadFromJsonAsync<AdjustStockResultDTO>();

                    if (result == null)
                    {
                        ConsoleHelper.ShowNotFoundMessage(
                            "❌ STOCK NOT ADJUSTED",
                            "Failed to read adjustment result."
                        );

                        return;
                    }

                    Console.WriteLine("\n\n");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}Previous Stock : {result.PreviousStock}"
                    );

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}Actual Stock   : {result.ActualStock}"
                    );

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}Adjustment     : {result.Adjustment}"
                    );

                    Console.WriteLine();

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}✅ STOCK ADJUSTED"
                    );

                    return;
                }

                if (respone.StatusCode ==
                    System.Net.HttpStatusCode.NotFound)
                {
                    ConsoleHelper.ShowNotFoundMessage(
                        "❌ PRODUCT NOT FOUND",
                        $"Product with ID {productID} was not found."
                    );

                    return;
                }

                ConsoleHelper.ShowNotFoundMessage(
                    "❌ STOCK NOT ADJUSTED",
                    await respone.Content.ReadAsStringAsync()
                );
            }
            catch (Exception ex)
            {
                ConsoleHelper.ShowNotFoundMessage(
                    "❌ SYSTEM ERROR",
                    ex.Message,
                    "your request. Please try again."
                );
            }
        }


        public static async Task GetLowStockProductsAsync()
        {
            try
            {
                Console.Clear();

                ConsoleHelper.PrintHeader("⚠️    LOW STOCK PRODUCTS", 7);
                Console.Write(
                    $"{ConsoleHelper.GenarateTabs(7)}Enter Low Stock Threshold: ");

                int threshold;

                while (!int.TryParse(Console.ReadLine(), out threshold) ||
                       threshold < 0)
                {
                    Console.Write(
                        $"{ConsoleHelper.GenarateTabs(7)}Invalid! Enter Low Stock Threshold: ");
                }

                using HttpClient httpClient = new HttpClient();

                httpClient.BaseAddress =
                    new Uri("http://localhost:5276/api/Products/Inventory/");

                var respone =
                    await httpClient.GetAsync(
                        $"LowStock?threshold={threshold}"
                    );

                if (!respone.IsSuccessStatusCode)
                {
                    ConsoleHelper.ShowNotFoundMessage(
                        "❌ FAILED TO GET LOW STOCK PRODUCTS",
                        await respone.Content.ReadAsStringAsync()
                    );

                    return;
                }

                List<LowStockProductDTO>? products =
                    await respone.Content
                        .ReadFromJsonAsync<List<LowStockProductDTO>>();

                if (products == null || products.Count == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}No low stock products found."
                    );

                    return;
                }

                Console.WriteLine("\n\n");

                Console.WriteLine(
                    $"{ConsoleHelper.GenarateTabs(7)}╔══════════════════════════════════════════════════════════╗");

                Console.WriteLine(
                    $"{ConsoleHelper.GenarateTabs(7)}║                  ⚠️  LOW STOCK PRODUCTS                   ║");

                Console.WriteLine(
                    $"{ConsoleHelper.GenarateTabs(7)}╠══════════════════════════════════════════════════════════╣");

                Console.WriteLine(
                    $"{ConsoleHelper.GenarateTabs(7)}║ Threshold : {threshold,-44} ║");

                Console.WriteLine(
                    $"{ConsoleHelper.GenarateTabs(7)}╠══════════════════════════════════════════════════════════╣");

                Console.WriteLine(
                    $"{ConsoleHelper.GenarateTabs(7)}║ {"ID",-5}{"Product",-25}{"Category",-17}{"Stock",-10}║");

                Console.WriteLine(
                    $"{ConsoleHelper.GenarateTabs(7)}║ -------------------------------------------------------- ║");

                foreach (LowStockProductDTO product in products)
                {
                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ " +
                        $"{product.ProductID,-5}" +
                        $"{product.ProductName,-25}" +
                        $"{product.Category,-17}" +
                        $"{product.StockQuantity,-10}" +
                        $"║");
                }

                Console.WriteLine(
                    $"{ConsoleHelper.GenarateTabs(7)}╠══════════════════════════════════════════════════════════╣");

                Console.WriteLine(
                    $"{ConsoleHelper.GenarateTabs(7)}║ Low Stock Products: {products.Count,-37}║");

                Console.WriteLine(
                    $"{ConsoleHelper.GenarateTabs(7)}╚══════════════════════════════════════════════════════════╝");
            }
            catch (Exception ex)
            {
                ConsoleHelper.ShowNotFoundMessage(
                    "❌ SYSTEM ERROR",
                    ex.Message,
                    "your request. Please try again."
                );
            }
        }

        public static async Task GetOutOfStockProductsAsync()
        {
            try
            {
                Console.Clear();

                ConsoleHelper.PrintHeader(
                    "❌ OUT OF STOCK",
                    7
                );

                Console.WriteLine("\n\n");

                using HttpClient httpClient = new HttpClient();

                httpClient.BaseAddress =
                    new Uri("http://localhost:5276/api/Products/Inventory/");

                var respone =
                    await httpClient.GetAsync("OutStock");

                if (!respone.IsSuccessStatusCode)
                {
                    ConsoleHelper.ShowNotFoundMessage(
                        "❌ FAILED TO GET OUT OF STOCK PRODUCTS",
                        await respone.Content.ReadAsStringAsync()
                    );

                    return;
                }

                List<OutOfStockProductDTO>? products =
                    await respone.Content
                        .ReadFromJsonAsync<List<OutOfStockProductDTO>>();

                if (products == null || products.Count == 0)
                {
                    Console.WriteLine();

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}No out of stock products found."
                    );

                    return;
                }

                Console.WriteLine(
                    $"{ConsoleHelper.GenarateTabs(6)}" +
                    $"{"ID",-15} {"Product",-25} {"Category",-20} {"Status",-15}"
                );

                Console.WriteLine(
                    $"{ConsoleHelper.GenarateTabs(6)}" +
                    $"{new string('-', 75)}"
                );

                foreach (OutOfStockProductDTO product in products)
                {
                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(6)}" +
                        $"{product.ProductID,-15} " +
                        $"{product.ProductName,-25} " +
                        $"{product.Category,-20} " +
                        $"{product.Status,-15}"
                    );
                }

                Console.WriteLine(
                    $"\n\n{ConsoleHelper.GenarateTabs(6)}" +
                    $"Total Out Of Stock: {products.Count}"
                );
            }
            catch (Exception ex)
            {
                ConsoleHelper.ShowNotFoundMessage(
                    "❌ SYSTEM ERROR",
                    ex.Message,
                    "your request. Please try again."
                );
            }
        }

        public static async Task GetInventoryValueAsync()
        {
            try
            {
                Console.Clear();
                ConsoleHelper.PrintHeader("💰 INVENTORY VALUE", 7);

                using HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri("http://localhost:5276/api/Products/Inventory/");

                var respone = await httpClient.GetAsync("Values");

                if (!respone.IsSuccessStatusCode)
                {
                    ConsoleHelper.ShowNotFoundMessage(
                        "❌ FAILED TO GET INVENTORY VALUE",
                        await respone.Content.ReadAsStringAsync());

                    return;
                }

                InventoryValueDTO? inventoryValue =
                    await respone.Content.ReadFromJsonAsync<InventoryValueDTO>();

                if (inventoryValue == null)
                {
                    ConsoleHelper.ShowNotFoundMessage(
                        "❌ NO INVENTORY DATA",
                        "Failed to read inventory value.");

                    return;
                }

                string tabs = ConsoleHelper.GenarateTabs(7);

                Console.WriteLine("\n");
                Console.WriteLine($"{tabs}╔════════════════════════════════════════════════════╗");
                Console.WriteLine($"{tabs}║                 💰 INVENTORY VALUE                 ║");
                Console.WriteLine($"{tabs}╠════════════════════════════════════════════════════╣");
                Console.WriteLine($"{tabs}║ Total Products        : {inventoryValue.TotalProducts,-26:N0} ║");
                Console.WriteLine($"{tabs}║ Total Stock Units     : {inventoryValue.TotalStockUnits,-26:N0} ║");
                Console.WriteLine($"{tabs}║ Total Inventory Value : {inventoryValue.TotalInventoryValue,-26:N2} ║");
                Console.WriteLine($"{tabs}║ Average Product Price : {inventoryValue.AverageProductPrice,-26:N2} ║");
                Console.WriteLine($"{tabs}║ Average Stock         : {inventoryValue.AverageStock,-26:N2} ║");
                Console.WriteLine($"{tabs}╠════════════════════════════════════════════════════╣");
                Console.WriteLine($"{tabs}║ Most Valuable Stock   : {inventoryValue.MostValuableStock,-26} ║");
                Console.WriteLine($"{tabs}║ Stock Value           : {inventoryValue.StockValue,-26:N2} ║");
                Console.WriteLine($"{tabs}╚════════════════════════════════════════════════════╝");
            }
            catch (Exception ex)
            {
                ConsoleHelper.ShowNotFoundMessage(
                    "❌ SYSTEM ERROR",
                    ex.Message,
                    "your request. Please try again.");
            }
        }


    }
}
```

### `NovaBusinessSystemPL/Moduls/Products Module/Products/ProductsMenu.cs`

```cs
using NovaBusinessSystem.Helpers;
using NovaBusinessSystem.Enumeration;
using NovaBusinessSystem.Modules.Products.Inventory;

namespace NovaBusinessSystem.Modules.Products
{
    public class ProductsMenu
    {
        private static void _PrintMainMenuProducts()
        {
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}╔══════════════════════════════════════════════╗");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║                 📦 PRODUCTS                  ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}╠══════════════════════════════════════════════╣");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║                                              ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║  1. 📋 List Products                         ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║  2. 🔎 Get Product By ID                     ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║  3. ➕ Add Product                           ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║  4. ✏️  Update Product                        ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║  5. 🗑️  Delete Product                        ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║  6. 🔍 Search & Filter Products              ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║  7. 📦 Inventory Management                  ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║  8. 💰 Product Sales Analysis                ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║  9. 📊 Product Reports                       ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║                                              ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║  0. 🔙 Back                                  ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}║                                              ║");
            Console.WriteLine($"{ConsoleHelper.GenarateTabs(7)}╚══════════════════════════════════════════════╝");

        }


        public static async Task StartupProductsSection()
        {
            while (true)
            {
                Console.Clear();
                _PrintMainMenuProducts();
                Console.Write($"\n\n{ConsoleHelper.GenarateTabs(7)}Select: ");
                byte choice = 0;
                while (!byte.TryParse(Console.ReadLine(), out choice) || choice > 9)
                    Console.Write($"{ConsoleHelper.GenarateTabs(7)}Incorrect choice try agian : ");

                switch ((Enumerations.EnChoicesProductsModule)choice)
                {

                    case Enumerations.EnChoicesProductsModule._kLIST_PRODUCTS:
                        {
                            await ProductsOperations.GetAllProductsAsync();
                            break;
                        }

                    case Enumerations.EnChoicesProductsModule._kGET_PRODUCT_BY_ID:
                        {
                            await ProductsOperations.GetProductByIDAsync();
                            break;
                        }

                    case Enumerations.EnChoicesProductsModule._kADD_PRODUCT:
                        {
                            await ProductsOperations.AddNewProductAsync();
                            break;
                        }

                    case Enumerations.EnChoicesProductsModule._kUPDATE_PRODUCT:
                        {
                            await ProductsOperations.UpdateProductAsync();
                            break;
                        }

                    case Enumerations.EnChoicesProductsModule._kDELETE_PRODUCT:
                        {

                            await ProductsOperations.DeleteProductAsync();
                            break;
                        }

                    case Enumerations.EnChoicesProductsModule._kSEARCH_AND_FILTER_PRODUCTS:
                        break;

                    case Enumerations.EnChoicesProductsModule._kINVENTORY_MANAGEMENT:
                    {
                        await  InventoryManagementMenu.StartupInventoryManagementSection();
                        break;
                    }

                    case Enumerations.EnChoicesProductsModule._kPRODUCT_SALES_ANALYSIS:
                        break;

                    case Enumerations.EnChoicesProductsModule._kPRODUCT_REPORTS:
                        break;

                    case Enumerations.EnChoicesProductsModule._kBACK:
                        return;
                }




                Console.WriteLine($"\n\n{ConsoleHelper.GenarateTabs(7)}Press any key to continue...");
                Console.ReadKey();
            }



        }
    }
}
```

### `NovaBusinessSystemPL/Moduls/Products Module/Products/ProductsOperations.cs`

```cs
using System.Net.Http.Json;
using NovaBusinessSystem.BL.Products;
using NovaBusinessSystem.DTOs.Products;
using NovaBusinessSystem.Enumeration;
using NovaBusinessSystem.Helpers;

namespace NovaBusinessSystem.Modules.Products
{
    public class ProductsOperations
    {
        public static async Task GetAllProductsAsync()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("\n\n");
                ConsoleHelper.PrintHeader("📋 PRODUCT LIST", 7);
                Console.WriteLine("\n\n");

                HttpClient httpClient = new HttpClient();

                httpClient.BaseAddress =
                    new Uri("http://localhost:5276/api/Products/");

                var respone = await httpClient.GetAsync("");

                if (respone.IsSuccessStatusCode)
                {
                    var L_Products =
                        await respone.Content.ReadFromJsonAsync<List<ProductDTO>>();

                    if (L_Products == null || !L_Products.Any())
                    {
                        ConsoleHelper.ShowNotFoundMessage(
                            "⚠️ NO PRODUCTS FOUND",
                            "No products were found.");

                        return;
                    }

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(4)}{"ID",-15} {"Product",-25} {"Category",-18} {"Price",-15} {"Stock",-10} {"Status",-12}");

                    Console.Write(
                        $"{ConsoleHelper.GenarateTabs(4)}{new string('-', 101)}{Environment.NewLine}");

                    foreach (var item in L_Products)
                    {
                        Console.WriteLine(
                            $"{ConsoleHelper.GenarateTabs(4)}{item.ProductID,-15} " +
                            $"{item.ProductName,-25} " +
                            $"{item.Category,-18} " +
                            $"{item.Price.ToString("N2"),-15} " +
                            $"{item.StockQuantity,-10} " +
                            $"{item.Status,-12}");
                    }

                    Console.Write(
                        $"{ConsoleHelper.GenarateTabs(4)}{new string('-', 101)}{Environment.NewLine}");

                    Console.WriteLine(
                        $"\n\n{ConsoleHelper.GenarateTabs(4)}Total Products: {L_Products.Count}");

                    return;
                }

                ConsoleHelper.ShowNotFoundMessage(
                    "⚠️ NO DATA FOUND",
                    $"{await respone.Content.ReadAsStringAsync()}");
            }
            catch (Exception ex)
            {
                ConsoleHelper.ShowNotFoundMessage(
                    "❌ SYSTEM ERROR",
                    ex.Message,
                    "your request. Please try again.");
            }
        }

        public static async Task GetProductByIDAsync()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("\n\n");
                ConsoleHelper.PrintHeader("🔎 GET PRODUCT BY ID", 7);
                Console.WriteLine("\n\n");

                int productID = InputHelper.ReadTheID("🔎 GET PRODUCT BY ID", "Enter Product ID: ");

                HttpClient httpClient = new HttpClient();

                httpClient.BaseAddress =
                    new Uri("http://localhost:5276/api/Products/");

                var respone = await httpClient.GetAsync($"{productID}");

                if (respone.IsSuccessStatusCode)
                {
                    var product =
                        await respone.Content.ReadFromJsonAsync<ProductDTO>();

                    if (product is null)
                    {
                        ConsoleHelper.ShowNotFoundMessage(
                            "⚠️ PRODUCT NOT FOUND",
                            "No product was found.");

                        return;
                    }

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}╔══════════════════════════════════════════════╗");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║              📦 PRODUCT DETAILS              ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}╠══════════════════════════════════════════════╣");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ Product ID       : {product.ProductID,-25} ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ Product Name     : {product.ProductName,-25} ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ Category         : {product.Category,-25} ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ Price            : {product.Price.ToString("N2"),-25} ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ Stock Quantity   : {product.StockQuantity,-25} ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ Status           : {product.Status,-25} ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}╚══════════════════════════════════════════════╝");

                    return;
                }

                ConsoleHelper.ShowNotFoundMessage(
                    "❌ PRODUCT NOT FOUND",
                    $"Product with ID {productID} was not found.");
            }
            catch (Exception ex)
            {
                ConsoleHelper.ShowNotFoundMessage(
                    "❌ SYSTEM ERROR",
                    ex.Message,
                    "your request. Please try again.");
            }
        }

        public static async Task AddNewProductAsync()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("\n\n");

                ConsoleHelper.PrintHeader("➕ ADD PRODUCT", 7);

                Console.WriteLine("\n");

                Console.Write($"{ConsoleHelper.GenarateTabs(7)}Product Name      : ");

                string productName = Console.ReadLine()!;

                while (true)
                {
                    bool isPass = true;

                    if (string.IsNullOrWhiteSpace(productName))
                        isPass = false;
                    else
                    {
                        foreach (char c in productName)
                            if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                            {
                                isPass = false;
                                break;
                            }
                    }

                    if (!isPass)
                    {
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}{"Invalid! Product Name      : "}: ");
                        productName = Console.ReadLine()!;
                    }
                    else
                        break;
                }


                Console.Write($"{ConsoleHelper.GenarateTabs(7)}Category          : ");
                string category = Console.ReadLine()!;

                while (true)
                {
                    bool isPass = true;

                    if (string.IsNullOrWhiteSpace(category))
                        isPass = false;
                    else
                    {
                        foreach (char c in category)
                            if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                            {
                                isPass = false;
                                break;
                            }
                    }

                    if (!isPass)
                    {
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}{"Invalid! Category          : "}: ");
                        category = Console.ReadLine()!;
                    }
                    else
                        break;
                }

                Console.Write($"{ConsoleHelper.GenarateTabs(7)}Price             : ");
                decimal price = 0.0m;

                while (!Decimal.TryParse(Console.ReadLine(), out price))
                    Console.Write($"{ConsoleHelper.GenarateTabs(7)}{"Invalid! Price          : "}: ");

                Console.Write($"{ConsoleHelper.GenarateTabs(7)}Initial Stock     : ");

                int stockQuantity = 0;

                while (!int.TryParse(Console.ReadLine(), out stockQuantity))
                    Console.Write($"{ConsoleHelper.GenarateTabs(7)}{"Invalid! Stock Quantity          : "}: ");

                Console.Write($"{ConsoleHelper.GenarateTabs(7)}Status            : ");
                string status = Console.ReadLine()!;

                while (true)
                {
                    bool isPass = true;

                    if (string.IsNullOrWhiteSpace(status))
                        isPass = false;
                    else
                    {
                        foreach (char c in status)
                            if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                            {
                                isPass = false;
                                break;
                            }
                    }

                    if (!isPass)
                    {
                        Console.Write($"{ConsoleHelper.GenarateTabs(7)}{"Invalid! Status            : ",-16}: ");
                        status = Console.ReadLine()!;
                    }
                    else
                        break;
                }

                ProductRequestDTO productRequest = new ProductRequestDTO(
                    productName,
                    category,
                    price,
                    stockQuantity,
                    status
                );


                HttpClient httpClient = new HttpClient();

                httpClient.BaseAddress =
                    new Uri("http://localhost:5276/api/Products/");


                var respone =
                    await httpClient.PostAsJsonAsync("", productRequest);


                if (respone.IsSuccessStatusCode)
                {
                    ProductDTO? product =
                        await respone.Content.ReadFromJsonAsync<ProductDTO>();

                    if (product == null)
                    {
                        ConsoleHelper.ShowNotFoundMessage(
                            "❌ PRODUCT NOT ADDED",
                            "Failed to read the created product.");

                        return;
                    }


                    Console.WriteLine("\n\n");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}╔══════════════════════════════════════════════╗");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║             ✅ PRODUCT ADDED                 ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}╠══════════════════════════════════════════════╣");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ Product ID       : {product.ProductID,-25} ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ Product Name     : {product.ProductName,-25} ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ Category         : {product.Category,-25} ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ Price            : {product.Price.ToString("N2"),-25} ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ Initial Stock    : {product.StockQuantity,-25} ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ Status           : {product.Status,-25} ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}╚══════════════════════════════════════════════╝");

                    return;
                }


                ConsoleHelper.ShowNotFoundMessage(
                    "❌ PRODUCT NOT ADDED",
                    await respone.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                ConsoleHelper.ShowNotFoundMessage(
                    "❌ SYSTEM ERROR",
                    ex.Message,
                    "your request. Please try again.");
            }
        }

        public static async Task UpdateProductAsync()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("\n\n");

                ConsoleHelper.PrintHeader("✏️  EDIT PRODUCT", 7);

                Console.WriteLine("\n");

                Console.Write($"{ConsoleHelper.GenarateTabs(7)}Product ID   : ");

                int productID = 0;

                while (!int.TryParse(Console.ReadLine(), out productID) || productID <= 0)
                    Console.Write($"{ConsoleHelper.GenarateTabs(7)}Invalid! Product ID : ");


                Console.Write($"{ConsoleHelper.GenarateTabs(7)}Product Name : ");
                string productName = Console.ReadLine()!;

                while (true)
                {
                    bool isPass = true;

                    if (string.IsNullOrWhiteSpace(productName))
                        isPass = false;
                    else
                    {
                        foreach (char c in productName)
                        {
                            if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                            {
                                isPass = false;
                                break;
                            }
                        }
                    }

                    if (!isPass)
                    {
                        Console.Write(
                            $"{ConsoleHelper.GenarateTabs(7)}Invalid! Product Name : ");

                        productName = Console.ReadLine()!;
                    }
                    else
                        break;
                }


                Console.Write($"{ConsoleHelper.GenarateTabs(7)}Category     : ");
                string category = Console.ReadLine()!;

                while (true)
                {
                    bool isPass = true;

                    if (string.IsNullOrWhiteSpace(category))
                        isPass = false;
                    else
                    {
                        foreach (char c in category)
                        {
                            if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                            {
                                isPass = false;
                                break;
                            }
                        }
                    }

                    if (!isPass)
                    {
                        Console.Write(
                            $"{ConsoleHelper.GenarateTabs(7)}Invalid! Category : ");

                        category = Console.ReadLine()!;
                    }
                    else
                        break;
                }


                Console.Write($"{ConsoleHelper.GenarateTabs(7)}Price        : ");

                decimal price = 0.0m;

                while (!decimal.TryParse(Console.ReadLine(), out price) || price <= 0)
                    Console.Write($"{ConsoleHelper.GenarateTabs(7)}Invalid! Price : ");


                Console.Write($"{ConsoleHelper.GenarateTabs(7)}Status       : ");
                string status = Console.ReadLine()!;

                while (string.IsNullOrWhiteSpace(status))
                {
                    Console.Write(
                        $"{ConsoleHelper.GenarateTabs(7)}Invalid! Status : ");

                    status = Console.ReadLine()!;
                }


                ProductUpdateDTO productUpdate = new ProductUpdateDTO(
                    productName,
                    category,
                    price,
                    status
                );


                using HttpClient httpClient = new HttpClient();

                httpClient.BaseAddress =
                    new Uri("http://localhost:5276/api/Products/");


                var respone =
                    await httpClient.PutAsJsonAsync(
                        $"{productID}",
                        productUpdate
                    );


                if (respone.IsSuccessStatusCode)
                {
                    Console.WriteLine("\n\n");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}╔══════════════════════════════════════════════╗");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║           ✅ PRODUCT UPDATED                 ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}╠══════════════════════════════════════════════╣");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ Product ID       : {productID,-25} ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ Product Name     : {productName,-25} ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ Category         : {category,-25} ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ Price            : {price.ToString("N2"),-25} ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ Status           : {status,-25} ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}╚══════════════════════════════════════════════╝");

                    return;
                }


                ConsoleHelper.ShowNotFoundMessage(
                    "❌ PRODUCT NOT UPDATED",
                    await respone.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                ConsoleHelper.ShowNotFoundMessage(
                    "❌ SYSTEM ERROR",
                    ex.Message,
                    "your request. Please try again.");
            }
        }

        public static async Task DeleteProductAsync()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("\n\n");

                ConsoleHelper.PrintHeader("🗑️ DELETE PRODUCT", 7);

                Console.WriteLine("\n");


                int productID = InputHelper.ReadTheID("🔎 GET PRODUCT BY ID", "Enter Product ID: ");

                using HttpClient httpClient = new HttpClient();

                httpClient.BaseAddress =
                    new Uri("http://localhost:5276/api/Products/");


                var respone =
                    await httpClient.DeleteAsync($"{productID}");


                if (respone.IsSuccessStatusCode)
                {
                    Console.WriteLine("\n\n");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}╔══════════════════════════════════════════════╗");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║            ✅ PRODUCT DELETED                ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}╠══════════════════════════════════════════════╣");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ Product with ID {productID,-27}║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}║ was deleted successfully.                    ║");

                    Console.WriteLine(
                        $"{ConsoleHelper.GenarateTabs(7)}╚══════════════════════════════════════════════╝");

                    return;
                }


                if (respone.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    ConsoleHelper.ShowNotFoundMessage(
                        "❌ PRODUCT NOT FOUND",
                        $"Product with ID {productID} was not found.");

                    return;
                }


                ConsoleHelper.ShowNotFoundMessage(
                    "❌ PRODUCT NOT DELETED",
                    await respone.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                ConsoleHelper.ShowNotFoundMessage(
                    "❌ SYSTEM ERROR",
                    ex.Message,
                    "your request. Please try again.");
            }
        }
    }
}
```

### `NovaBusinessSystemPL/Program.cs`

```cs
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
```

## 6. Selected documentation and local launch settings

Sensitive appsettings files, environment files, and user secrets are excluded.
Review launch settings before sharing if they contain private values.

### `NovaBusinessSystem.API/Properties/launchSettings.json`

```json
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
```

### `README.md`

```markdown
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
```

## 7. Required agent instructions

- Treat backend source and verified API responses as the source of truth.
- Do not invent routes, DTO fields, records, business rules, or successful API responses.
- Identify missing or ambiguous contracts and request only the specific missing information.
- Do not expose secrets or copy credentials into frontend code.
- Verify routes and response schemas against Swagger/OpenAPI or the running API when available.
- Clearly distinguish source-code findings from runtime-verified behavior.
- Build the UI shell and design system without fake business data while contracts are being verified.
- Connect each feature only after its actual contract is established.
