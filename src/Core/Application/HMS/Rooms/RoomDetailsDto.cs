using FSH.WebApi.Application.HMS.Floors;

namespace FSH.WebApi.Application.HMS.Rooms;

public class RoomDetailsDto : IDto
{
    public DefaultIdType Id { get; set; }
    public int RoomNumber { get; set; }
    public int NumberOfBeds { get; set; }
    public string? Notes { get; set; }
    public string? MaintenanceNotes { get; set; }
    public string? ImagePath { get; set; }
    public FloorDto Floor { get; set; } = default!;
}