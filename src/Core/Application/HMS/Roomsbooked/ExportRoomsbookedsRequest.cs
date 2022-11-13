using FSH.WebApi.Application.Common.Exporters;

namespace FSH.WebApi.Application.HMS.Roomsbookeds;

public class ExportRoomsbookedsRequest : BaseFilter, IRequest<Stream>
{
    public DefaultIdType? RoomId { get; set; }
    public DefaultIdType? BookingId { get; set; }
    public decimal? MinimumRate { get; set; }
    public decimal? MaximumRate { get; set; }
}

public class ExportRoomsbookedsRequestHandler : IRequestHandler<ExportRoomsbookedsRequest, Stream>
{
    private readonly IReadRepository<Roomsbooked> _repository;
    private readonly IExcelWriter _excelWriter;

    public ExportRoomsbookedsRequestHandler(IReadRepository<Roomsbooked> repository, IExcelWriter excelWriter)
    {
        _repository = repository;
        _excelWriter = excelWriter;
    }

    public async Task<Stream> Handle(ExportRoomsbookedsRequest request, CancellationToken cancellationToken)
    {
        var spec = new ExportRoomsbookedsWithRoomsSpecification(request);

        var list = await _repository.ListAsync(spec, cancellationToken);

        return _excelWriter.WriteToStream(list);
    }
}

public class ExportRoomsbookedsWithRoomsSpecification : EntitiesByBaseFilterSpec<Roomsbooked, RoomsbookedExportDto>
{
    public ExportRoomsbookedsWithRoomsSpecification(ExportRoomsbookedsRequest request)
        : base(request) =>
        Query
            .Include(p => p.Room)
            .Where(p => p.RoomId.Equals(request.RoomId!.Value), request.RoomId.HasValue)
            .Where(p => p.RoomRate >= request.MinimumRate!.Value, request.MinimumRate.HasValue)
            .Where(p => p.RoomRate <= request.MaximumRate!.Value, request.MaximumRate.HasValue);
}