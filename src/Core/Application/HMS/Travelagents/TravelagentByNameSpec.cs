namespace FSH.WebApi.Application.HMS.Travelagents;

public class TravelagentByNameSpec : Specification<Travelagent>, ISingleResultSpecification
{
    public TravelagentByNameSpec(string name) =>
        Query.Where(p => p.Name == name);
}