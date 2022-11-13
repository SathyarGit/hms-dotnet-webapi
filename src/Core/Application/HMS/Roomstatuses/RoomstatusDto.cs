namespace FSH.WebApi.Application.HMS.Roomstatuses;

public class RoomstatusDto : IDto
{
    public DefaultIdType Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}