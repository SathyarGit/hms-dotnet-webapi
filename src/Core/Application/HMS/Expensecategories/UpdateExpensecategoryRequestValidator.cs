namespace FSH.WebApi.Application.HMS.Expensecategories;

public class UpdateExpensecategoryRequestValidator : CustomValidator<UpdateExpensecategoryRequest>
{
    public UpdateExpensecategoryRequestValidator(IReadRepository<Expensecategory> roomtypeRepo, IReadRepository<Brand> brandRepo, IStringLocalizer<UpdateExpensecategoryRequestValidator> T)
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (roomtype, name, ct) =>
                    await roomtypeRepo.GetBySpecAsync(new ExpensecategoryByNameSpec(name), ct)
                        is not Expensecategory existingExpensecategory || existingExpensecategory.Id == roomtype.Id)
                .WithMessage((_, name) => T["Expensecategory {0} already Exists.", name]);
    }
}