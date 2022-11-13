namespace FSH.WebApi.Application.HMS.Customerclassifications;

public class CustomerclassificationDto : IDto
{
    public DefaultIdType Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}