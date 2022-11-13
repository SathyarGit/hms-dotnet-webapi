using FSH.WebApi.Domain.HMS;

namespace FSH.WebApi.Application.HMS.Charges;

public class CreateChargeRequestValidator : CustomValidator<CreateChargeRequest>
{
    public CreateChargeRequestValidator(IReadRepository<Charge> chargeRepo, IReadRepository<Department> departmentRepo, IReadRepository<Folio> folioRepo, IReadRepository<Travelagent> travelagentRepo, IReadRepository<Transactionstatus> transactionstatusRepo, IStringLocalizer<CreateChargeRequestValidator> T)
    {
        RuleFor(p => p.DepartmentId)
            .NotEmpty()
            .MustAsync(async (id, ct) => await departmentRepo.GetByIdAsync(id, ct) is not null)
                .WithMessage((_, id) => T["Department {0} Not Found.", id]);

        RuleFor(p => p.FolioId)
            .NotEmpty()
            .MustAsync(async (id, ct) => await folioRepo.GetByIdAsync(id, ct) is not null)
                .WithMessage((_, id) => T["Folio {0} Not Found.", id]);

        RuleFor(p => p.TravelagentId)
            .NotEmpty()
            .MustAsync(async (id, ct) => await travelagentRepo.GetByIdAsync(id, ct) is not null)
                .WithMessage((_, id) => T["Travelagent {0} Not Found.", id]);

        RuleFor(p => p.TransactionstatusId)
            .NotEmpty()
            .MustAsync(async (id, ct) => await transactionstatusRepo.GetByIdAsync(id, ct) is not null)
                .WithMessage((_, id) => T["Transactionstatus {0} Not Found.", id]);
    }
}