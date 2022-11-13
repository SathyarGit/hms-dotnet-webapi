namespace FSH.WebApi.Application.HMS.Customers;

public class CustomerDto : IDto
{
    public DefaultIdType Id { get; set; }
    public string? Name { get; set; } = default!;
    public string? AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
    public string? Pincode { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? Notes { get; set; }
    public string? ImagePath { get; set; }
    public DefaultIdType? CustclassificationId { get; set; }
    public string CustomerclassificationName { get; set; } = default!;
}