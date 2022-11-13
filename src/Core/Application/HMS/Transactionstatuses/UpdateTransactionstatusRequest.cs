using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Transactionstatuses;

public class UpdateTransactionstatusRequest : IRequest<DefaultIdType>
{
    public DefaultIdType Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}

public class UpdateTransactionstatusRequestHandler : IRequestHandler<UpdateTransactionstatusRequest, DefaultIdType>
{
    private readonly IRepository<Transactionstatus> _repository;
    private readonly IStringLocalizer _t;

    public UpdateTransactionstatusRequestHandler(IRepository<Transactionstatus> repository, IStringLocalizer<UpdateTransactionstatusRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<DefaultIdType> Handle(UpdateTransactionstatusRequest request, CancellationToken cancellationToken)
    {
        var transactionstatus = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = transactionstatus ?? throw new NotFoundException(_t["Transactionstatus {0} Not Found.", request.Id]);

        var updatedTransactionstatus = transactionstatus.Update(request.Name, request.Description);

        // Add Domain Events to be raised after the commit
        transactionstatus.DomainEvents.Add(EntityUpdatedEvent.WithEntity(transactionstatus));

        await _repository.UpdateAsync(updatedTransactionstatus, cancellationToken);

        return request.Id;
    }
}