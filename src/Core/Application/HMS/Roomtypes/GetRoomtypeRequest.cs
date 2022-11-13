namespace FSH.WebApi.Application.HMS.Roomtypes;

public class GetRoomtypeRequest : IRequest<RoomtypeDto>
{
    public DefaultIdType Id { get; set; }

    public GetRoomtypeRequest(DefaultIdType id) => Id = id;
}

public class GetRoomtypeRequestHandler : IRequestHandler<GetRoomtypeRequest, RoomtypeDto>
{
    private readonly IRepository<Roomtype> _repository;
    private readonly IStringLocalizer _t;

    public GetRoomtypeRequestHandler(IRepository<Roomtype> repository, IStringLocalizer<GetRoomtypeRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<RoomtypeDto> Handle(GetRoomtypeRequest request, CancellationToken cancellationToken) =>
        await _repository.GetBySpecAsync(
            (ISpecification<Roomtype, RoomtypeDto>)new RoomtypeByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(_t["Roomtype {0} Not Found.", request.Id]);
}