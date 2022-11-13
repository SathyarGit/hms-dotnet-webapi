namespace FSH.WebApi.Application.HMS.Bookings;

public class SearchBookingsRequest : PaginationFilter, IRequest<PaginationResponse<BookingDto>>
{
    public DefaultIdType? CustomerId { get; set; }
    public decimal? MinimumAmount { get; set; }
    public decimal? MaximumAmount { get; set; }
}

public class SearchBookingsRequestHandler : IRequestHandler<SearchBookingsRequest, PaginationResponse<BookingDto>>
{
    private readonly IReadRepository<Booking> _repository;

    public SearchBookingsRequestHandler(IReadRepository<Booking> repository) => _repository = repository;

    public async Task<PaginationResponse<BookingDto>> Handle(SearchBookingsRequest request, CancellationToken cancellationToken)
    {
        var spec = new BookingsBySearchRequestWithCustomersSpec(request);
        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken: cancellationToken);
    }
}