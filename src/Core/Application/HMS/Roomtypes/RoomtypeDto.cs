namespace FSH.WebApi.Application.HMS.Roomtypes;

public class RoomtypeDto : IDto
{
    public DefaultIdType Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}