using Mapster;

namespace FSH.WebApi.Application.HMS.Purchases;

public class GetPurchaseViaDapperRequest : IRequest<PurchaseDto>
{
    public DefaultIdType Id { get; set; }

    public GetPurchaseViaDapperRequest(DefaultIdType id) => Id = id;
}

public class GetPurchaseViaDapperRequestHandler : IRequestHandler<GetPurchaseViaDapperRequest, PurchaseDto>
{
    private readonly IDapperRepository _repository;
    private readonly IStringLocalizer _t;

    public GetPurchaseViaDapperRequestHandler(IDapperRepository repository, IStringLocalizer<GetPurchaseViaDapperRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<PurchaseDto> Handle(GetPurchaseViaDapperRequest request, CancellationToken cancellationToken)
    {
        var purchase = await _repository.QueryFirstOrDefaultAsync<Purchase>(
            $"SELECT * FROM HMS.\"Purchases\" WHERE \"Id\"  = '{request.Id}' AND \"TenantId\" = '@tenant'", cancellationToken: cancellationToken);

        _ = purchase ?? throw new NotFoundException(_t["Purchase {0} Not Found.", request.Id]);

        // Using mapster here throws a nullreference exception because of the "DepartmentName" property
        // in PurchaseDto and the purchase not having a Department assigned.
        return new PurchaseDto
        {
            Id = purchase.Id,
            PurchaseDate = purchase.PurchaseDate,
            VendorId = purchase.VendorId,
            Amount = purchase.Amount,
            Description = purchase.Description,
            DepartmentId = purchase.DepartmentId,
            BillsOrInvoiceNumber = purchase.BillsOrInvoiceNumber,
            ImagePath = purchase.ImagePath,
            TransactionstatusId = purchase.TransactionstatusId,
            DepartmentName = string.Empty,
            VendorName = string.Empty,
            TransactionstatusName = string.Empty
        };
    }
}