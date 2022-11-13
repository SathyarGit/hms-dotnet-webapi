using FSH.WebApi.Application.HMS.Bookingstatuses;
using FSH.WebApi.Application.HMS.Customers;
using FSH.WebApi.Application.HMS.Folios;
using FSH.WebApi.Application.HMS.Travelagents;

namespace FSH.WebApi.Application.HMS.Bookings;

public class BookingDetailsDto : IDto
{
    public DefaultIdType Id { get; set; }
    public DateTime? CheckinDate { get; set; }
    public DateTime? CheckoutDate { get; set; }
    public int? NumberOfRooms { get; set; }
    public int? NumberOfAdults { get; set; }
    public int? NumberOfChildren { get; set; }
    public int? Amount { get; set; }
    public string? Notes { get; set; }
    public bool? BookingMaterialised { get; set; }
    public BookingstatusDto Bookingstatus { get; set; } = default!;
    public CustomerDto Customer { get; set; } = default!;
    public TravelagentDto Travelagent { get; set; } = default!;
    public FolioDto Folio { get; set; } = default!;
}