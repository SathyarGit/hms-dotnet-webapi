namespace FSH.WebApi.Application.HMS.Roomstatuses;

public class UpdateRoomstatusRequestValidator : CustomValidator<UpdateRoomstatusRequest>
{
    public UpdateRoomstatusRequestValidator(IReadRepository<Roomstatus> roomstatusRepo, IReadRepository<Brand> brandRepo, IStringLocalizer<UpdateRoomstatusRequestValidator> T)
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (roomstatus, name, ct) =>
                    await roomstatusRepo.GetBySpecAsync(new RoomstatusByNameSpec(name), ct)
                        is not Roomstatus existingRoomstatus || existingRoomstatus.Id == roomstatus.Id)
                .WithMessage((_, name) => T["Roomstatus {0} already Exists.", name]);
    }
}