using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Roomsbookeds;

public class UpdateRoomsbookedRequest : IRequest<DefaultIdType>
{
    public DefaultIdType Id { get; set; }
    public int? RoomRate { get; set; }
    public DefaultIdType RoomId { get; set; }
    public DefaultIdType BookingId { get; set; }
}

public class UpdateRoomsbookedRequestHandler : IRequestHandler<UpdateRoomsbookedRequest, DefaultIdType>
{
    private readonly IRepository<Roomsbooked> _repository;
    private readonly IStringLocalizer _t;
    private readonly IFileStorageService _file;

    public UpdateRoomsbookedRequestHandler(IRepository<Roomsbooked> repository, IStringLocalizer<UpdateRoomsbookedRequestHandler> localizer, IFileStorageService file) =>
        (_repository, _t, _file) = (repository, localizer, file);

    public async Task<DefaultIdType> Handle(UpdateRoomsbookedRequest request, CancellationToken cancellationToken)
    {
        var roomsbooked = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = roomsbooked ?? throw new NotFoundException(_t["Roomsbooked {0} Not Found.", request.Id]);

        var updatedRoomsbooked = roomsbooked.Update(request.RoomRate, request.RoomId, request.BookingId);

        // Add Domain Events to be raised after the commit
        roomsbooked.DomainEvents.Add(EntityUpdatedEvent.WithEntity(roomsbooked));

        await _repository.UpdateAsync(updatedRoomsbooked, cancellationToken);

        return request.Id;
    }
}