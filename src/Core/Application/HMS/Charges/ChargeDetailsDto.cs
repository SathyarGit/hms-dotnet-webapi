using FSH.WebApi.Application.HMS.Departments;
using FSH.WebApi.Application.HMS.Folios;
using FSH.WebApi.Application.HMS.Transactionstatuses;
using FSH.WebApi.Application.HMS.Travelagents;

namespace FSH.WebApi.Application.HMS.Charges;

public class ChargeDetailsDto : IDto
{
    public DefaultIdType Id { get; set; }
    public DateTime? ChargeDate { get; set; }
    public int? Amount { get; set; }
    public string? Description { get; set; }
    public FolioDto Folio { get; set; } = default!;
    public DepartmentDto Department { get; set; } = default!;
    public TransactionstatusDto Transactionstatus { get; set; } = default!;
    public TravelagentDto Travelagent { get; set; } = default!;
}