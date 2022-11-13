namespace FSH.WebApi.Application.HMS.Roomstatuses;

public class RoomstatusByIdSpec : Specification<Roomstatus, RoomstatusDto>, ISingleResultSpecification
{
    public RoomstatusByIdSpec(DefaultIdType id) =>
        Query
            .Where(p => p.Id == id);
}