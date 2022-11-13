namespace FSH.WebApi.Application.HMS.Roomstatuses;

public class CreateRoomstatusRequestValidator : CustomValidator<CreateRoomstatusRequest>
{
    public CreateRoomstatusRequestValidator(IReadRepository<Roomstatus> roomstatusRepo, IReadRepository<Brand> brandRepo, IStringLocalizer<CreateRoomstatusRequestValidator> T)
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (name, ct) => await roomstatusRepo.GetBySpecAsync(new RoomstatusByNameSpec(name), ct) is null)
                .WithMessage((_, name) => T["Roomstatus {0} already Exists.", name]);

    }
}