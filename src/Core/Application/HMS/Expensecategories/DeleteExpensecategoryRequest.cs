using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Expensecategories;

public class DeleteExpensecategoryRequest : IRequest<DefaultIdType>
{
    public DefaultIdType Id { get; set; }

    public DeleteExpensecategoryRequest(DefaultIdType id) => Id = id;
}

public class DeleteExpensecategoryRequestHandler : IRequestHandler<DeleteExpensecategoryRequest, DefaultIdType>
{
    private readonly IRepository<Expensecategory> _repository;
    private readonly IStringLocalizer _t;

    public DeleteExpensecategoryRequestHandler(IRepository<Expensecategory> repository, IStringLocalizer<DeleteExpensecategoryRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<DefaultIdType> Handle(DeleteExpensecategoryRequest request, CancellationToken cancellationToken)
    {
        var roomtype = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = roomtype ?? throw new NotFoundException(_t["Expensecategory {0} Not Found."]);

        // Add Domain Events to be raised after the commit
        roomtype.DomainEvents.Add(EntityDeletedEvent.WithEntity(roomtype));

        await _repository.DeleteAsync(roomtype, cancellationToken);

        return request.Id;
    }
}