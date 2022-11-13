namespace FSH.WebApi.Application.HMS.Folios;

public class FoliosByBookingSpec : Specification<Folio>
{
    public FoliosByBookingSpec(DefaultIdType bookingId) =>
        Query.Where(p => p.BookingId == bookingId);
}
