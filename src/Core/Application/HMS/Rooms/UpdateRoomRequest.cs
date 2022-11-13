using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Rooms;

public class UpdateRoomRequest : IRequest<DefaultIdType>
{
    public DefaultIdType Id { get; set; }
    public int RoomNumber { get; set; }
    public int NumberOfBeds { get; set; }
    public string? Notes { get; set; }
    public string? MaintenanceNotes { get; set; }
    public DefaultIdType FloorId { get; set; }
    public DefaultIdType RoomtypeId { get; set; }
    public bool DeleteCurrentImage { get; set; } = false;
    public FileUploadRequest? Image { get; set; }
}

public class UpdateRoomRequestHandler : IRequestHandler<UpdateRoomRequest, DefaultIdType>
{
    private readonly IRepository<Room> _repository;
    private readonly IStringLocalizer _t;
    private readonly IFileStorageService _file;

    public UpdateRoomRequestHandler(IRepository<Room> repository, IStringLocalizer<UpdateRoomRequestHandler> localizer, IFileStorageService file) =>
        (_repository, _t, _file) = (repository, localizer, file);

    public async Task<DefaultIdType> Handle(UpdateRoomRequest request, CancellationToken cancellationToken)
    {
        var room = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = room ?? throw new NotFoundException(_t["Room {0} Not Found.", request.Id]);

        // Remove old image if flag is set
        if (request.DeleteCurrentImage)
        {
            string? currentRoomImagePath = room.ImagePath;
            if (!string.IsNullOrEmpty(currentRoomImagePath))
            {
                string root = Directory.GetCurrentDirectory();
                _file.Remove(Path.Combine(root, currentRoomImagePath));
            }

            room = room.ClearImagePath();
        }

        string? roomImagePath = request.Image is not null
            ? await _file.UploadAsync<Room>(request.Image, FileType.Image, cancellationToken)
            : null;

        var updatedRoom = room.Update(request.RoomNumber, request.NumberOfBeds, request.Notes, request.MaintenanceNotes, request.FloorId, request.RoomtypeId, roomImagePath);

        // Add Domain Events to be raised after the commit
        room.DomainEvents.Add(EntityUpdatedEvent.WithEntity(room));

        await _repository.UpdateAsync(updatedRoom, cancellationToken);

        return request.Id;
    }
}