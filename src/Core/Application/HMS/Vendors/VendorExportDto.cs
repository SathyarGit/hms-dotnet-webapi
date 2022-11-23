namespace FSH.WebApi.Application.HMS.Vendors;

public class VendorExportDto : IDto
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Notes { get; set; } = default!;
}