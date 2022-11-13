namespace FSH.WebApi.Application.HMS.Floors;

public class FloorDetailsDto : IDto
{
    public DefaultIdType Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}