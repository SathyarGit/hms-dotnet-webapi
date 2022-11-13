using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Customerclassifications;

public class UpdateCustomerclassificationRequest : IRequest<DefaultIdType>
{
    public DefaultIdType Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}

public class UpdateCustomerclassificationRequestHandler : IRequestHandler<UpdateCustomerclassificationRequest, DefaultIdType>
{
    private readonly IRepository<Customerclassification> _repository;
    private readonly IStringLocalizer _t;

    public UpdateCustomerclassificationRequestHandler(IRepository<Customerclassification> repository, IStringLocalizer<UpdateCustomerclassificationRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<DefaultIdType> Handle(UpdateCustomerclassificationRequest request, CancellationToken cancellationToken)
    {
        var customerclassification = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = customerclassification ?? throw new NotFoundException(_t["Customerclassification {0} Not Found.", request.Id]);

        var updatedCustomerclassification = customerclassification.Update(request.Name, request.Description);

        // Add Domain Events to be raised after the commit
        customerclassification.DomainEvents.Add(EntityUpdatedEvent.WithEntity(customerclassification));

        await _repository.UpdateAsync(updatedCustomerclassification, cancellationToken);

        return request.Id;
    }
}