namespace FSH.WebApi.Application.HMS.Foliotypes;

public class UpdateFoliotypeRequestValidator : CustomValidator<UpdateFoliotypeRequest>
{
    public UpdateFoliotypeRequestValidator(IReadRepository<Foliotype> foliotypeRepo, IReadRepository<Brand> brandRepo, IStringLocalizer<UpdateFoliotypeRequestValidator> T)
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (foliotype, name, ct) =>
                    await foliotypeRepo.GetBySpecAsync(new FoliotypeByNameSpec(name), ct)
                        is not Foliotype existingFoliotype || existingFoliotype.Id == foliotype.Id)
                .WithMessage((_, name) => T["Foliotype {0} already Exists.", name]);
    }
}