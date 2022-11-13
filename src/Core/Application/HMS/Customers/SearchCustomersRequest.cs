namespace FSH.WebApi.Application.HMS.Customers;

public class SearchCustomersRequest : PaginationFilter, IRequest<PaginationResponse<CustomerDto>>
{
    public DefaultIdType? CustclassificationId { get; set; }
}

public class SearchCustomersRequestHandler : IRequestHandler<SearchCustomersRequest, PaginationResponse<CustomerDto>>
{
    private readonly IReadRepository<Customer> _repository;

    public SearchCustomersRequestHandler(IReadRepository<Customer> repository) => _repository = repository;

    public async Task<PaginationResponse<CustomerDto>> Handle(SearchCustomersRequest request, CancellationToken cancellationToken)
    {
        var spec = new CustomersBySearchRequestWithCustomerclassificationsSpec(request);
        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken: cancellationToken);
    }
}