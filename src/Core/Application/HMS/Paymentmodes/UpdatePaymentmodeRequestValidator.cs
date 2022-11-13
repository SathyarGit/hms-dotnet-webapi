namespace FSH.WebApi.Application.HMS.Paymentmodes;

public class UpdatePaymentmodeRequestValidator : CustomValidator<UpdatePaymentmodeRequest>
{
    public UpdatePaymentmodeRequestValidator(IReadRepository<Paymentmode> paymentmodeRepo, IReadRepository<Brand> brandRepo, IStringLocalizer<UpdatePaymentmodeRequestValidator> T)
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (paymentmode, name, ct) =>
                    await paymentmodeRepo.GetBySpecAsync(new PaymentmodeByNameSpec(name), ct)
                        is not Paymentmode existingPaymentmode || existingPaymentmode.Id == paymentmode.Id)
                .WithMessage((_, name) => T["Paymentmode {0} already Exists.", name]);
    }
}