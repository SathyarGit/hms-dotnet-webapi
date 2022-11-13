namespace FSH.WebApi.Application.HMS.Foliotypes;

public class FoliotypeByNameSpec : Specification<Foliotype>, ISingleResultSpecification
{
    public FoliotypeByNameSpec(string name) =>
        Query.Where(p => p.Name == name);
}