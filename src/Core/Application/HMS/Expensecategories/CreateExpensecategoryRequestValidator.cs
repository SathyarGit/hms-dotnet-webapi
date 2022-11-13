namespace FSH.WebApi.Application.HMS.Expensecategories;

public class CreateExpensecategoryRequestValidator : CustomValidator<CreateExpensecategoryRequest>
{
    public CreateExpensecategoryRequestValidator(IReadRepository<Expensecategory> roomtypeRepo, IReadRepository<Brand> brandRepo, IStringLocalizer<CreateExpensecategoryRequestValidator> T)
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (name, ct) => await roomtypeRepo.GetBySpecAsync(new ExpensecategoryByNameSpec(name), ct) is null)
                .WithMessage((_, name) => T["Expensecategory {0} already Exists.", name]);

    }
}