namespace FSH.WebApi.Application.HMS.Accountentries;

public class AccountentryDto : IDto
{
    public DefaultIdType Id { get; set; }
    public DateTime? TransactionDate { get; set; }
    public DefaultIdType? FolioId { get; set; }
    public DefaultIdType? PurchaseId { get; set; }
    public DefaultIdType? PaymentmodeId { get; set; }
    public DefaultIdType? DepartmentId { get; set; }
    public DefaultIdType? ExpensecategoryId { get; set; }
    public int? Amount { get; set; }
    public DefaultIdType? TransactiontypeId { get; set; }
    public string? Description { get; set; }
    public string PaymentmodeName { get; set; } = default!;
    public string DepartmentName { get; set; } = default!;
    public string ExpensecategoryName { get; set; } = default!;
    public string TransactiontypeName { get; set; } = default!;
 }