namespace FSH.WebApi.Application.HMS.Charges;

public class ChargeExportDto : IDto
{
    public DateTime? ChargeDate { get; set; } = default(DateTime?);
    public int? Amount { get; set; } = default!;
    public string? Description { get; set; } = default!;
    public string DepartmentName { get; set; } = default!;
    public string TransactionstatusName { get; set; } = default!;
    public string TravelagentName { get; set; } = default!;
}