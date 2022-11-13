namespace FSH.WebApi.Application.HMS.Customers;

public class CreateCustomerRequestValidator : CustomValidator<CreateCustomerRequest>
{
    public CreateCustomerRequestValidator(IReadRepository<Customer> customerRepo, IReadRepository<Customerclassification> customerclassificationRepo, IStringLocalizer<CreateCustomerRequestValidator> T)
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(128);

        RuleFor(p => p.Image)
            .InjectValidator();

        RuleFor(p => p.CustclassificationId)
            .NotEmpty()
            .MustAsync(async (id, ct) => await customerclassificationRepo.GetByIdAsync(id, ct) is not null)
                .WithMessage((_, id) => T["Customerclassification {0} Not Found.", id]);
    }
}