namespace FSH.WebApi.Domain.HMS;

public class Accountentry : AuditableEntity, IAggregateRoot
{
    public DateTime? TransactionDate { get; private set; }
    public DefaultIdType? FolioId { get; private set; }
    public DefaultIdType? PurchaseId { get; private set; }
    public DefaultIdType? PaymentmodeId { get; private set; }
    public DefaultIdType? DepartmentId { get; private set; }
    public DefaultIdType? ExpensecategoryId { get; private set; }
    public int? Amount { get; private set; }
    public DefaultIdType? TransactiontypeId { get; private set; }
    public string? Description { get; private set; }

    public virtual Folio Folio { get; set; } = default!;
    public virtual Purchase Purchase { get; set; } = default!;
    public virtual Paymentmode Paymentmode { get; set; } = default!;
    public virtual Department Department { get; set; } = default!;
    public virtual Expensecategory Expensecategory { get; set; } = default!;
    public virtual Transactiontype Transactiontype { get; set; } = default!;

    public Accountentry(DateTime? transactionDate, DefaultIdType? folioId, DefaultIdType? purchaseId, DefaultIdType? paymentmodeId, DefaultIdType? departmentId, DefaultIdType? expensecategoryId, int? amount, DefaultIdType? transactiontypeId, string? description)
    {
        TransactionDate = transactionDate;
        FolioId = folioId;
        PurchaseId = purchaseId;
        PaymentmodeId = paymentmodeId;
        DepartmentId = departmentId;
        ExpensecategoryId = expensecategoryId;
        Amount = amount;
        TransactiontypeId = transactiontypeId;
        Description = description;
    }

    public Accountentry Update(DateTime? transactionDate, DefaultIdType? folioId, DefaultIdType? purchaseId, DefaultIdType? paymentmodeId, DefaultIdType? departmentId, DefaultIdType? expensecategoryId, int? amount, DefaultIdType? transactiontypeId, string? description)
    {
        if (transactionDate.HasValue && TransactionDate != transactionDate) TransactionDate = transactionDate.Value;
        if (folioId.HasValue && folioId.Value != DefaultIdType.Empty && !FolioId.Equals(folioId.Value)) FolioId = folioId.Value;
        if (purchaseId.HasValue && purchaseId.Value != DefaultIdType.Empty && !PurchaseId.Equals(purchaseId.Value)) PurchaseId = purchaseId.Value;
        if (paymentmodeId.HasValue && paymentmodeId.Value != DefaultIdType.Empty && !PaymentmodeId.Equals(paymentmodeId.Value)) PaymentmodeId = paymentmodeId.Value;
        if (departmentId.HasValue && departmentId.Value != DefaultIdType.Empty && !DepartmentId.Equals(departmentId.Value)) DepartmentId = departmentId.Value;
        if (expensecategoryId.HasValue && expensecategoryId.Value != DefaultIdType.Empty && !ExpensecategoryId.Equals(expensecategoryId.Value)) ExpensecategoryId = expensecategoryId.Value;
        if (amount.HasValue && Amount != amount) Amount = amount.Value;
        if (transactiontypeId.HasValue && transactiontypeId.Value != DefaultIdType.Empty && !TransactiontypeId.Equals(transactiontypeId.Value)) TransactiontypeId = transactiontypeId.Value;
        if (description is not null && Description?.Equals(description) is not true) Description = description;
        return this;
    }
}