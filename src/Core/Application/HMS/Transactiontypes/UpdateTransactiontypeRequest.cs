using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Transactiontypes;

public class UpdateTransactiontypeRequest : IRequest<DefaultIdType>
{
    public DefaultIdType Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}

public class UpdateTransactiontypeRequestHandler : IRequestHandler<UpdateTransactiontypeRequest, DefaultIdType>
{
    private readonly IRepository<Transactiontype> _repository;
    private readonly IStringLocalizer _t;

    public UpdateTransactiontypeRequestHandler(IRepository<Transactiontype> repository, IStringLocalizer<UpdateTransactiontypeRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<DefaultIdType> Handle(UpdateTransactiontypeRequest request, CancellationToken cancellationToken)
    {
        var transactiontype = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = transactiontype ?? throw new NotFoundException(_t["Transactiontype {0} Not Found.", request.Id]);

        var updatedTransactiontype = transactiontype.Update(request.Name, request.Description);

        // Add Domain Events to be raised after the commit
        transactiontype.DomainEvents.Add(EntityUpdatedEvent.WithEntity(transactiontype));

        await _repository.UpdateAsync(updatedTransactiontype, cancellationToken);

        return request.Id;
    }
}