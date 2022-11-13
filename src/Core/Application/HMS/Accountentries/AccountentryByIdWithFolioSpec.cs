namespace FSH.WebApi.Application.HMS.Accountentries;

public class AccountentryByIdWithFolioSpec : Specification<Accountentry, AccountentryDetailsDto>, ISingleResultSpecification
{
    public AccountentryByIdWithFolioSpec(DefaultIdType id) =>
        Query
            .Where(p => p.Id == id)
            .Include(p => p.Folio);
}