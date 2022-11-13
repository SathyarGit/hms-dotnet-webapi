namespace FSH.WebApi.Application.HMS.Paymentmodes;

public class CreatePaymentmodeRequestValidator : CustomValidator<CreatePaymentmodeRequest>
{
    public CreatePaymentmodeRequestValidator(IReadRepository<Paymentmode> paymentmodeRepo, IReadRepository<Brand> brandRepo, IStringLocalizer<CreatePaymentmodeRequestValidator> T)
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (name, ct) => await paymentmodeRepo.GetBySpecAsync(new PaymentmodeByNameSpec(name), ct) is null)
                .WithMessage((_, name) => T["Paymentmode {0} already Exists.", name]);

    }
}