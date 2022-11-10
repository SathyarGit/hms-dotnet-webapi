
namespace FSH.WebApi.Domain.HMS;

public class Room : AuditableEntity, IAggregateRoot
{
    public int RoomNumber { get; private set; }
    public int NumberOfBeds { get; private set; }
    public string? Notes { get; private set; }
    public string? MaintenanceNotes { get; private set; }
    public string? ImagePath { get; private set; }
    public DefaultIdType FloorId { get; private set; }
    public virtual Floor Floor { get; private set; } = default!;

    public Room(int roomNumber, int numberOfBeds, string? notes, string? maintenanceNotes, DefaultIdType floorId, string? imagePath)
    {
        RoomNumber = roomNumber;
        NumberOfBeds = numberOfBeds;
        Notes = notes;
        MaintenanceNotes = maintenanceNotes;
        FloorId = floorId;
        ImagePath = imagePath;
    }

    public Room Update(int? roomNumber, int? numberOfBeds, string? notes, string? maintenanceNotes, DefaultIdType? floorId, string? imagePath)
    {
        if (roomNumber.HasValue && RoomNumber != roomNumber) RoomNumber = roomNumber.Value;
        if (numberOfBeds.HasValue && NumberOfBeds != numberOfBeds) NumberOfBeds = numberOfBeds.Value;
        if (notes is not null && Notes?.Equals(notes) is not true) Notes= notes;
        if (maintenanceNotes is not null && MaintenanceNotes?.Equals(maintenanceNotes) is not true) MaintenanceNotes = maintenanceNotes;
        if (floorId.HasValue && floorId.Value != DefaultIdType.Empty && !FloorId.Equals(floorId.Value)) FloorId = floorId.Value;
        if (imagePath is not null && ImagePath?.Equals(imagePath) is not true) ImagePath = imagePath;
        return this;
    }

    public Room ClearImagePath()
    {
        ImagePath = string.Empty;
        return this;
    }
}