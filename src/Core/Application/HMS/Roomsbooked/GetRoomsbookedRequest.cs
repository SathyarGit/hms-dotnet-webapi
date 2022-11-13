namespace FSH.WebApi.Application.HMS.Roomsbookeds;

public class GetRoomsbookedRequest : IRequest<RoomsbookedDetailsDto>
{
    public DefaultIdType Id { get; set; }

    public GetRoomsbookedRequest(DefaultIdType id) => Id = id;
}

public class GetRoomsbookedRequestHandler : IRequestHandler<GetRoomsbookedRequest, RoomsbookedDetailsDto>
{
    private readonly IRepository<Roomsbooked> _repository;
    private readonly IStringLocalizer _t;

    public GetRoomsbookedRequestHandler(IRepository<Roomsbooked> repository, IStringLocalizer<GetRoomsbookedRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<RoomsbookedDetailsDto> Handle(GetRoomsbookedRequest request, CancellationToken cancellationToken) =>
        await _repository.GetBySpecAsync(
            (ISpecification<Roomsbooked, RoomsbookedDetailsDto>)new RoomsbookedByIdWithRoomSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(_t["Roomsbooked {0} Not Found.", request.Id]);
}