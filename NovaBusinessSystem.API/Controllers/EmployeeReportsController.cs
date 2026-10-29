
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
