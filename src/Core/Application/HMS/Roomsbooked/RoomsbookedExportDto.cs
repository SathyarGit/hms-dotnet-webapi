namespace FSH.WebApi.Application.HMS.Roomsbookeds;

public class RoomsbookedExportDto : IDto
{
    public int? RoomRate { get; set; } = default!;
    public string RoomNumber { get; set; } = default!;
}