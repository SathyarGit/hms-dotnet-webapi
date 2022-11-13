using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Customers;

public class DeleteCustomerRequest : IRequest<DefaultIdType>
{
    public DefaultIdType Id { get; set; }

    public DeleteCustomerRequest(DefaultIdType id) => Id = id;
}

public class DeleteCustomerRequestHandler : IRequestHandler<DeleteCustomerRequest, DefaultIdType>
{
    private readonly IRepository<Customer> _repository;
    private readonly IStringLocalizer _t;

    public DeleteCustomerRequestHandler(IRepository<Customer> repository, IStringLocalizer<DeleteCustomerRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<DefaultIdType> Handle(DeleteCustomerRequest request, CancellationToken cancellationToken)
    {
        var customer = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = customer ?? throw new NotFoundException(_t["Customer {0} Not Found."]);

        // Add Domain Events to be raised after the commit
        customer.DomainEvents.Add(EntityDeletedEvent.WithEntity(customer));

        await _repository.DeleteAsync(customer, cancellationToken);

        return request.Id;
    }
}