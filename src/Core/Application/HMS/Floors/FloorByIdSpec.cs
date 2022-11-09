namespace FSH.WebApi.Application.HMS.Floors;

public class FloorByIdSpec : Specification<Floor, FloorDetailsDto>, ISingleResultSpecification
{
    public FloorByIdSpec(Guid id) =>
        Query
            .Where(p => p.Id == id);
}