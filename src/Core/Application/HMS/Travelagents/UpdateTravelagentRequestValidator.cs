namespace FSH.WebApi.Application.HMS.Travelagents;

public class UpdateTravelagentRequestValidator : CustomValidator<UpdateTravelagentRequest>
{
    public UpdateTravelagentRequestValidator(IReadRepository<Travelagent> travelagentRepo, IReadRepository<Brand> brandRepo, IStringLocalizer<UpdateTravelagentRequestValidator> T)
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(128)
            .MustAsync(async (travelagent, name, ct) =>
                    await travelagentRepo.GetBySpecAsync(new TravelagentByNameSpec(name), ct)
                        is not Travelagent existingTravelagent || existingTravelagent.Id == travelagent.Id)
                .WithMessage((_, name) => T["Travelagent {0} already Exists.", name]);

        RuleFor(p => p.PhoneNumber)
            .NotEmpty();
    }
}