namespace FSH.WebApi.Application.HMS.Accountentries;

public class UpdateAccountentryRequestValidator : CustomValidator<UpdateAccountentryRequest>
{
    public UpdateAccountentryRequestValidator(IReadRepository<Accountentry> accountentryRepo, IReadRepository<Department> departmentRepo, IReadRepository<Folio> folioRepo, IReadRepository<Purchase> purchaseRepo, IReadRepository<Paymentmode> paymentmodeRepo, IReadRepository<Transactiontype> transactiontypeRepo, IReadRepository<Expensecategory> expensecategoryRepo, IStringLocalizer<CreateAccountentryRequestValidator> T)
    {
        RuleFor(p => p.DepartmentId)
            .NotEmpty()
            .MustAsync(async (id, ct) => await departmentRepo.GetByIdAsync(id, ct) is not null)
                .WithMessage((_, id) => T["Department {0} Not Found.", id]);

        RuleFor(p => p.FolioId)
            .NotEmpty()
            .MustAsync(async (id, ct) => await folioRepo.GetByIdAsync(id, ct) is not null)
                .WithMessage((_, id) => T["Folio {0} Not Found.", id]);

        RuleFor(p => p.PurchaseId)
            .NotEmpty()
            .MustAsync(async (id, ct) => await purchaseRepo.GetByIdAsync(id, ct) is not null)
                .WithMessage((_, id) => T["Purchase {0} Not Found.", id]);

        RuleFor(p => p.PaymentmodeId)
            .NotEmpty()
            .MustAsync(async (id, ct) => await paymentmodeRepo.GetByIdAsync(id, ct) is not null)
                .WithMessage((_, id) => T["Paymentmode {0} Not Found.", id]);

        RuleFor(p => p.TransactiontypeId)
            .NotEmpty()
            .MustAsync(async (id, ct) => await transactiontypeRepo.GetByIdAsync(id, ct) is not null)
                .WithMessage((_, id) => T["Transactiontype {0} Not Found.", id]);

        RuleFor(p => p.ExpensecategoryId)
            .NotEmpty()
            .MustAsync(async (id, ct) => await expensecategoryRepo.GetByIdAsync(id, ct) is not null)
                .WithMessage((_, id) => T["Expensecategory {0} Not Found.", id]);
    }
}