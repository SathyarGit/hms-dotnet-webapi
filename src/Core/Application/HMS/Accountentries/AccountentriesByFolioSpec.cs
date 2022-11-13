namespace FSH.WebApi.Application.HMS.Accountentries;

public class AccountentriesByFolioSpec : Specification<Accountentry>
{
    public AccountentriesByFolioSpec(DefaultIdType folioId) =>
        Query.Where(p => p.FolioId == folioId);
}
