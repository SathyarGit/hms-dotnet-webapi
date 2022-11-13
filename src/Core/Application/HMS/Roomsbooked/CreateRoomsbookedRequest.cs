using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Roomsbookeds;

public class CreateRoomsbookedRequest : IRequest<DefaultIdType>
{
    public int? RoomRate { get; set; } = default!;
    public DefaultIdType RoomId { get; set; }
    public DefaultIdType BookingId { get; set; }
}

public class CreateRoomsbookedRequestHandler : IRequestHandler<CreateRoomsbookedRequest, DefaultIdType>
{
    private readonly IRepository<Roomsbooked> _repository;
    private readonly IFileStorageService _file;

    public CreateRoomsbookedRequestHandler(IRepository<Roomsbooked> repository, IFileStorageService file) =>
        (_repository, _file) = (repository, file);

    public async Task<DefaultIdType> Handle(CreateRoomsbookedRequest request, CancellationToken cancellationToken)
    {
        var roomsbooked = new Roomsbooked(request.RoomRate, request.RoomId, request.BookingId);

        // Add Domain Events to be raised after the commit
        roomsbooked.DomainEvents.Add(EntityCreatedEvent.WithEntity(roomsbooked));

        await _repository.AddAsync(roomsbooked, cancellationToken);

        return roomsbooked.Id;
    }
}