namespace FSH.WebApi.Application.HMS.Accountentries;

public class AccountentryExportDto : IDto
{
    public DateTime? TransactionDate { get; private set; } = default(DateTime?);
    public int? Amount { get; set; } = default!;
    public string? Description { get; set; } = default!;
    public string PaymentmodeName { get; set; } = default!;
    public string DepartmentName { get; set; } = default!;
    public string ExpensecategoryName { get; set; } = default!;
    public string TransactiontypeName { get; set; } = default!;
}