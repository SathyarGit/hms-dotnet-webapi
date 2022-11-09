using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Rooms;

public class DeleteRoomRequest : IRequest<DefaultIdType>
{
    public DefaultIdType Id { get; set; }

    public DeleteRoomRequest(DefaultIdType id) => Id = id;
}

public class DeleteRoomRequestHandler : IRequestHandler<DeleteRoomRequest, DefaultIdType>
{
    private readonly IRepository<Room> _repository;
    private readonly IStringLocalizer _t;

    public DeleteRoomRequestHandler(IRepository<Room> repository, IStringLocalizer<DeleteRoomRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<DefaultIdType> Handle(DeleteRoomRequest request, CancellationToken cancellationToken)
    {
        var room = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = room ?? throw new NotFoundException(_t["Room {0} Not Found."]);

        // Add Domain Events to be raised after the commit
        room.DomainEvents.Add(EntityDeletedEvent.WithEntity(room));

        await _repository.DeleteAsync(room, cancellationToken);

        return request.Id;
    }
}