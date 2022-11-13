namespace FSH.WebApi.Application.HMS.Folios;

public class FolioByIdWithBookingSpec : Specification<Folio, FolioDetailsDto>, ISingleResultSpecification
{
    public FolioByIdWithBookingSpec(DefaultIdType id) =>
        Query
            .Where(p => p.Id == id)
            .Include(p => p.Booking);
}