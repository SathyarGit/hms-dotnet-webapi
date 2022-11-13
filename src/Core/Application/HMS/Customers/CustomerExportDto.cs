namespace FSH.WebApi.Application.HMS.Customers;

public class CustomerExportDto : IDto
{
    public string Name { get; set; } = default!;
    public string AddressLine1 { get; set; } = default!;
    public string AddressLine2 { get; set; } = default!;
    public string City { get; set; } = default!;
    public string Country { get; set; } = default!;
    public string Pincode { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Notes { get; set; } = default!;
    public string? ImagePath { get; set; }
    public string CustomerclassificationName { get; set; } = default!;
}