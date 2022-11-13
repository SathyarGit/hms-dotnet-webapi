namespace FSH.WebApi.Application.HMS.Transactiontypes;

public class CreateTransactiontypeRequestValidator : CustomValidator<CreateTransactiontypeRequest>
{
    public CreateTransactiontypeRequestValidator(IReadRepository<Transactiontype> transactiontypeRepo, IReadRepository<Brand> brandRepo, IStringLocalizer<CreateTransactiontypeRequestValidator> T)
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (name, ct) => await transactiontypeRepo.GetBySpecAsync(new TransactiontypeByNameSpec(name), ct) is null)
                .WithMessage((_, name) => T["Transactiontype {0} already Exists.", name]);

    }
}