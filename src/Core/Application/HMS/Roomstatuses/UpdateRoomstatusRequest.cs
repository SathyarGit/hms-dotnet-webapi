using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Roomstatuses;

public class UpdateRoomstatusRequest : IRequest<DefaultIdType>
{
    public DefaultIdType Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}

public class UpdateRoomstatusRequestHandler : IRequestHandler<UpdateRoomstatusRequest, DefaultIdType>
{
    private readonly IRepository<Roomstatus> _repository;
    private readonly IStringLocalizer _t;

    public UpdateRoomstatusRequestHandler(IRepository<Roomstatus> repository, IStringLocalizer<UpdateRoomstatusRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<DefaultIdType> Handle(UpdateRoomstatusRequest request, CancellationToken cancellationToken)
    {
        var roomstatus = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = roomstatus ?? throw new NotFoundException(_t["Roomstatus {0} Not Found.", request.Id]);

        var updatedRoomstatus = roomstatus.Update(request.Name, request.Description);

        // Add Domain Events to be raised after the commit
        roomstatus.DomainEvents.Add(EntityUpdatedEvent.WithEntity(roomstatus));

        await _repository.UpdateAsync(updatedRoomstatus, cancellationToken);

        return request.Id;
    }
}