using FSH.WebApi.Application.HMS.Departments;
using FSH.WebApi.Application.HMS.Foliotypes;
using FSH.WebApi.Application.HMS.Bookings;

namespace FSH.WebApi.Application.HMS.Folios;

public class FolioDetailsDto : IDto
{
    public DefaultIdType Id { get; set; }
    public string? Description { get; set; }
    public FoliotypeDto Foliotype { get; set; } = default!;
    public BookingDto Booking { get; set; } = default!;
}