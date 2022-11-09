namespace FSH.WebApi.Application.HMS.Rooms;

public class UpdateRoomRequestValidator : CustomValidator<UpdateRoomRequest>
{
    public UpdateRoomRequestValidator(IReadRepository<Room> roomRepo, IReadRepository<Floor> floorRepo, IStringLocalizer<UpdateRoomRequestValidator> T)
    {
        RuleFor(p => p.RoomNumber)
            .GreaterThanOrEqualTo(1)
            .MustAsync(async (room, roomNumber, ct) =>
                    await roomRepo.GetBySpecAsync(new RoomByRoomNumberSpec(roomNumber), ct)
                        is not Room existingRoom || existingRoom.Id == room.Id)
                .WithMessage((_, roomNumber) => T["Room {0} already Exists.", roomNumber]);

        RuleFor(p => p.NumberOfBeds)
            .GreaterThanOrEqualTo(1);

        RuleFor(p => p.Image)
            .InjectValidator();

        RuleFor(p => p.FloorId)
            .NotEmpty()
            .MustAsync(async (id, ct) => await floorRepo.GetByIdAsync(id, ct) is not null)
                .WithMessage((_, id) => T["Floor {0} Not Found.", id]);
    }
}