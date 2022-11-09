using FSH.WebApi.Application.Common.Exporters;

namespace FSH.WebApi.Application.HMS.Rooms;

public class ExportRoomsRequest : BaseFilter, IRequest<Stream>
{
    public DefaultIdType? FloorId { get; set; }
    //public decimal? MinimumRate { get; set; }
    //public decimal? MaximumRate { get; set; }
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
            //.Where(p => p.Rate >= request.MinimumRate!.Value, request.MinimumRate.HasValue)
            //.Where(p => p.Rate <= request.MaximumRate!.Value, request.MaximumRate.HasValue);
}