namespace FSH.WebApi.Application.HMS.Employees;

public class EmployeeDto : IDto
{
    public DefaultIdType Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Address { get; set; }
    public string? Notes { get; set; }
    public string? ImagePath { get; set; }
    public DefaultIdType DepartmentId { get; set; }
    public string DepartmentName { get; set; } = default!;
}