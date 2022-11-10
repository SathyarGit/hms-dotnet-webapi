namespace FSH.WebApi.Domain.HMS;

public class Charge : AuditableEntity, IAggregateRoot
{
    public DateTime? ChargeDate { get; private set; }
    public DefaultIdType? FolioId { get; private set; }
    public int? Amount { get; private set; }
    public string? Description { get; private set; }
    public DefaultIdType? DepartmentId { get; private set; }
    public DefaultIdType? TransactionstatusId { get; private set; }
    public DefaultIdType? TravelagentId { get; private set; }

    public virtual Folio Folio { get; set; } = default!;
    public virtual Department Department { get; set; } = default!;
    public virtual Travelagent Travelagent { get; set; } = default!;
    public virtual Transactionstatus Transactionstatus { get; set; } = default!;


    public Charge(DateTime? chargeDate, DefaultIdType? folioId, int? amount, string? description, DefaultIdType? departmentId, DefaultIdType? transactionstatusId, DefaultIdType? travelagentId)
    {
        ChargeDate = chargeDate;
        FolioId = folioId;
        Amount = amount;
        Description = description;
        DepartmentId = departmentId;
        TransactionstatusId = transactionstatusId;
        TravelagentId = travelagentId;
    }

    public Charge Update(DateTime? chargeDate, DefaultIdType? folioId, int? amount, string? description, DefaultIdType? departmentId, DefaultIdType? transactionstatusId, DefaultIdType? travelagentId)
    {
        if (chargeDate.HasValue && ChargeDate != chargeDate) ChargeDate = chargeDate.Value;
        if (folioId.HasValue && folioId.Value != DefaultIdType.Empty && !FolioId.Equals(folioId.Value)) FolioId = folioId.Value;
        if (amount.HasValue && Amount != amount) Amount = amount.Value;
        if (description is not null && Description?.Equals(description) is not true) Description = description;
        if (departmentId.HasValue && departmentId.Value != DefaultIdType.Empty && !DepartmentId.Equals(departmentId.Value)) DepartmentId = departmentId.Value;
        if (transactionstatusId.HasValue && transactionstatusId.Value != DefaultIdType.Empty && !TransactionstatusId.Equals(transactionstatusId.Value)) TransactionstatusId = transactionstatusId.Value;
        if (travelagentId.HasValue && travelagentId.Value != DefaultIdType.Empty && !TravelagentId.Equals(travelagentId.Value)) TravelagentId = travelagentId.Value;
        return this;
    }
}