namespace FSH.WebApi.Application.HMS.Paymentmodes;

public class SearchPaymentmodesRequest : PaginationFilter, IRequest<PaginationResponse<PaymentmodeDto>>
{
}

public class SearchPaymentmodesRequestHandler : IRequestHandler<SearchPaymentmodesRequest, PaginationResponse<PaymentmodeDto>>
{
    private readonly IReadRepository<Paymentmode> _repository;

    public SearchPaymentmodesRequestHandler(IReadRepository<Paymentmode> repository) => _repository = repository;

    public async Task<PaginationResponse<PaymentmodeDto>> Handle(SearchPaymentmodesRequest request, CancellationToken cancellationToken)
    {
        var spec = new PaymentmodesBySearchRequestSpec(request);
        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken: cancellationToken);
    }
}