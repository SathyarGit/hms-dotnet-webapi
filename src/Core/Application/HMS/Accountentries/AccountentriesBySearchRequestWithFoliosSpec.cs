namespace FSH.WebApi.Application.HMS.Accountentries;

public class AccountentriesBySearchRequestWithFoliosSpec : EntitiesByPaginationFilterSpec<Accountentry, AccountentryDto>
{
    public AccountentriesBySearchRequestWithFoliosSpec(SearchAccountentriesRequest request)
        : base(request) =>
        Query
            .Include(p => p.Folio)
            .Where(p => p.FolioId.Equals(request.FolioId!.Value), request.FolioId.HasValue)
             .Where(p => p.Amount >= request.MinimumAmount!.Value, request.MinimumAmount.HasValue)
             .Where(p => p.Amount <= request.MaximumAmount!.Value, request.MaximumAmount.HasValue);
}