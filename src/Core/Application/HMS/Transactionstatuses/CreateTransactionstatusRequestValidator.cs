namespace FSH.WebApi.Application.HMS.Transactionstatuses;

public class CreateTransactionstatusRequestValidator : CustomValidator<CreateTransactionstatusRequest>
{
    public CreateTransactionstatusRequestValidator(IReadRepository<Transactionstatus> transactionstatusRepo, IReadRepository<Brand> brandRepo, IStringLocalizer<CreateTransactionstatusRequestValidator> T)
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (name, ct) => await transactionstatusRepo.GetBySpecAsync(new TransactionstatusByNameSpec(name), ct) is null)
                .WithMessage((_, name) => T["Transactionstatus {0} already Exists.", name]);

    }
}