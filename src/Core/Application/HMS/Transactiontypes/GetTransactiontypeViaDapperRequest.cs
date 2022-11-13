using Mapster;

namespace FSH.WebApi.Application.HMS.Transactiontypes;

public class GetTransactiontypeViaDapperRequest : IRequest<TransactiontypeDto>
{
    public DefaultIdType Id { get; set; }

    public GetTransactiontypeViaDapperRequest(DefaultIdType id) => Id = id;
}

public class GetTransactiontypeViaDapperRequestHandler : IRequestHandler<GetTransactiontypeViaDapperRequest, TransactiontypeDto>
{
    private readonly IDapperRepository _repository;
    private readonly IStringLocalizer _t;

    public GetTransactiontypeViaDapperRequestHandler(IDapperRepository repository, IStringLocalizer<GetTransactiontypeViaDapperRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<TransactiontypeDto> Handle(GetTransactiontypeViaDapperRequest request, CancellationToken cancellationToken)
    {
        var transactiontype = await _repository.QueryFirstOrDefaultAsync<Transactiontype>(
            $"SELECT * FROM HMS.\"Transactiontypes\" WHERE \"Id\"  = '{request.Id}' AND \"TenantId\" = '@tenant'", cancellationToken: cancellationToken);

        _ = transactiontype ?? throw new NotFoundException(_t["Transactiontype {0} Not Found.", request.Id]);

        // Using mapster here throws a nullreference exception because of the "BrandName" property
        // in TransactiontypeDto and the transactiontype not having a Brand assigned.
        return new TransactiontypeDto
        {
            Id = transactiontype.Id,
            Description = transactiontype.Description,
            Name = transactiontype.Name
        };
    }
}