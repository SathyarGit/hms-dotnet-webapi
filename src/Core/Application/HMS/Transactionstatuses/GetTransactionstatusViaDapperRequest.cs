using Mapster;

namespace FSH.WebApi.Application.HMS.Transactionstatuses;

public class GetTransactionstatusViaDapperRequest : IRequest<TransactionstatusDto>
{
    public DefaultIdType Id { get; set; }

    public GetTransactionstatusViaDapperRequest(DefaultIdType id) => Id = id;
}

public class GetTransactionstatusViaDapperRequestHandler : IRequestHandler<GetTransactionstatusViaDapperRequest, TransactionstatusDto>
{
    private readonly IDapperRepository _repository;
    private readonly IStringLocalizer _t;

    public GetTransactionstatusViaDapperRequestHandler(IDapperRepository repository, IStringLocalizer<GetTransactionstatusViaDapperRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<TransactionstatusDto> Handle(GetTransactionstatusViaDapperRequest request, CancellationToken cancellationToken)
    {
        var transactionstatus = await _repository.QueryFirstOrDefaultAsync<Transactionstatus>(
            $"SELECT * FROM HMS.\"Transactionstatuses\" WHERE \"Id\"  = '{request.Id}' AND \"TenantId\" = '@tenant'", cancellationToken: cancellationToken);

        _ = transactionstatus ?? throw new NotFoundException(_t["Transactionstatus {0} Not Found.", request.Id]);

        // Using mapster here throws a nullreference exception because of the "BrandName" property
        // in TransactionstatusDto and the transactionstatus not having a Brand assigned.
        return new TransactionstatusDto
        {
            Id = transactionstatus.Id,
            Description = transactionstatus.Description,
            Name = transactionstatus.Name
        };
    }
}