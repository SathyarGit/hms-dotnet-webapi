using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Purchases;

public class DeletePurchaseRequest : IRequest<DefaultIdType>
{
    public DefaultIdType Id { get; set; }

    public DeletePurchaseRequest(DefaultIdType id) => Id = id;
}

public class DeletePurchaseRequestHandler : IRequestHandler<DeletePurchaseRequest, DefaultIdType>
{
    private readonly IRepository<Purchase> _repository;
    private readonly IStringLocalizer _t;

    public DeletePurchaseRequestHandler(IRepository<Purchase> repository, IStringLocalizer<DeletePurchaseRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<DefaultIdType> Handle(DeletePurchaseRequest request, CancellationToken cancellationToken)
    {
        var purchase = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = purchase ?? throw new NotFoundException(_t["Purchase {0} Not Found."]);

        // Add Domain Events to be raised after the commit
        purchase.DomainEvents.Add(EntityDeletedEvent.WithEntity(purchase));

        await _repository.DeleteAsync(purchase, cancellationToken);

        return request.Id;
    }
}