namespace FSH.WebApi.Application.HMS.Travelagents;

public class TravelagentsBySearchRequestSpec : EntitiesByPaginationFilterSpec<Travelagent, TravelagentDto>
{
    public TravelagentsBySearchRequestSpec(SearchTravelagentsRequest request)
        : base(request) =>
        Query
            .OrderBy(c => c.Name, !request.HasOrderBy());
}