using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Roomsbookeds;

public class DeleteRoomsbookedRequest : IRequest<DefaultIdType>
{
    public DefaultIdType Id { get; set; }

    public DeleteRoomsbookedRequest(DefaultIdType id) => Id = id;
}

public class DeleteRoomsbookedRequestHandler : IRequestHandler<DeleteRoomsbookedRequest, DefaultIdType>
{
    private readonly IRepository<Roomsbooked> _repository;
    private readonly IStringLocalizer _t;

    public DeleteRoomsbookedRequestHandler(IRepository<Roomsbooked> repository, IStringLocalizer<DeleteRoomsbookedRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<DefaultIdType> Handle(DeleteRoomsbookedRequest request, CancellationToken cancellationToken)
    {
        var roomsbooked = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = roomsbooked ?? throw new NotFoundException(_t["Roomsbooked {0} Not Found."]);

        // Add Domain Events to be raised after the commit
        roomsbooked.DomainEvents.Add(EntityDeletedEvent.WithEntity(roomsbooked));

        await _repository.DeleteAsync(roomsbooked, cancellationToken);

        return request.Id;
    }
}