using Mapster;

namespace FSH.WebApi.Application.HMS.Accountentries;

public class GetAccountentryViaDapperRequest : IRequest<AccountentryDto>
{
    public DefaultIdType Id { get; set; }

    public GetAccountentryViaDapperRequest(DefaultIdType id) => Id = id;
}

public class GetAccountentryViaDapperRequestHandler : IRequestHandler<GetAccountentryViaDapperRequest, AccountentryDto>
{
    private readonly IDapperRepository _repository;
    private readonly IStringLocalizer _t;

    public GetAccountentryViaDapperRequestHandler(IDapperRepository repository, IStringLocalizer<GetAccountentryViaDapperRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<AccountentryDto> Handle(GetAccountentryViaDapperRequest request, CancellationToken cancellationToken)
    {
        var accountentry = await _repository.QueryFirstOrDefaultAsync<Accountentry>(
            $"SELECT * FROM HMS.\"Accountentries\" WHERE \"Id\"  = '{request.Id}' AND \"TenantId\" = '@tenant'", cancellationToken: cancellationToken);

        _ = accountentry ?? throw new NotFoundException(_t["Accountentry {0} Not Found.", request.Id]);

        // Using mapster here throws a nullreference exception because of the "DepartmentName" property
        // in AccountentryDto and the accountentry not having a Department assigned.
        return new AccountentryDto
        {
            Id = accountentry.Id,
            TransactionDate = accountentry.TransactionDate,
            FolioId = accountentry.FolioId,
            PurchaseId = accountentry.PurchaseId,
            PaymentmodeId = accountentry.PaymentmodeId,
            DepartmentId = accountentry.DepartmentId,
            ExpensecategoryId = accountentry.ExpensecategoryId,
            Amount = accountentry.Amount,
            TransactiontypeId = accountentry.TransactiontypeId,
            Description = accountentry.Description,
            DepartmentName = string.Empty,
            PaymentmodeName = string.Empty,
            ExpensecategoryName = string.Empty,
            TransactiontypeName = string.Empty
        };
    }
}