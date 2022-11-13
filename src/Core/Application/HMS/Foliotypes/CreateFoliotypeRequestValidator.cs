namespace FSH.WebApi.Application.HMS.Foliotypes;

public class CreateFoliotypeRequestValidator : CustomValidator<CreateFoliotypeRequest>
{
    public CreateFoliotypeRequestValidator(IReadRepository<Foliotype> foliotypeRepo, IReadRepository<Brand> brandRepo, IStringLocalizer<CreateFoliotypeRequestValidator> T)
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (name, ct) => await foliotypeRepo.GetBySpecAsync(new FoliotypeByNameSpec(name), ct) is null)
                .WithMessage((_, name) => T["Foliotype {0} already Exists.", name]);

    }
}