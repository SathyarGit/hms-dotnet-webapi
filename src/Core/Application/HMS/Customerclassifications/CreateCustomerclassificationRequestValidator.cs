namespace FSH.WebApi.Application.HMS.Customerclassifications;

public class CreateCustomerclassificationRequestValidator : CustomValidator<CreateCustomerclassificationRequest>
{
    public CreateCustomerclassificationRequestValidator(IReadRepository<Customerclassification> customerclassificationRepo, IReadRepository<Brand> brandRepo, IStringLocalizer<CreateCustomerclassificationRequestValidator> T)
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (name, ct) => await customerclassificationRepo.GetBySpecAsync(new CustomerclassificationByNameSpec(name), ct) is null)
                .WithMessage((_, name) => T["Customerclassification {0} already Exists.", name]);

    }
}