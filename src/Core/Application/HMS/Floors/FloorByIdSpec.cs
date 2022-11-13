namespace FSH.WebApi.Application.HMS.Floors;

public class FloorByIdSpec : Specification<Floor, FloorDetailsDto>, ISingleResultSpecification
{
    public FloorByIdSpec(DefaultIdType id) =>
        Query
            .Where(p => p.Id == id);
}