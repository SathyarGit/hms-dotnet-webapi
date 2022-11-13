namespace FSH.WebApi.Application.HMS.Charges;

public class SearchChargesRequest : PaginationFilter, IRequest<PaginationResponse<ChargeDto>>
{
    public DefaultIdType? FolioId { get; set; }
    public int? MinimumAmount { get; set; }
    public int? MaximumAmount { get; set; }
}

public class SearchChargesRequestHandler : IRequestHandler<SearchChargesRequest, PaginationResponse<ChargeDto>>
{
    private readonly IReadRepository<Charge> _repository;

    public SearchChargesRequestHandler(IReadRepository<Charge> repository) => _repository = repository;

    public async Task<PaginationResponse<ChargeDto>> Handle(SearchChargesRequest request, CancellationToken cancellationToken)
    {
        var spec = new ChargesBySearchRequestWithFoliosSpec(request);
        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken: cancellationToken);
    }
}