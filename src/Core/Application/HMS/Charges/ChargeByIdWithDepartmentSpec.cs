namespace FSH.WebApi.Application.HMS.Charges;

public class ChargeByIdWithDepartmentSpec : Specification<Charge, ChargeDetailsDto>, ISingleResultSpecification
{
    public ChargeByIdWithDepartmentSpec(DefaultIdType id) =>
        Query
            .Where(p => p.Id == id)
            .Include(p => p.Department);
}