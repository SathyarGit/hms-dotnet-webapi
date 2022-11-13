namespace FSH.WebApi.Application.HMS.Transactiontypes;

public class GetTransactiontypeRequest : IRequest<TransactiontypeDto>
{
    public DefaultIdType Id { get; set; }

    public GetTransactiontypeRequest(DefaultIdType id) => Id = id;
}

public class GetTransactiontypeRequestHandler : IRequestHandler<GetTransactiontypeRequest, TransactiontypeDto>
{
    private readonly IRepository<Transactiontype> _repository;
    private readonly IStringLocalizer _t;

    public GetTransactiontypeRequestHandler(IRepository<Transactiontype> repository, IStringLocalizer<GetTransactiontypeRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<TransactiontypeDto> Handle(GetTransactiontypeRequest request, CancellationToken cancellationToken) =>
        await _repository.GetBySpecAsync(
            (ISpecification<Transactiontype, TransactiontypeDto>)new TransactiontypeByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(_t["Transactiontype {0} Not Found.", request.Id]);
}