namespace FSH.WebApi.Application.HMS.Charges;

public class ChargeDto : IDto
{
    public DefaultIdType Id { get; set; }
    public DateTime? ChargeDate { get; set; }
    public DefaultIdType? FolioId { get; set; }
    public int? Amount { get; set; }
    public string? Description { get; set; }
    public DefaultIdType? DepartmentId { get; set; }
    public DefaultIdType? TransactionstatusId { get; set; }
    public DefaultIdType? TravelagentId { get; set; }
    public string DepartmentName { get; set; } = default!;
    public string TransactionstatusName { get; set; } = default!;
    public string TravelagentName { get; set; } = default!;
 }