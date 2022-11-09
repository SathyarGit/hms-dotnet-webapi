namespace FSH.WebApi.Application.HMS.Rooms;

public class GetRoomRequest : IRequest<RoomDetailsDto>
{
    public DefaultIdType Id { get; set; }

    public GetRoomRequest(DefaultIdType id) => Id = id;
}

public class GetRoomRequestHandler : IRequestHandler<GetRoomRequest, RoomDetailsDto>
{
    private readonly IRepository<Room> _repository;
    private readonly IStringLocalizer _t;

    public GetRoomRequestHandler(IRepository<Room> repository, IStringLocalizer<GetRoomRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<RoomDetailsDto> Handle(GetRoomRequest request, CancellationToken cancellationToken) =>
        await _repository.GetBySpecAsync(
            (ISpecification<Room, RoomDetailsDto>)new RoomByIdWithFloorSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(_t["Room {0} Not Found.", request.Id]);
}