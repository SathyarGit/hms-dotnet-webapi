namespace FSH.WebApi.Application.HMS.Foliotypes;

public class FoliotypesBySearchRequestSpec : EntitiesByPaginationFilterSpec<Foliotype, FoliotypeDto>
{
    public FoliotypesBySearchRequestSpec(SearchFoliotypesRequest request)
        : base(request) =>
        Query
            .OrderBy(c => c.Name, !request.HasOrderBy());
}