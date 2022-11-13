namespace FSH.WebApi.Application.HMS.Bookings;

public class BookingDto : IDto
{
    public DefaultIdType Id { get; set; }
    public DateTime? CheckinDate { get; set; }
    public DateTime? CheckoutDate { get; set; }
    public int? NumberOfRooms { get; set; }
    public int? NumberOfAdults { get; set; }
    public int? NumberOfChildren { get; set; }
    public DefaultIdType? BookingstatusId { get; set; }
    public int? Amount { get; set; }
    public string? Notes { get; set; }
    public bool? BookingMaterialised { get; set; }
    public DefaultIdType? CustomerId { get; set; }
    public DefaultIdType? TravelagentId { get; set; }
    public DefaultIdType? FolioId { get; set; }
    public string BookingstatusName { get; set; } = default!;
    public string CustomerName { get; set; } = default!;
    public string TravelagentName { get; set; } = default!;
 }