using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Transactionstatuses;

public class DeleteTransactionstatusRequest : IRequest<DefaultIdType>
{
    public DefaultIdType Id { get; set; }

    public DeleteTransactionstatusRequest(DefaultIdType id) => Id = id;
}

public class DeleteTransactionstatusRequestHandler : IRequestHandler<DeleteTransactionstatusRequest, DefaultIdType>
{
    private readonly IRepository<Transactionstatus> _repository;
    private readonly IStringLocalizer _t;

    public DeleteTransactionstatusRequestHandler(IRepository<Transactionstatus> repository, IStringLocalizer<DeleteTransactionstatusRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<DefaultIdType> Handle(DeleteTransactionstatusRequest request, CancellationToken cancellationToken)
    {
        var transactionstatus = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = transactionstatus ?? throw new NotFoundException(_t["Transactionstatus {0} Not Found."]);

        // Add Domain Events to be raised after the commit
        transactionstatus.DomainEvents.Add(EntityDeletedEvent.WithEntity(transactionstatus));

        await _repository.DeleteAsync(transactionstatus, cancellationToken);

        return request.Id;
    }
}