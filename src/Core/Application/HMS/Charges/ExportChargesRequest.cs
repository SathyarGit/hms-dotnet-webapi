using FSH.WebApi.Application.Common.Exporters;

namespace FSH.WebApi.Application.HMS.Charges;

public class ExportChargesRequest : BaseFilter, IRequest<Stream>
{
    public DefaultIdType? FolioId { get; set; }
    public decimal? MinimumAmount { get; set; }
    public decimal? MaximumAmount { get; set; }
}

public class ExportChargesRequestHandler : IRequestHandler<ExportChargesRequest, Stream>
{
    private readonly IReadRepository<Charge> _repository;
    private readonly IExcelWriter _excelWriter;

    public ExportChargesRequestHandler(IReadRepository<Charge> repository, IExcelWriter excelWriter)
    {
        _repository = repository;
        _excelWriter = excelWriter;
    }

    public async Task<Stream> Handle(ExportChargesRequest request, CancellationToken cancellationToken)
    {
        var spec = new ExportChargesWithFoliosSpecification(request);

        var list = await _repository.ListAsync(spec, cancellationToken);

        return _excelWriter.WriteToStream(list);
    }
}

public class ExportChargesWithFoliosSpecification : EntitiesByBaseFilterSpec<Charge, ChargeExportDto>
{
    public ExportChargesWithFoliosSpecification(ExportChargesRequest request)
        : base(request) =>
        Query
            .Include(p => p.Folio)
            .Where(p => p.FolioId.Equals(request.FolioId!.Value), request.FolioId.HasValue)
            .Where(p => p.Amount >= request.MinimumAmount!.Value, request.MinimumAmount.HasValue)
            .Where(p => p.Amount <= request.MaximumAmount!.Value, request.MaximumAmount.HasValue);
}