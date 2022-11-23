namespace FSH.WebApi.Application.HMS.Employees;

public class EmployeeExportDto : IDto
{
    public string Name { get; set; } = default!;
    public string? Address { get; set; } = default!;
    public string Notes { get; set; } = default!;
    public string DepartmentName { get; set; } = default!;
}