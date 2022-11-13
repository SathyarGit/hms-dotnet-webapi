using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Expensecategories;

public class UpdateExpensecategoryRequest : IRequest<DefaultIdType>
{
    public DefaultIdType Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}

public class UpdateExpensecategoryRequestHandler : IRequestHandler<UpdateExpensecategoryRequest, DefaultIdType>
{
    private readonly IRepository<Expensecategory> _repository;
    private readonly IStringLocalizer _t;

    public UpdateExpensecategoryRequestHandler(IRepository<Expensecategory> repository, IStringLocalizer<UpdateExpensecategoryRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<DefaultIdType> Handle(UpdateExpensecategoryRequest request, CancellationToken cancellationToken)
    {
        var roomtype = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = roomtype ?? throw new NotFoundException(_t["Expensecategory {0} Not Found.", request.Id]);

        var updatedExpensecategory = roomtype.Update(request.Name, request.Description);

        // Add Domain Events to be raised after the commit
        roomtype.DomainEvents.Add(EntityUpdatedEvent.WithEntity(roomtype));

        await _repository.UpdateAsync(updatedExpensecategory, cancellationToken);

        return request.Id;
    }
}