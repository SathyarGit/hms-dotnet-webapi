namespace FSH.WebApi.Application.HMS.Foliotypes;

public class FoliotypeDto : IDto
{
    public DefaultIdType Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}