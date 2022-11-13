using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Transactionstatuses;

public class CreateTransactionstatusRequest : IRequest<DefaultIdType>
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}

public class CreateTransactionstatusRequestHandler : IRequestHandler<CreateTransactionstatusRequest, DefaultIdType>
{
    private readonly IRepository<Transactionstatus> _repository;

    public CreateTransactionstatusRequestHandler(IRepository<Transactionstatus> repository) =>
        _repository = repository;

    public async Task<DefaultIdType> Handle(CreateTransactionstatusRequest request, CancellationToken cancellationToken)
    {
        var transactionstatus = new Transactionstatus(request.Name, request.Description);

        // Add Domain Events to be raised after the commit
        transactionstatus.DomainEvents.Add(EntityCreatedEvent.WithEntity(transactionstatus));

        await _repository.AddAsync(transactionstatus, cancellationToken);

        return transactionstatus.Id;
    }
}