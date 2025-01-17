namespace FSH.WebApi.Application.HMS.Bookingstatuses;

public class BookingstatusDto : IDto
{
    public DefaultIdType Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}