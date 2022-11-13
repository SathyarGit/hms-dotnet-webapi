using FSH.WebApi.Application.Common.Exporters;

namespace FSH.WebApi.Application.HMS.Bookings;

public class ExportBookingsRequest : BaseFilter, IRequest<Stream>
{
    public DefaultIdType? CustomerId { get; set; }
    public decimal? MinimumAmount { get; set; }
    public decimal? MaximumAmount { get; set; }
}

public class ExportBookingsRequestHandler : IRequestHandler<ExportBookingsRequest, Stream>
{
    private readonly IReadRepository<Booking> _repository;
    private readonly IExcelWriter _excelWriter;

    public ExportBookingsRequestHandler(IReadRepository<Booking> repository, IExcelWriter excelWriter)
    {
        _repository = repository;
        _excelWriter = excelWriter;
    }

    public async Task<Stream> Handle(ExportBookingsRequest request, CancellationToken cancellationToken)
    {
        var spec = new ExportBookingsWithCustomersSpecification(request);

        var list = await _repository.ListAsync(spec, cancellationToken);

        return _excelWriter.WriteToStream(list);
    }
}

public class ExportBookingsWithCustomersSpecification : EntitiesByBaseFilterSpec<Booking, BookingExportDto>
{
    public ExportBookingsWithCustomersSpecification(ExportBookingsRequest request)
        : base(request) =>
        Query
            .Include(p => p.Customer)
            .Where(p => p.CustomerId.Equals(request.CustomerId!.Value), request.CustomerId.HasValue)
            .Where(p => p.Amount >= request.MinimumAmount!.Value, request.MinimumAmount.HasValue)
            .Where(p => p.Amount <= request.MaximumAmount!.Value, request.MaximumAmount.HasValue);
}