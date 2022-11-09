namespace FSH.WebApi.Application.HMS.Floors;

public class FloorsBySearchRequestSpec : EntitiesByPaginationFilterSpec<Floor, FloorDto>
{
    public FloorsBySearchRequestSpec(SearchFloorsRequest request)
        : base(request) =>
        Query
            .OrderBy(c => c.Name, !request.HasOrderBy());
}