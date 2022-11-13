using Mapster;

namespace FSH.WebApi.Application.HMS.Roomsbookeds;

public class GetRoomsbookedViaDapperRequest : IRequest<RoomsbookedDto>
{
    public DefaultIdType Id { get; set; }

    public GetRoomsbookedViaDapperRequest(DefaultIdType id) => Id = id;
}

public class GetRoomsbookedViaDapperRequestHandler : IRequestHandler<GetRoomsbookedViaDapperRequest, RoomsbookedDto>
{
    private readonly IDapperRepository _repository;
    private readonly IStringLocalizer _t;

    public GetRoomsbookedViaDapperRequestHandler(IDapperRepository repository, IStringLocalizer<GetRoomsbookedViaDapperRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<RoomsbookedDto> Handle(GetRoomsbookedViaDapperRequest request, CancellationToken cancellationToken)
    {
        var roomsbooked = await _repository.QueryFirstOrDefaultAsync<Roomsbooked>(
            $"SELECT * FROM HMS.\"Roomsbookeds\" WHERE \"Id\"  = '{request.Id}' AND \"TenantId\" = '@tenant'", cancellationToken: cancellationToken);

        _ = roomsbooked ?? throw new NotFoundException(_t["Roomsbooked {0} Not Found.", request.Id]);

        // Using mapster here throws a nullreference exception because of the "RoomNumber" property
        // in RoomsbookedDto and the roomsbooked not having a Room assigned.
        return new RoomsbookedDto
        {
            Id = roomsbooked.Id,
            RoomRate = roomsbooked?.RoomRate ?? 0,
            RoomId = roomsbooked?.RoomId,
            BookingId = roomsbooked?.BookingId,
            RoomNumber = string.Empty,
        };
    }
}