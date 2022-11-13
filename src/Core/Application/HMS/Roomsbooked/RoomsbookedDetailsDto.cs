using FSH.WebApi.Application.HMS.Rooms;
using FSH.WebApi.Application.HMS.Bookings;

namespace FSH.WebApi.Application.HMS.Roomsbookeds;

public class RoomsbookedDetailsDto : IDto
{
    public DefaultIdType Id { get; set; }
    public int? RoomRate { get; set; }
    public DefaultIdType? RoomId { get; set; }
    public DefaultIdType? BookingId { get; set; }
    public string RoomNumber { get; set; } = default!;
    public RoomDto Room { get; set; } = default!;
    public BookingDto Booking { get; set; } = default!;
}