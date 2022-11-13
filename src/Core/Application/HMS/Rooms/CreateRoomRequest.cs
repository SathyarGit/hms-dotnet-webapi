using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Rooms;

public class CreateRoomRequest : IRequest<DefaultIdType>
{
    public int RoomNumber { get; set; }
    public int NumberOfBeds { get; set; }
    public string? Notes { get; set; }
    public string? MaintenanceNotes { get; set; }
    public FileUploadRequest? Image { get; set; }
    public DefaultIdType FloorId { get; set; }
    public DefaultIdType RoomtypeId { get; set; }
}

public class CreateRoomRequestHandler : IRequestHandler<CreateRoomRequest, DefaultIdType>
{
    private readonly IRepository<Room> _repository;
    private readonly IFileStorageService _file;

    public CreateRoomRequestHandler(IRepository<Room> repository, IFileStorageService file) =>
        (_repository, _file) = (repository, file);

    public async Task<DefaultIdType> Handle(CreateRoomRequest request, CancellationToken cancellationToken)
    {
        string roomImagePath = await _file.UploadAsync<Room>(request.Image, FileType.Image, cancellationToken);

        var room = new Room(request.RoomNumber, request.NumberOfBeds, request.Notes, request.MaintenanceNotes, request.FloorId, request.RoomtypeId, roomImagePath);

        // Add Domain Events to be raised after the commit
        room.DomainEvents.Add(EntityCreatedEvent.WithEntity(room));

        await _repository.AddAsync(room, cancellationToken);

        return room.Id;
    }
}