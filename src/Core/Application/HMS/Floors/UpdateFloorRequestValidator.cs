namespace FSH.WebApi.Application.HMS.Floors;

public class UpdateFloorRequestValidator : CustomValidator<UpdateFloorRequest>
{
    public UpdateFloorRequestValidator(IReadRepository<Floor> floorRepo, IReadRepository<Brand> brandRepo, IStringLocalizer<UpdateFloorRequestValidator> T)
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (floor, name, ct) =>
                    await floorRepo.GetBySpecAsync(new FloorByNameSpec(name), ct)
                        is not Floor existingFloor || existingFloor.Id == floor.Id)
                .WithMessage((_, name) => T["Floor {0} already Exists.", name]);
    }
}