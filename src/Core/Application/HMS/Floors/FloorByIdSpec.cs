namespace FSH.WebApi.Application.HMS.Floors;

public class FloorByIdSpec : Specification<Floor, FloorDto>, ISingleResultSpecification
{
    public FloorByIdSpec(DefaultIdType id) =>
        Query
            .Where(p => p.Id == id);
}