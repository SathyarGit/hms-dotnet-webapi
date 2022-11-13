namespace FSH.WebApi.Application.HMS.Purchases;

public class PurchaseExportDto : IDto
{
    public DateTime? PurchaseDate { get; set; }
    public int? Amount { get; set; }
    public string? Description { get; set; }
    public string? BillsOrInvoiceNumber { get; set; }
    public string DepartmentName { get; set; } = default!;
    public string VendorName { get; set; } = default!;
    public string Transactionstatus { get; set; } = default!;
}