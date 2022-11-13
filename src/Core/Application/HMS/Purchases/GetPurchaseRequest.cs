namespace FSH.WebApi.Application.HMS.Purchases;

public class GetPurchaseRequest : IRequest<PurchaseDetailsDto>
{
    public DefaultIdType Id { get; set; }

    public GetPurchaseRequest(DefaultIdType id) => Id = id;
}

public class GetPurchaseRequestHandler : IRequestHandler<GetPurchaseRequest, PurchaseDetailsDto>
{
    private readonly IRepository<Purchase> _repository;
    private readonly IStringLocalizer _t;

    public GetPurchaseRequestHandler(IRepository<Purchase> repository, IStringLocalizer<GetPurchaseRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<PurchaseDetailsDto> Handle(GetPurchaseRequest request, CancellationToken cancellationToken) =>
        await _repository.GetBySpecAsync(
            (ISpecification<Purchase, PurchaseDetailsDto>)new PurchaseByIdWithDepartmentSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(_t["Purchase {0} Not Found.", request.Id]);
}