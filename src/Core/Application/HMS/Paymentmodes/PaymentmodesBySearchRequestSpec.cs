namespace FSH.WebApi.Application.HMS.Paymentmodes;

public class PaymentmodesBySearchRequestSpec : EntitiesByPaginationFilterSpec<Paymentmode, PaymentmodeDto>
{
    public PaymentmodesBySearchRequestSpec(SearchPaymentmodesRequest request)
        : base(request) =>
        Query
            .OrderBy(c => c.Name, !request.HasOrderBy());
}