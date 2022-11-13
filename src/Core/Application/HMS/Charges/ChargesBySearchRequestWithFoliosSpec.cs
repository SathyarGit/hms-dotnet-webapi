namespace FSH.WebApi.Application.HMS.Charges;

public class ChargesBySearchRequestWithFoliosSpec : EntitiesByPaginationFilterSpec<Charge, ChargeDto>
{
    public ChargesBySearchRequestWithFoliosSpec(SearchChargesRequest request)
        : base(request) =>
        Query
            .Include(p => p.Folio)
            .Where(p => p.FolioId.Equals(request.FolioId!.Value), request.FolioId.HasValue)
             .Where(p => p.Amount >= request.MinimumAmount!.Value, request.MinimumAmount.HasValue)
             .Where(p => p.Amount <= request.MaximumAmount!.Value, request.MaximumAmount.HasValue);
}