using Mapster;

namespace FSH.WebApi.Application.HMS.Floors;

public class GetFloorViaDapperRequest : IRequest<FloorDto>
{
    public Guid Id { get; set; }

    public GetFloorViaDapperRequest(Guid id) => Id = id;
}

public class GetFloorViaDapperRequestHandler : IRequestHandler<GetFloorViaDapperRequest, FloorDto>
{
    private readonly IDapperRepository _repository;
    private readonly IStringLocalizer _t;

    public GetFloorViaDapperRequestHandler(IDapperRepository repository, IStringLocalizer<GetFloorViaDapperRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<FloorDto> Handle(GetFloorViaDapperRequest request, CancellationToken cancellationToken)
    {
        var floor = await _repository.QueryFirstOrDefaultAsync<Floor>(
            $"SELECT * FROM HMS.\"Floors\" WHERE \"Id\"  = '{request.Id}' AND \"TenantId\" = '@tenant'", cancellationToken: cancellationToken);

        _ = floor ?? throw new NotFoundException(_t["Floor {0} Not Found.", request.Id]);

        // Using mapster here throws a nullreference exception because of the "BrandName" property
        // in FloorDto and the floor not having a Brand assigned.
        return new FloorDto
        {
            Id = floor.Id,
            Description = floor.Description,
            Name = floor.Name
        };
    }
}