namespace FSH.WebApi.Application.HMS.Roomstatuses;

public class GetRoomstatusRequest : IRequest<RoomstatusDto>
{
    public DefaultIdType Id { get; set; }

    public GetRoomstatusRequest(DefaultIdType id) => Id = id;
}

public class GetRoomstatusRequestHandler : IRequestHandler<GetRoomstatusRequest, RoomstatusDto>
{
    private readonly IRepository<Roomstatus> _repository;
    private readonly IStringLocalizer _t;

    public GetRoomstatusRequestHandler(IRepository<Roomstatus> repository, IStringLocalizer<GetRoomstatusRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<RoomstatusDto> Handle(GetRoomstatusRequest request, CancellationToken cancellationToken) =>
        await _repository.GetBySpecAsync(
            (ISpecification<Roomstatus, RoomstatusDto>)new RoomstatusByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(_t["Roomstatus {0} Not Found.", request.Id]);
}