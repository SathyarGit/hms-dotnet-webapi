namespace FSH.WebApi.Application.HMS.Floors;

public class CreateFloorRequestValidator : CustomValidator<CreateFloorRequest>
{
    public CreateFloorRequestValidator(IReadRepository<Floor> floorRepo, IReadRepository<Brand> brandRepo, IStringLocalizer<CreateFloorRequestValidator> T)
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (name, ct) => await floorRepo.GetBySpecAsync(new FloorByNameSpec(name), ct) is null)
                .WithMessage((_, name) => T["Floor {0} already Exists.", name]);

    }
}