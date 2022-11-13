using FSH.WebApi.Application.HMS.Departments;
using FSH.WebApi.Application.HMS.Transactionstatuses;
using FSH.WebApi.Application.HMS.Vendors;

namespace FSH.WebApi.Application.HMS.Purchases;

public class PurchaseDetailsDto : IDto
{
    public DefaultIdType Id { get; set; }
    public DateTime? PurchaseDate { get; set; }
    public int? Amount { get; set; }
    public string? Description { get; set; }
    public string? BillsOrInvoiceNumber { get; set; }
    public string? ImagePath { get; set; }
    public DepartmentDto Department { get; set; } = default!;
    public VendorDto Vendor { get; set; } = default!;
    public TransactionstatusDto Transactionstatus { get; set; } = default!;
}