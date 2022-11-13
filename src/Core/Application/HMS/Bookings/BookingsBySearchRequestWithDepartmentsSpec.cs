namespace FSH.WebApi.Application.HMS.Bookings;

public class BookingsBySearchRequestWithCustomersSpec : EntitiesByPaginationFilterSpec<Booking, BookingDto>
{
    public BookingsBySearchRequestWithCustomersSpec(SearchBookingsRequest request)
        : base(request) =>
        Query
            .Include(p => p.Customer)
            .Where(p => p.CustomerId.Equals(request.CustomerId!.Value), request.CustomerId.HasValue)
            .Where(p => p.Amount >= request.MinimumAmount!.Value, request.MinimumAmount.HasValue)
            .Where(p => p.Amount <= request.MaximumAmount!.Value, request.MaximumAmount.HasValue);
}