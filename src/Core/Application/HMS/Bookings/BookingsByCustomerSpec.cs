namespace FSH.WebApi.Application.HMS.Bookings;

public class BookingsByCustomerSpec : Specification<Booking>
{
    public BookingsByCustomerSpec(DefaultIdType customerId) =>
        Query.Where(p => p.CustomerId == customerId);
}
