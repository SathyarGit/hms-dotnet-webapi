namespace FSH.WebApi.Application.HMS.Transactionstatuses;

public class UpdateTransactionstatusRequestValidator : CustomValidator<UpdateTransactionstatusRequest>
{
    public UpdateTransactionstatusRequestValidator(IReadRepository<Transactionstatus> transactionstatusRepo, IReadRepository<Brand> brandRepo, IStringLocalizer<UpdateTransactionstatusRequestValidator> T)
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (transactionstatus, name, ct) =>
                    await transactionstatusRepo.GetBySpecAsync(new TransactionstatusByNameSpec(name), ct)
                        is not Transactionstatus existingTransactionstatus || existingTransactionstatus.Id == transactionstatus.Id)
                .WithMessage((_, name) => T["Transactionstatus {0} already Exists.", name]);
    }
}