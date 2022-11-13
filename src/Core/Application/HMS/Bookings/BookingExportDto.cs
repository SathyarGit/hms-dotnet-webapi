namespace FSH.WebApi.Application.HMS.Bookings;

public class BookingExportDto : IDto
{
    public DateTime? CheckinDate { get; set; } = default(DateTime?);
    public DateTime? CheckoutDate { get; set; } = default!;
    public int? NumberOfRooms { get; set; } = default!;
    public int? NumberOfAdults { get; set; } = default!;
    public int? NumberOfChildren { get; set; } = default!;
    public int? Amount { get; set; } = default!;
    public string? Notes { get; set; } = default!;
    public bool? BookingMaterialised { get; set; } = default!;
    public string BookingstatusName { get; set; } = default!;
    public string CustomerName { get; set; } = default!;
    public string TravelagentName { get; set; } = default!;
}