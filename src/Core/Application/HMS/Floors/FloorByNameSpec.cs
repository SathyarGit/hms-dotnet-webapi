namespace FSH.WebApi.Application.HMS.Floors;

public class FloorByNameSpec : Specification<Floor>, ISingleResultSpecification
{
    public FloorByNameSpec(string name) =>
        Query.Where(p => p.Name == name);
}