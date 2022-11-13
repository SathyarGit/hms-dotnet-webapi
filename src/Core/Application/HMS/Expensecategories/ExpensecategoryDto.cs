namespace FSH.WebApi.Application.HMS.Expensecategories;

public class ExpensecategoryDto : IDto
{
    public DefaultIdType Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}