using FSH.WebApi.Application.Common.Exporters;

namespace FSH.WebApi.Application.HMS.Rooms;

public class ExportRoomsRequest : BaseFilter, IRequest<Stream>
{
    public DefaultIdType? FloorId { get; set; }
    public DefaultIdType? RoomtypeId { get; set; }
}

public class ExportRoomsRequestHandler : IRequestHandler<ExportRoomsRequest, Stream>
{
    private readonly IReadRepository<Room> _repository;
    private readonly IExcelWriter _excelWriter;

    public ExportRoomsRequestHandler(IReadRepository<Room> repository, IExcelWriter excelWriter)
    {
        _repository = repository;
        _excelWriter = excelWriter;
    }

    public async Task<Stream> Handle(ExportRoomsRequest request, CancellationToken cancellationToken)
    {
        var spec = new ExportRoomsWithFloorsSpecification(request);

        var list = await _repository.ListAsync(spec, cancellationToken);

        return _excelWriter.WriteToStream(list);
    }
}

public class ExportRoomsWithFloorsSpecification : EntitiesByBaseFilterSpec<Room, RoomExportDto>
{
    public ExportRoomsWithFloorsSpecification(ExportRoomsRequest request)
        : base(request) =>
        Query
            .Include(p => p.Floor)
            .Where(p => p.FloorId.Equals(request.FloorId!.Value), request.FloorId.HasValue);
}

public class ExportRoomsWithRoomtypesSpecification : EntitiesByBaseFilterSpec<Room, RoomExportDto>
{
    public ExportRoomsWithRoomtypesSpecification(ExportRoomsRequest request)
        : base(request) =>
        Query
            .Include(p => p.Roomtype)
            .Where(p => p.RoomtypeId.Equals(request.RoomtypeId!.Value), request.RoomtypeId.HasValue);
}