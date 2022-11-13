namespace FSH.WebApi.Application.HMS.Rooms;

public class RoomExportDto : IDto
{
    public int RoomNumber { get; set; }
    public int NumberOfBeds { get; set; }
    public string? Notes { get; set; }
    public string? MaintenanceNotes { get; set; }
    public string FloorName { get; set; } = default!;
    public string RoomtypeName { get; set; } = default!;
}