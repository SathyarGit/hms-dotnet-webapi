using FSH.WebApi.Application.Common.Exporters;

namespace FSH.WebApi.Application.HMS.Vendors;

public class ExportVendorsRequest : BaseFilter, IRequest<Stream>
{
}

public class ExportVendorsRequestHandler : IRequestHandler<ExportVendorsRequest, Stream>
{
    private readonly IReadRepository<Vendor> _repository;
    private readonly IExcelWriter _excelWriter;

    public ExportVendorsRequestHandler(IReadRepository<Vendor> repository, IExcelWriter excelWriter)
    {
        _repository = repository;
        _excelWriter = excelWriter;
    }

    public async Task<Stream> Handle(ExportVendorsRequest request, CancellationToken cancellationToken)
    {
        var spec = new ExportVendorsWithBrandsSpecification(request);

        var list = await _repository.ListAsync(spec, cancellationToken);

        return _excelWriter.WriteToStream(list);
    }
}

public class ExportVendorsWithBrandsSpecification : EntitiesByBaseFilterSpec<Vendor, VendorExportDto>
{
    public ExportVendorsWithBrandsSpecification(ExportVendorsRequest request)
        : base(request)
    {
    }
}