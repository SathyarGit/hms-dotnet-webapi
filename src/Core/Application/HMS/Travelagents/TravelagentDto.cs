namespace FSH.WebApi.Application.HMS.Travelagents;

public class TravelagentDto : IDto
{
    public DefaultIdType Id { get; set; }
    public string Name { get; set; } = default!;
    public string? AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
    public string? Pincode { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? Notes { get; set; }
}