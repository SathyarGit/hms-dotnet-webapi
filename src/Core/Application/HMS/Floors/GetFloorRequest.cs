namespace FSH.WebApi.Application.HMS.Floors;

public class GetFloorRequest : IRequest<FloorDto>
{
    public DefaultIdType Id { get; set; }

    public GetFloorRequest(DefaultIdType id) => Id = id;
}

public class GetFloorRequestHandler : IRequestHandler<GetFloorRequest, FloorDto>
{
    private readonly IRepository<Floor> _repository;
    private readonly IStringLocalizer _t;

    public GetFloorRequestHandler(IRepository<Floor> repository, IStringLocalizer<GetFloorRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<FloorDto> Handle(GetFloorRequest request, CancellationToken cancellationToken) =>
        await _repository.GetBySpecAsync(
            (ISpecification<Floor, FloorDto>)new FloorByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(_t["Floor {0} Not Found.", request.Id]);
}