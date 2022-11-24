namespace FSH.WebApi.Application.HMS.Purchases;

public class PurchaseDto : IDto
{
    public DefaultIdType Id { get; set; }
    public DateTime? PurchaseDate { get; set; }
    public DefaultIdType? VendorId { get; set; }
    public int? Amount { get; set; }
    public string? Description { get; set; }
    public DefaultIdType? DepartmentId { get; set; }
    public string? BillsOrInvoiceNumber { get; set; }
    public string? ImagePath { get; set; }
    public DefaultIdType? TransactionstatusId { get; set; }
    public string DepartmentName { get; set; } = default!;
    public string VendorName { get; set; } = default!;
    public string TransactionstatusName { get; set; } = default!;
}