namespace FSH.WebApi.Application.HMS.Customers;

public class UpdateCustomerRequestValidator : CustomValidator<UpdateCustomerRequest>
{
    public UpdateCustomerRequestValidator(IReadRepository<Customer> customerRepo, IReadRepository<Customerclassification> customerclassificationRepo, IStringLocalizer<UpdateCustomerRequestValidator> T)
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(128)
            .MustAsync(async (customer, name, ct) =>
                    await customerRepo.GetBySpecAsync(new CustomerByNameSpec(name), ct)
                        is not Customer existingCustomer || existingCustomer.Id == customer.Id)
                .WithMessage((_, name) => T["Customer {0} already Exists.", name]);

        RuleFor(p => p.Image)
            .InjectValidator();

        RuleFor(p => p.CustclassificationId)
            .NotEmpty()
            .MustAsync(async (id, ct) => await customerclassificationRepo.GetByIdAsync(id, ct) is not null)
                .WithMessage((_, id) => T["Custclassification {0} Not Found.", id]);
    }
}