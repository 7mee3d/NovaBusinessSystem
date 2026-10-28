
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NovaBusinessSystem.BL;
using NovaBusinessSystem.DTOs.Employees;

[ApiController]
[Route("api/Employees")]
public class EmployeesController : ControllerBase
{

    private readonly EmployeesBL _employeeBL;

    public EmployeesController(EmployeesBL employeesBL)
    {
        this._employeeBL = employeesBL;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<EmployeeDetailsResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<Ok<IEnumerable<EmployeeDetailsResponseDto>>> GetEmployeeDetails()
    {
        return TypedResults.Ok(await _employeeBL.GetEmployeeDetailsResponsesAsync());
    }
}