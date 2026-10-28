
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

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(EmployeeResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]


    public async Task<Results<Ok<EmployeeResponseDto>, BadRequest<string>, NotFound<string>>> GetEmployeeById([FromRoute(Name = "id")] int id)
    {
        if (id <= 0)
            return TypedResults.BadRequest("Invalid data");

        EmployeesBL? emp = await _employeeBL.FindEmployeeByAsync(id);

        if (emp is null)
            return TypedResults.NotFound("Not found employee");

        return TypedResults.Ok(emp.Dto);
    }
}