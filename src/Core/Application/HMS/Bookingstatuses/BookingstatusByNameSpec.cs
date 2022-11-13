namespace FSH.WebApi.Application.HMS.Bookingstatuses;

public class BookingstatusByNameSpec : Specification<Bookingstatus>, ISingleResultSpecification
{
    public BookingstatusByNameSpec(string name) =>
        Query.Where(p => p.Name == name);
}