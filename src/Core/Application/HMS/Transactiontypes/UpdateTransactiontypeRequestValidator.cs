namespace FSH.WebApi.Application.HMS.Transactiontypes;

public class UpdateTransactiontypeRequestValidator : CustomValidator<UpdateTransactiontypeRequest>
{
    public UpdateTransactiontypeRequestValidator(IReadRepository<Transactiontype> transactiontypeRepo, IReadRepository<Brand> brandRepo, IStringLocalizer<UpdateTransactiontypeRequestValidator> T)
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (transactiontype, name, ct) =>
                    await transactiontypeRepo.GetBySpecAsync(new TransactiontypeByNameSpec(name), ct)
                        is not Transactiontype existingTransactiontype || existingTransactiontype.Id == transactiontype.Id)
                .WithMessage((_, name) => T["Transactiontype {0} already Exists.", name]);
    }
}