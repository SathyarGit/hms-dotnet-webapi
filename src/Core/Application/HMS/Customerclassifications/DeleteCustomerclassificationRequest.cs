using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Customerclassifications;

public class DeleteCustomerclassificationRequest : IRequest<DefaultIdType>
{
    public DefaultIdType Id { get; set; }

    public DeleteCustomerclassificationRequest(DefaultIdType id) => Id = id;
}

public class DeleteCustomerclassificationRequestHandler : IRequestHandler<DeleteCustomerclassificationRequest, DefaultIdType>
{
    private readonly IRepository<Customerclassification> _repository;
    private readonly IStringLocalizer _t;

    public DeleteCustomerclassificationRequestHandler(IRepository<Customerclassification> repository, IStringLocalizer<DeleteCustomerclassificationRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<DefaultIdType> Handle(DeleteCustomerclassificationRequest request, CancellationToken cancellationToken)
    {
        var customerclassification = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = customerclassification ?? throw new NotFoundException(_t["Customerclassification {0} Not Found."]);

        // Add Domain Events to be raised after the commit
        customerclassification.DomainEvents.Add(EntityDeletedEvent.WithEntity(customerclassification));

        await _repository.DeleteAsync(customerclassification, cancellationToken);

        return request.Id;
    }
}