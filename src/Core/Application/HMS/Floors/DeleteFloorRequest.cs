using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Floors;

public class DeleteFloorRequest : IRequest<Guid>
{
    public Guid Id { get; set; }

    public DeleteFloorRequest(Guid id) => Id = id;
}

public class DeleteFloorRequestHandler : IRequestHandler<DeleteFloorRequest, Guid>
{
    private readonly IRepository<Floor> _repository;
    private readonly IStringLocalizer _t;

    public DeleteFloorRequestHandler(IRepository<Floor> repository, IStringLocalizer<DeleteFloorRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<Guid> Handle(DeleteFloorRequest request, CancellationToken cancellationToken)
    {
        var floor = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = floor ?? throw new NotFoundException(_t["Floor {0} Not Found."]);

        // Add Domain Events to be raised after the commit
        floor.DomainEvents.Add(EntityDeletedEvent.WithEntity(floor));

        await _repository.DeleteAsync(floor, cancellationToken);

        return request.Id;
    }
}