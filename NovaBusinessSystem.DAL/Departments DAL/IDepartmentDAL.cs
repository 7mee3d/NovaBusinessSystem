using NovaBusinessSystem.DTOs.Departments;

public interface IDepartmentDAL
{
    Task<DepartmentResponseDto> GetDepartmentAsync(int departmentID);

}