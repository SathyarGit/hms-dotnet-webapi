using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Floors;

public class UpdateFloorRequest : IRequest<DefaultIdType>
{
    public DefaultIdType Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}

public class UpdateFloorRequestHandler : IRequestHandler<UpdateFloorRequest, DefaultIdType>
{
    private readonly IRepository<Floor> _repository;
    private readonly IStringLocalizer _t;

    public UpdateFloorRequestHandler(IRepository<Floor> repository, IStringLocalizer<UpdateFloorRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<DefaultIdType> Handle(UpdateFloorRequest request, CancellationToken cancellationToken)
    {
        var floor = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = floor ?? throw new NotFoundException(_t["Floor {0} Not Found.", request.Id]);

        var updatedFloor = floor.Update(request.Name, request.Description);

        // Add Domain Events to be raised after the commit
        floor.DomainEvents.Add(EntityUpdatedEvent.WithEntity(floor));

        await _repository.UpdateAsync(updatedFloor, cancellationToken);

        return request.Id;
    }
}