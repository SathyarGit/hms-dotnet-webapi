using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Customerclassifications;

public class CreateCustomerclassificationRequest : IRequest<DefaultIdType>
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}

public class CreateCustomerclassificationRequestHandler : IRequestHandler<CreateCustomerclassificationRequest, DefaultIdType>
{
    private readonly IRepository<Customerclassification> _repository;

    public CreateCustomerclassificationRequestHandler(IRepository<Customerclassification> repository) =>
        _repository = repository;

    public async Task<DefaultIdType> Handle(CreateCustomerclassificationRequest request, CancellationToken cancellationToken)
    {
        var customerclassification = new Customerclassification(request.Name, request.Description);

        // Add Domain Events to be raised after the commit
        customerclassification.DomainEvents.Add(EntityCreatedEvent.WithEntity(customerclassification));

        await _repository.AddAsync(customerclassification, cancellationToken);

        return customerclassification.Id;
    }
}