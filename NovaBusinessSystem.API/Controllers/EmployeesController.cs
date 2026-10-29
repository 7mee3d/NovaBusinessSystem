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
