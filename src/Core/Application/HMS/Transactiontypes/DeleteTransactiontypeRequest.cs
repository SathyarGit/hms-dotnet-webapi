using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Transactiontypes;

public class DeleteTransactiontypeRequest : IRequest<DefaultIdType>
{
    public DefaultIdType Id { get; set; }

    public DeleteTransactiontypeRequest(DefaultIdType id) => Id = id;
}

public class DeleteTransactiontypeRequestHandler : IRequestHandler<DeleteTransactiontypeRequest, DefaultIdType>
{
    private readonly IRepository<Transactiontype> _repository;
    private readonly IStringLocalizer _t;

    public DeleteTransactiontypeRequestHandler(IRepository<Transactiontype> repository, IStringLocalizer<DeleteTransactiontypeRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<DefaultIdType> Handle(DeleteTransactiontypeRequest request, CancellationToken cancellationToken)
    {
        var transactiontype = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = transactiontype ?? throw new NotFoundException(_t["Transactiontype {0} Not Found."]);

        // Add Domain Events to be raised after the commit
        transactiontype.DomainEvents.Add(EntityDeletedEvent.WithEntity(transactiontype));

        await _repository.DeleteAsync(transactiontype, cancellationToken);

        return request.Id;
    }
}