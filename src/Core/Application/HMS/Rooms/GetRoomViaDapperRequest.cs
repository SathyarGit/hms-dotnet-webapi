using Mapster;

namespace FSH.WebApi.Application.HMS.Rooms;

public class GetRoomViaDapperRequest : IRequest<RoomDto>
{
    public DefaultIdType Id { get; set; }

    public GetRoomViaDapperRequest(DefaultIdType id) => Id = id;
}

public class GetRoomViaDapperRequestHandler : IRequestHandler<GetRoomViaDapperRequest, RoomDto>
{
    private readonly IDapperRepository _repository;
    private readonly IStringLocalizer _t;

    public GetRoomViaDapperRequestHandler(IDapperRepository repository, IStringLocalizer<GetRoomViaDapperRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<RoomDto> Handle(GetRoomViaDapperRequest request, CancellationToken cancellationToken)
    {
        var room = await _repository.QueryFirstOrDefaultAsync<Room>(
            $"SELECT * FROM HMS.\"Rooms\" WHERE \"Id\"  = '{request.Id}' AND \"TenantId\" = '@tenant'", cancellationToken: cancellationToken);

        _ = room ?? throw new NotFoundException(_t["Room {0} Not Found.", request.Id]);

        // Using mapster here throws a nullreference exception because of the "FloorName" property
        // in RoomDto and the room not having a Floor assigned.
        return new RoomDto
        {
            Id = room.Id,
            RoomNumber = room.RoomNumber,
            NumberOfBeds = room.NumberOfBeds,
            Notes = room.Notes,
            MaintenanceNotes = room.MaintenanceNotes,
            ImagePath = room.ImagePath,
            FloorId = room.FloorId,
            FloorName = string.Empty
        };
    }
}