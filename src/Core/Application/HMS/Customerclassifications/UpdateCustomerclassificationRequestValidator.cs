namespace FSH.WebApi.Application.HMS.Customerclassifications;

public class UpdateCustomerclassificationRequestValidator : CustomValidator<UpdateCustomerclassificationRequest>
{
    public UpdateCustomerclassificationRequestValidator(IReadRepository<Customerclassification> customerclassificationRepo, IReadRepository<Brand> brandRepo, IStringLocalizer<UpdateCustomerclassificationRequestValidator> T)
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (customerclassification, name, ct) =>
                    await customerclassificationRepo.GetBySpecAsync(new CustomerclassificationByNameSpec(name), ct)
                        is not Customerclassification existingCustomerclassification || existingCustomerclassification.Id == customerclassification.Id)
                .WithMessage((_, name) => T["Customerclassification {0} already Exists.", name]);
    }
}