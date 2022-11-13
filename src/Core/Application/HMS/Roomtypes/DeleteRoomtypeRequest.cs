using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Roomtypes;

public class DeleteRoomtypeRequest : IRequest<DefaultIdType>
{
    public DefaultIdType Id { get; set; }

    public DeleteRoomtypeRequest(DefaultIdType id) => Id = id;
}

public class DeleteRoomtypeRequestHandler : IRequestHandler<DeleteRoomtypeRequest, DefaultIdType>
{
    private readonly IRepository<Roomtype> _repository;
    private readonly IStringLocalizer _t;

    public DeleteRoomtypeRequestHandler(IRepository<Roomtype> repository, IStringLocalizer<DeleteRoomtypeRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<DefaultIdType> Handle(DeleteRoomtypeRequest request, CancellationToken cancellationToken)
    {
        var roomtype = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = roomtype ?? throw new NotFoundException(_t["Roomtype {0} Not Found."]);

        // Add Domain Events to be raised after the commit
        roomtype.DomainEvents.Add(EntityDeletedEvent.WithEntity(roomtype));

        await _repository.DeleteAsync(roomtype, cancellationToken);

        return request.Id;
    }
}