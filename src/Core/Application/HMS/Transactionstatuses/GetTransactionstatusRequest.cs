namespace FSH.WebApi.Application.HMS.Transactionstatuses;

public class GetTransactionstatusRequest : IRequest<TransactionstatusDto>
{
    public DefaultIdType Id { get; set; }

    public GetTransactionstatusRequest(DefaultIdType id) => Id = id;
}

public class GetTransactionstatusRequestHandler : IRequestHandler<GetTransactionstatusRequest, TransactionstatusDto>
{
    private readonly IRepository<Transactionstatus> _repository;
    private readonly IStringLocalizer _t;

    public GetTransactionstatusRequestHandler(IRepository<Transactionstatus> repository, IStringLocalizer<GetTransactionstatusRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<TransactionstatusDto> Handle(GetTransactionstatusRequest request, CancellationToken cancellationToken) =>
        await _repository.GetBySpecAsync(
            (ISpecification<Transactionstatus, TransactionstatusDto>)new TransactionstatusByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(_t["Transactionstatus {0} Not Found.", request.Id]);
}