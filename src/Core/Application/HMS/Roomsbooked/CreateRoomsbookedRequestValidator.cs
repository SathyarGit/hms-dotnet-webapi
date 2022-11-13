namespace FSH.WebApi.Application.HMS.Roomsbookeds;

public class CreateRoomsbookedRequestValidator : CustomValidator<CreateRoomsbookedRequest>
{
    public CreateRoomsbookedRequestValidator(IReadRepository<Roomsbooked> roomsbookedRepo, IReadRepository<Room> roomRepo, IReadRepository<Booking> bookingRepo, IStringLocalizer<CreateRoomsbookedRequestValidator> T)
    {
        RuleFor(p => p.RoomRate)
            .GreaterThanOrEqualTo(1);

        RuleFor(p => p.RoomId)
            .NotEmpty()
            .MustAsync(async (id, ct) => await roomRepo.GetByIdAsync(id, ct) is not null)
                .WithMessage((_, id) => T["Room {0} Not Found.", id]);

        RuleFor(p => p.BookingId)
            .NotEmpty()
            .MustAsync(async (id, ct) => await bookingRepo.GetByIdAsync(id, ct) is not null)
            .WithMessage((_, id) => T["Booking {0} Not Found.", id]);
    }
}