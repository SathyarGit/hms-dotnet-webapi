namespace FSH.WebApi.Application.HMS.Foliotypes;

public class FoliotypeByIdSpec : Specification<Foliotype, FoliotypeDto>, ISingleResultSpecification
{
    public FoliotypeByIdSpec(DefaultIdType id) =>
        Query
            .Where(p => p.Id == id);
}