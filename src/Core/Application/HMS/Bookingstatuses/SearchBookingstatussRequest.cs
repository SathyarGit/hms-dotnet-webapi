namespace FSH.WebApi.Application.HMS.Bookingstatuses;

public class SearchBookingstatusesRequest : PaginationFilter, IRequest<PaginationResponse<BookingstatusDto>>
{
    public DefaultIdType? BrandId { get; set; }
    public decimal? MinimumRate { get; set; }
    public decimal? MaximumRate { get; set; }
}

public class SearchBookingstatusesRequestHandler : IRequestHandler<SearchBookingstatusesRequest, PaginationResponse<BookingstatusDto>>
{
    private readonly IReadRepository<Bookingstatus> _repository;

    public SearchBookingstatusesRequestHandler(IReadRepository<Bookingstatus> repository) => _repository = repository;

    public async Task<PaginationResponse<BookingstatusDto>> Handle(SearchBookingstatusesRequest request, CancellationToken cancellationToken)
    {
        var spec = new BookingstatusesBySearchRequestSpec(request);
        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken: cancellationToken);
    }
}