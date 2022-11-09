namespace FSH.WebApi.Application.HMS.Floors;

public class GetFloorRequest : IRequest<FloorDetailsDto>
{
    public Guid Id { get; set; }

    public GetFloorRequest(Guid id) => Id = id;
}

public class GetFloorRequestHandler : IRequestHandler<GetFloorRequest, FloorDetailsDto>
{
    private readonly IRepository<Floor> _repository;
    private readonly IStringLocalizer _t;

    public GetFloorRequestHandler(IRepository<Floor> repository, IStringLocalizer<GetFloorRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<FloorDetailsDto> Handle(GetFloorRequest request, CancellationToken cancellationToken) =>
        await _repository.GetBySpecAsync(
            (ISpecification<Floor, FloorDetailsDto>)new FloorByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(_t["Floor {0} Not Found.", request.Id]);
}