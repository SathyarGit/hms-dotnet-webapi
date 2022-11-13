using Mapster;

namespace FSH.WebApi.Application.HMS.Roomtypes;

public class GetRoomtypeViaDapperRequest : IRequest<RoomtypeDto>
{
    public DefaultIdType Id { get; set; }

    public GetRoomtypeViaDapperRequest(DefaultIdType id) => Id = id;
}

public class GetRoomtypeViaDapperRequestHandler : IRequestHandler<GetRoomtypeViaDapperRequest, RoomtypeDto>
{
    private readonly IDapperRepository _repository;
    private readonly IStringLocalizer _t;

    public GetRoomtypeViaDapperRequestHandler(IDapperRepository repository, IStringLocalizer<GetRoomtypeViaDapperRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<RoomtypeDto> Handle(GetRoomtypeViaDapperRequest request, CancellationToken cancellationToken)
    {
        var roomtype = await _repository.QueryFirstOrDefaultAsync<Roomtype>(
            $"SELECT * FROM HMS.\"Roomtypes\" WHERE \"Id\"  = '{request.Id}' AND \"TenantId\" = '@tenant'", cancellationToken: cancellationToken);

        _ = roomtype ?? throw new NotFoundException(_t["Roomtype {0} Not Found.", request.Id]);

        // Using mapster here throws a nullreference exception because of the "BrandName" property
        // in RoomtypeDto and the roomtype not having a Brand assigned.
        return new RoomtypeDto
        {
            Id = roomtype.Id,
            Description = roomtype.Description,
            Name = roomtype.Name
        };
    }
}