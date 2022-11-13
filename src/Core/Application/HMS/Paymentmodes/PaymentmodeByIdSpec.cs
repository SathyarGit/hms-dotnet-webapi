namespace FSH.WebApi.Application.HMS.Paymentmodes;

public class PaymentmodeByIdSpec : Specification<Paymentmode, PaymentmodeDto>, ISingleResultSpecification
{
    public PaymentmodeByIdSpec(DefaultIdType id) =>
        Query
            .Where(p => p.Id == id);
}