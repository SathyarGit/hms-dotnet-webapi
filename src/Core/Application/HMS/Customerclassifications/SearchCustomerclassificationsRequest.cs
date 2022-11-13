namespace FSH.WebApi.Application.HMS.Customerclassifications;

public class SearchCustomerclassificationsRequest : PaginationFilter, IRequest<PaginationResponse<CustomerclassificationDto>>
{
    public DefaultIdType? BrandId { get; set; }
    public decimal? MinimumRate { get; set; }
    public decimal? MaximumRate { get; set; }
}

public class SearchCustomerclassificationsRequestHandler : IRequestHandler<SearchCustomerclassificationsRequest, PaginationResponse<CustomerclassificationDto>>
{
    private readonly IReadRepository<Customerclassification> _repository;

    public SearchCustomerclassificationsRequestHandler(IReadRepository<Customerclassification> repository) => _repository = repository;

    public async Task<PaginationResponse<CustomerclassificationDto>> Handle(SearchCustomerclassificationsRequest request, CancellationToken cancellationToken)
    {
        var spec = new CustomerclassificationsBySearchRequestSpec(request);
        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken: cancellationToken);
    }
}