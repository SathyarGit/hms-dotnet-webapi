using FSH.WebApi.Application.HMS.Departments;

namespace FSH.WebApi.Application.HMS.Employees;

public class EmployeeDetailsDto : IDto
{
    public DefaultIdType Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Address { get; set; }
    public string? Notes { get; set; }
    public string? ImagePath { get; set; }
    public DepartmentDto Department { get; set; } = default!;
}