namespace FSH.WebApi.Application.HMS.Rooms;

public class RoomDto : IDto
{
    public DefaultIdType Id { get; set; }
    public int RoomNumber { get; set; }
    public int NumberOfBeds { get; set; }
    public string? Notes { get; set; }
    public string? MaintenanceNotes { get; set; }
    public string? ImagePath { get; set; }
    public DefaultIdType FloorId { get; set; }
    public string FloorName { get; set; } = default!;
}