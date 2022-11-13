namespace FSH.WebApi.Application.HMS.Roomtypes;

public class UpdateRoomtypeRequestValidator : CustomValidator<UpdateRoomtypeRequest>
{
    public UpdateRoomtypeRequestValidator(IReadRepository<Roomtype> roomtypeRepo, IReadRepository<Brand> brandRepo, IStringLocalizer<UpdateRoomtypeRequestValidator> T)
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (roomtype, name, ct) =>
                    await roomtypeRepo.GetBySpecAsync(new RoomtypeByNameSpec(name), ct)
                        is not Roomtype existingRoomtype || existingRoomtype.Id == roomtype.Id)
                .WithMessage((_, name) => T["Roomtype {0} already Exists.", name]);
    }
}