namespace FSH.WebApi.Application.HMS.Folios;

public class SearchFoliosRequest : PaginationFilter, IRequest<PaginationResponse<FolioDto>>
{
    public DefaultIdType? BookingId { get; set; }
}

public class SearchFoliosRequestHandler : IRequestHandler<SearchFoliosRequest, PaginationResponse<FolioDto>>
{
    private readonly IReadRepository<Folio> _repository;

    public SearchFoliosRequestHandler(IReadRepository<Folio> repository) => _repository = repository;

    public async Task<PaginationResponse<FolioDto>> Handle(SearchFoliosRequest request, CancellationToken cancellationToken)
    {
        var spec = new FoliosBySearchRequestWithBookingsSpec(request);
        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken: cancellationToken);
    }
}