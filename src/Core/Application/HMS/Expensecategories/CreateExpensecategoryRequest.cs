using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Expensecategories;

public class CreateExpensecategoryRequest : IRequest<DefaultIdType>
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}

public class CreateExpensecategoryRequestHandler : IRequestHandler<CreateExpensecategoryRequest, DefaultIdType>
{
    private readonly IRepository<Expensecategory> _repository;

    public CreateExpensecategoryRequestHandler(IRepository<Expensecategory> repository) =>
        _repository = repository;

    public async Task<DefaultIdType> Handle(CreateExpensecategoryRequest request, CancellationToken cancellationToken)
    {
        var roomtype = new Expensecategory(request.Name, request.Description);

        // Add Domain Events to be raised after the commit
        roomtype.DomainEvents.Add(EntityCreatedEvent.WithEntity(roomtype));

        await _repository.AddAsync(roomtype, cancellationToken);

        return roomtype.Id;
    }
}