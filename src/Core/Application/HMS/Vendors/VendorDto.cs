namespace FSH.WebApi.Application.HMS.Vendors;

public class VendorDto : IDto
{
    public DefaultIdType Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public string? Notes { get; set; }
}