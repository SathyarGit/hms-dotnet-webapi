namespace FSH.WebApi.Application.HMS.Folios;

public class FolioDto : IDto
{
    public DefaultIdType Id { get; set; }
    public DefaultIdType? BookingId { get; set; }
    public DefaultIdType? FoliotypeId { get; set; }
    public string? Description { get; set; }
    public string FoliotypeName { get; set; } = default!;
}