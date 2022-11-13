namespace FSH.WebApi.Application.HMS.Paymentmodes;

public class PaymentmodeDto : IDto
{
    public DefaultIdType Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}