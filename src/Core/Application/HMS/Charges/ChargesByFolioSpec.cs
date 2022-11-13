namespace FSH.WebApi.Application.HMS.Charges;

public class ChargesByFolioSpec : Specification<Charge>
{
    public ChargesByFolioSpec(DefaultIdType folioId) =>
        Query.Where(p => p.FolioId == folioId);
}
