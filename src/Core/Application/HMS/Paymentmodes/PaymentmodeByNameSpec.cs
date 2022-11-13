namespace FSH.WebApi.Application.HMS.Paymentmodes;

public class PaymentmodeByNameSpec : Specification<Paymentmode>, ISingleResultSpecification
{
    public PaymentmodeByNameSpec(string name) =>
        Query.Where(p => p.Name == name);
}