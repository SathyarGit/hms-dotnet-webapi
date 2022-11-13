using FSH.WebApi.Application.Common.Exporters;

namespace FSH.WebApi.Application.HMS.Purchases;

public class ExportPurchasesRequest : BaseFilter, IRequest<Stream>
{
    public DefaultIdType? DepartmentId { get; set; }
    public int? MinimumAmount { get; set; }
    public int? MaximumAmount { get; set; }
}

public class ExportPurchasesRequestHandler : IRequestHandler<ExportPurchasesRequest, Stream>
{
    private readonly IReadRepository<Purchase> _repository;
    private readonly IExcelWriter _excelWriter;

    public ExportPurchasesRequestHandler(IReadRepository<Purchase> repository, IExcelWriter excelWriter)
    {
        _repository = repository;
        _excelWriter = excelWriter;
    }

    public async Task<Stream> Handle(ExportPurchasesRequest request, CancellationToken cancellationToken)
    {
        var spec = new ExportPurchasesWithDepartmentsSpecification(request);

        var list = await _repository.ListAsync(spec, cancellationToken);

        return _excelWriter.WriteToStream(list);
    }
}

public class ExportPurchasesWithDepartmentsSpecification : EntitiesByBaseFilterSpec<Purchase, PurchaseExportDto>
{
    public ExportPurchasesWithDepartmentsSpecification(ExportPurchasesRequest request)
        : base(request) =>
        Query
            .Include(p => p.Department)
            .Where(p => p.DepartmentId.Equals(request.DepartmentId!.Value), request.DepartmentId.HasValue)
            .Where(p => p.Amount >= request.MinimumAmount!.Value, request.MinimumAmount.HasValue)
            .Where(p => p.Amount <= request.MaximumAmount!.Value, request.MaximumAmount.HasValue);
}