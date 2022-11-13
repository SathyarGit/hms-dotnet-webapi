namespace FSH.WebApi.Application.HMS.Roomtypes;

public class RoomtypeByNameSpec : Specification<Roomtype>, ISingleResultSpecification
{
    public RoomtypeByNameSpec(string name) =>
        Query.Where(p => p.Name == name);
}