namespace FSH.WebApi.Application.HMS.Roomtypes;

public class CreateRoomtypeRequestValidator : CustomValidator<CreateRoomtypeRequest>
{
    public CreateRoomtypeRequestValidator(IReadRepository<Roomtype> roomtypeRepo, IReadRepository<Brand> brandRepo, IStringLocalizer<CreateRoomtypeRequestValidator> T)
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (name, ct) => await roomtypeRepo.GetBySpecAsync(new RoomtypeByNameSpec(name), ct) is null)
                .WithMessage((_, name) => T["Roomtype {0} already Exists.", name]);

    }
}