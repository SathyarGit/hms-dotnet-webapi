namespace FSH.WebApi.Application.HMS.Travelagents;

public class TravelagentByIdSpec : Specification<Travelagent, TravelagentDto>, ISingleResultSpecification
{
    public TravelagentByIdSpec(DefaultIdType id) =>
        Query
            .Where(p => p.Id == id);
}