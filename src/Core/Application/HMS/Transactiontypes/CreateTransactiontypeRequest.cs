using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Transactiontypes;

public class CreateTransactiontypeRequest : IRequest<DefaultIdType>
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}

public class CreateTransactiontypeRequestHandler : IRequestHandler<CreateTransactiontypeRequest, DefaultIdType>
{
    private readonly IRepository<Transactiontype> _repository;

    public CreateTransactiontypeRequestHandler(IRepository<Transactiontype> repository) =>
        _repository = repository;

    public async Task<DefaultIdType> Handle(CreateTransactiontypeRequest request, CancellationToken cancellationToken)
    {
        var transactiontype = new Transactiontype(request.Name, request.Description);

        // Add Domain Events to be raised after the commit
        transactiontype.DomainEvents.Add(EntityCreatedEvent.WithEntity(transactiontype));

        await _repository.AddAsync(transactiontype, cancellationToken);

        return transactiontype.Id;
    }
}