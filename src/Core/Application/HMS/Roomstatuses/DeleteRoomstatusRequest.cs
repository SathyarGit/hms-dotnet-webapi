using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Roomstatuses;

public class DeleteRoomstatusRequest : IRequest<DefaultIdType>
{
    public DefaultIdType Id { get; set; }

    public DeleteRoomstatusRequest(DefaultIdType id) => Id = id;
}

public class DeleteRoomstatusRequestHandler : IRequestHandler<DeleteRoomstatusRequest, DefaultIdType>
{
    private readonly IRepository<Roomstatus> _repository;
    private readonly IStringLocalizer _t;

    public DeleteRoomstatusRequestHandler(IRepository<Roomstatus> repository, IStringLocalizer<DeleteRoomstatusRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<DefaultIdType> Handle(DeleteRoomstatusRequest request, CancellationToken cancellationToken)
    {
        var roomstatus = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = roomstatus ?? throw new NotFoundException(_t["Roomstatus {0} Not Found."]);

        // Add Domain Events to be raised after the commit
        roomstatus.DomainEvents.Add(EntityDeletedEvent.WithEntity(roomstatus));

        await _repository.DeleteAsync(roomstatus, cancellationToken);

        return request.Id;
    }
}