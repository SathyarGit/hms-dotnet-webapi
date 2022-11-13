namespace FSH.WebApi.Application.HMS.Folios;

public class FoliosBySearchRequestWithBookingsSpec : EntitiesByPaginationFilterSpec<Folio, FolioDto>
{
    public FoliosBySearchRequestWithBookingsSpec(SearchFoliosRequest request)
        : base(request) =>
        Query
            .Include(p => p.Booking)
            .Where(p => p.BookingId.Equals(request.BookingId!.Value), request.BookingId.HasValue);
}