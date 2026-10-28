namespace NovaBusinessSystem.DTOs.Departments
{
    public record DepartmentResponseDto(
        int DepartmentID,
        string DepartmentName,
        string Location,
        decimal Budget
    );
}