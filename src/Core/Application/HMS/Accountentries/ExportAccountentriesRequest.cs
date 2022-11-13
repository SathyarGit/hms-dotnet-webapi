using FSH.WebApi.Application.Common.Exporters;

namespace FSH.WebApi.Application.HMS.Accountentries;

public class ExportAccountentriesRequest : BaseFilter, IRequest<Stream>
{
    public DefaultIdType? FolioId { get; set; }
    public DefaultIdType? DepartmentId { get; set; }
    public DefaultIdType? PurchaseId { get; set; }
    public decimal? MinimumAmount { get; set; }
    public decimal? MaximumAmount { get; set; }
}

public class ExportAccountentriesRequestHandler : IRequestHandler<ExportAccountentriesRequest, Stream>
{
    private readonly IReadRepository<Accountentry> _repository;
    private readonly IExcelWriter _excelWriter;

    public ExportAccountentriesRequestHandler(IReadRepository<Accountentry> repository, IExcelWriter excelWriter)
    {
        _repository = repository;
        _excelWriter = excelWriter;
    }

    public async Task<Stream> Handle(ExportAccountentriesRequest request, CancellationToken cancellationToken)
    {
        var spec = new ExportAccountentriesWithFoliosSpecification(request);

        var list = await _repository.ListAsync(spec, cancellationToken);

        return _excelWriter.WriteToStream(list);
    }
}

public class ExportAccountentriesWithFoliosSpecification : EntitiesByBaseFilterSpec<Accountentry, AccountentryExportDto>
{
    public ExportAccountentriesWithFoliosSpecification(ExportAccountentriesRequest request)
        : base(request) =>
        Query
            .Include(p => p.Folio)
            .Where(p => p.FolioId.Equals(request.FolioId!.Value), request.FolioId.HasValue)
            .Where(p => p.Amount >= request.MinimumAmount!.Value, request.MinimumAmount.HasValue)
            .Where(p => p.Amount <= request.MaximumAmount!.Value, request.MaximumAmount.HasValue);
}

public class ExportAccountentriesWithDepartmentsSpecification : EntitiesByBaseFilterSpec<Accountentry, AccountentryExportDto>
{
    public ExportAccountentriesWithDepartmentsSpecification(ExportAccountentriesRequest request)
        : base(request) =>
        Query
            .Include(p => p.Department)
            .Where(p => p.DepartmentId.Equals(request.DepartmentId!.Value), request.DepartmentId.HasValue)
            .Where(p => p.Amount >= request.MinimumAmount!.Value, request.MinimumAmount.HasValue)
            .Where(p => p.Amount <= request.MaximumAmount!.Value, request.MaximumAmount.HasValue);
}

public class ExportAccountentriesWithPurchasesSpecification : EntitiesByBaseFilterSpec<Accountentry, AccountentryExportDto>
{
    public ExportAccountentriesWithPurchasesSpecification(ExportAccountentriesRequest request)
        : base(request) =>
        Query
            .Include(p => p.Purchase)
            .Where(p => p.PurchaseId.Equals(request.PurchaseId!.Value), request.PurchaseId.HasValue)
            .Where(p => p.Amount >= request.MinimumAmount!.Value, request.MinimumAmount.HasValue)
            .Where(p => p.Amount <= request.MaximumAmount!.Value, request.MaximumAmount.HasValue);
}