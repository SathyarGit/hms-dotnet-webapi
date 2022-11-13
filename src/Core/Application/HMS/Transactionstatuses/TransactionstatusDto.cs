namespace FSH.WebApi.Application.HMS.Transactionstatuses;

public class TransactionstatusDto : IDto
{
    public DefaultIdType Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}