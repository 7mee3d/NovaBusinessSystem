namespace NovaBusinessSystem.DTOs.Employees;

public record EmployeeSalarySummaryResponseDto(

    decimal MinimumSalary,
    decimal MaximumSalary,
    decimal AverageSalary,
    decimal TotalSalary
);