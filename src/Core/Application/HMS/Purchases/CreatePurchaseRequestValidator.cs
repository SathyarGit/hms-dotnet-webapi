namespace FSH.WebApi.Application.HMS.Purchases;

public class CreatePurchaseRequestValidator : CustomValidator<CreatePurchaseRequest>
{
    public CreatePurchaseRequestValidator(IReadRepository<Purchase> purchaseRepo, IReadRepository<Department> departmentRepo, IReadRepository<Vendor> vendorRepo, IReadRepository<Transactionstatus> transactionstatusRepo, IStringLocalizer<CreatePurchaseRequestValidator> T)
    {
        RuleFor(p => p.Image)
            .InjectValidator();

        RuleFor(p => p.DepartmentId)
            .NotEmpty()
            .MustAsync(async (id, ct) => await departmentRepo.GetByIdAsync(id, ct) is not null)
                .WithMessage((_, id) => T["Department {0} Not Found.", id]);

        RuleFor(p => p.VendorId)
            .NotEmpty()
            .MustAsync(async (id, ct) => await vendorRepo.GetByIdAsync(id, ct) is not null)
                .WithMessage((_, id) => T["Vendor {0} Not Found.", id]);

        RuleFor(p => p.TransactionstatusId)
            .NotEmpty()
            .MustAsync(async (id, ct) => await transactionstatusRepo.GetByIdAsync(id, ct) is not null)
                .WithMessage((_, id) => T["Transactionstatus {0} Not Found.", id]);
    }
}