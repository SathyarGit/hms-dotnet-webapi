namespace FSH.WebApi.Application.HMS.Bookingstatuses;

public class BookingstatusByIdSpec : Specification<Bookingstatus, BookingstatusDto>, ISingleResultSpecification
{
    public BookingstatusByIdSpec(DefaultIdType id) =>
        Query
            .Where(p => p.Id == id);
}