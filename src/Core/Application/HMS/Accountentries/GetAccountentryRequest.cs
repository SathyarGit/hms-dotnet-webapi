namespace FSH.WebApi.Application.HMS.Accountentries;

public class GetAccountentryRequest : IRequest<AccountentryDetailsDto>
{
    public DefaultIdType Id { get; set; }

    public GetAccountentryRequest(DefaultIdType id) => Id = id;
}

public class GetAccountentryRequestHandler : IRequestHandler<GetAccountentryRequest, AccountentryDetailsDto>
{
    private readonly IRepository<Accountentry> _repository;
    private readonly IStringLocalizer _t;

    public GetAccountentryRequestHandler(IRepository<Accountentry> repository, IStringLocalizer<GetAccountentryRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<AccountentryDetailsDto> Handle(GetAccountentryRequest request, CancellationToken cancellationToken) =>
        await _repository.GetBySpecAsync(
            (ISpecification<Accountentry, AccountentryDetailsDto>)new AccountentryByIdWithDepartmentSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(_t["Accountentry {0} Not Found.", request.Id]);
}