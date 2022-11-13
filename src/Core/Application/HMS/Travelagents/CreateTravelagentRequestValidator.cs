namespace FSH.WebApi.Application.HMS.Travelagents;

public class CreateTravelagentRequestValidator : CustomValidator<CreateTravelagentRequest>
{
    public CreateTravelagentRequestValidator(IReadRepository<Travelagent> travelagentRepo, IReadRepository<Brand> brandRepo, IStringLocalizer<CreateTravelagentRequestValidator> T)
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(128)
            .MustAsync(async (name, ct) => await travelagentRepo.GetBySpecAsync(new TravelagentByNameSpec(name), ct) is null)
                .WithMessage((_, name) => T["Travelagent {0} already Exists.", name]);

        RuleFor(p => p.PhoneNumber)
            .NotEmpty();
    }
}