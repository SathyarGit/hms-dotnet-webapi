namespace FSH.WebApi.Application.HMS.Bookingstatuses;

public class BookingstatusesBySearchRequestSpec : EntitiesByPaginationFilterSpec<Bookingstatus, BookingstatusDto>
{
    public BookingstatusesBySearchRequestSpec(SearchBookingstatusesRequest request)
        : base(request) =>
        Query
            .OrderBy(c => c.Name, !request.HasOrderBy());
}