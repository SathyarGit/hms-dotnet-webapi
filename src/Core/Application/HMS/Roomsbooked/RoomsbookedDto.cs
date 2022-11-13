namespace FSH.WebApi.Application.HMS.Roomsbookeds;

public class RoomsbookedDto : IDto
{
    public DefaultIdType Id { get; set; }
    public int? RoomRate { get; set; }
    public DefaultIdType? RoomId { get; set; }
    public DefaultIdType? BookingId { get; set; }
    public string RoomNumber { get; set; } = default!;
}