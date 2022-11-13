using Mapster;

namespace FSH.WebApi.Application.HMS.Roomstatuses;

public class GetRoomstatusViaDapperRequest : IRequest<RoomstatusDto>
{
    public DefaultIdType Id { get; set; }

    public GetRoomstatusViaDapperRequest(DefaultIdType id) => Id = id;
}

public class GetRoomstatusViaDapperRequestHandler : IRequestHandler<GetRoomstatusViaDapperRequest, RoomstatusDto>
{
    private readonly IDapperRepository _repository;
    private readonly IStringLocalizer _t;

    public GetRoomstatusViaDapperRequestHandler(IDapperRepository repository, IStringLocalizer<GetRoomstatusViaDapperRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<RoomstatusDto> Handle(GetRoomstatusViaDapperRequest request, CancellationToken cancellationToken)
    {
        var roomstatus = await _repository.QueryFirstOrDefaultAsync<Roomstatus>(
            $"SELECT * FROM HMS.\"Roomstatuses\" WHERE \"Id\"  = '{request.Id}' AND \"TenantId\" = '@tenant'", cancellationToken: cancellationToken);

        _ = roomstatus ?? throw new NotFoundException(_t["Roomstatus {0} Not Found.", request.Id]);

        // Using mapster here throws a nullreference exception because of the "BrandName" property
        // in RoomstatusDto and the roomstatus not having a Brand assigned.
        return new RoomstatusDto
        {
            Id = roomstatus.Id,
            Description = roomstatus.Description,
            Name = roomstatus.Name
        };
    }
}