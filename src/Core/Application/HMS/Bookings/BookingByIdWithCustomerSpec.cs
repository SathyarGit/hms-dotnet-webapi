namespace FSH.WebApi.Application.HMS.Bookings;

public class BookingByIdWithCustomerSpec : Specification<Booking, BookingDetailsDto>, ISingleResultSpecification
{
    public BookingByIdWithCustomerSpec(DefaultIdType id) =>
        Query
            .Where(p => p.Id == id)
            .Include(p => p.Customer);
}