using FSH.WebApi.Application.Common.Exporters;

namespace FSH.WebApi.Application.HMS.Customers;

public class ExportCustomersRequest : BaseFilter, IRequest<Stream>
{
    public DefaultIdType? CustclassificationId { get; set; }
}

public class ExportCustomersRequestHandler : IRequestHandler<ExportCustomersRequest, Stream>
{
    private readonly IReadRepository<Customer> _repository;
    private readonly IExcelWriter _excelWriter;

    public ExportCustomersRequestHandler(IReadRepository<Customer> repository, IExcelWriter excelWriter)
    {
        _repository = repository;
        _excelWriter = excelWriter;
    }

    public async Task<Stream> Handle(ExportCustomersRequest request, CancellationToken cancellationToken)
    {
        var spec = new ExportCustomersWithCustomerclassificationsSpecification(request);

        var list = await _repository.ListAsync(spec, cancellationToken);

        return _excelWriter.WriteToStream(list);
    }
}

public class ExportCustomersWithCustomerclassificationsSpecification : EntitiesByBaseFilterSpec<Customer, CustomerExportDto>
{
    public ExportCustomersWithCustomerclassificationsSpecification(ExportCustomersRequest request)
        : base(request) =>
        Query
            .Include(p => p.Customerclassification)
            .Where(p => p.CustclassificationId.Equals(request.CustclassificationId!.Value), request.CustclassificationId.HasValue);
}