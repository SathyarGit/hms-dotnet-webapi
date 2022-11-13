using FSH.WebApi.Application.Common.Exporters;

namespace FSH.WebApi.Application.HMS.Folios;

public class ExportFoliosRequest : BaseFilter, IRequest<Stream>
{
    public DefaultIdType? BookingId { get; set; }
}

public class ExportFoliosRequestHandler : IRequestHandler<ExportFoliosRequest, Stream>
{
    private readonly IReadRepository<Folio> _repository;
    private readonly IExcelWriter _excelWriter;

    public ExportFoliosRequestHandler(IReadRepository<Folio> repository, IExcelWriter excelWriter)
    {
        _repository = repository;
        _excelWriter = excelWriter;
    }

    public async Task<Stream> Handle(ExportFoliosRequest request, CancellationToken cancellationToken)
    {
        var spec = new ExportFoliosWithBookingsSpecification(request);

        var list = await _repository.ListAsync(spec, cancellationToken);

        return _excelWriter.WriteToStream(list);
    }
}

public class ExportFoliosWithBookingsSpecification : EntitiesByBaseFilterSpec<Folio, FolioExportDto>
{
    public ExportFoliosWithBookingsSpecification(ExportFoliosRequest request)
        : base(request) =>
        Query
            .Include(p => p.Booking)
            .Where(p => p.BookingId.Equals(request.BookingId!.Value), request.BookingId.HasValue);
}