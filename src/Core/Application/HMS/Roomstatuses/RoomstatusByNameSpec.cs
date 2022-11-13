namespace FSH.WebApi.Application.HMS.Roomstatuses;

public class RoomstatusByNameSpec : Specification<Roomstatus>, ISingleResultSpecification
{
    public RoomstatusByNameSpec(string name) =>
        Query.Where(p => p.Name == name);
}