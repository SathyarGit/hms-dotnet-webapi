namespace FSH.WebApi.Application.HMS.Transactiontypes;

public class TransactiontypeDto : IDto
{
    public DefaultIdType Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}