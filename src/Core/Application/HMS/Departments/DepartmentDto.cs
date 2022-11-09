namespace FSH.WebApi.Application.HMS.Departments;

public class DepartmentDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}