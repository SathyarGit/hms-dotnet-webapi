namespace FSH.WebApi.Application.HMS.Vendors;

public class SearchVendorsRequest : PaginationFilter, IRequest<PaginationResponse<VendorDto>>
{
    public DefaultIdType? BrandId { get; set; }
}

public class SearchVendorsRequestHandler : IRequestHandler<SearchVendorsRequest, PaginationResponse<VendorDto>>
{
    private readonly IReadRepository<Vendor> _repository;

    public SearchVendorsRequestHandler(IReadRepository<Vendor> repository) => _repository = repository;

    public async Task<PaginationResponse<VendorDto>> Handle(SearchVendorsRequest request, CancellationToken cancellationToken)
    {
        var spec = new VendorsBySearchRequestSpec(request);
        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken: cancellationToken);
    }
}