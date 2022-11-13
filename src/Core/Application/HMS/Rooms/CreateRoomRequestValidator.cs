namespace FSH.WebApi.Application.HMS.Rooms;

public class CreateRoomRequestValidator : CustomValidator<CreateRoomRequest>
{
    public CreateRoomRequestValidator(IReadRepository<Room> roomRepo, IReadRepository<Floor> floorRepo, IReadRepository<Roomtype> roomtypeRepo, IStringLocalizer<CreateRoomRequestValidator> T)
    {
        RuleFor(p => p.RoomNumber)
            .GreaterThanOrEqualTo(1)
            .MustAsync(async (roomNumber, ct) => await roomRepo.GetBySpecAsync(new RoomByRoomNumberSpec(roomNumber), ct) is null)
                .WithMessage((_, roomNumber) => T["Room {0} already Exists.", roomNumber]);

        RuleFor(p => p.NumberOfBeds)
            .GreaterThanOrEqualTo(1);

        RuleFor(p => p.Image)
            .InjectValidator();

        RuleFor(p => p.FloorId)
            .NotEmpty()
            .MustAsync(async (id, ct) => await floorRepo.GetByIdAsync(id, ct) is not null)
                .WithMessage((_, id) => T["Floor {0} Not Found.", id]);

        RuleFor(p => p.RoomtypeId)
            .NotEmpty()
            .MustAsync(async (id, ct) => await roomtypeRepo.GetByIdAsync(id, ct) is not null)
                .WithMessage((_, id) => T["Roomtype {0} Not Found.", id]);
    }
}