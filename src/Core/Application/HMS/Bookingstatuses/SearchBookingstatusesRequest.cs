namespace FSH.WebApi.Application.HMS.Bookingstatuses;

public class SearchBookingstatusesRequest : PaginationFilter, IRequest<PaginationResponse<BookingstatusDto>>
{
}

public class BookingstatusesBySearchRequestSpec : EntitiesByPaginationFilterSpec<Bookingstatus, BookingstatusDto>
{
    public BookingstatusesBySearchRequestSpec(SearchBookingstatusesRequest request)
        : base(request) =>
        Query.OrderBy(c => c.Name, !request.HasOrderBy());
}

public class SearchBookingstatusesRequestHandler : IRequestHandler<SearchBookingstatusesRequest, PaginationResponse<BookingstatusDto>>
{
    private readonly IReadRepository<Bookingstatus> _repository;

    public SearchBookingstatusesRequestHandler(IReadRepository<Bookingstatus> repository) => _repository = repository;

    public async Task<PaginationResponse<BookingstatusDto>> Handle(SearchBookingstatusesRequest request, CancellationToken cancellationToken)
    {
        var spec = new BookingstatusesBySearchRequestSpec(request);
        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken);
    }
}