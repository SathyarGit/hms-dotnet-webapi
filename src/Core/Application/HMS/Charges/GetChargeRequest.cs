namespace FSH.WebApi.Application.HMS.Charges;

public class GetChargeRequest : IRequest<ChargeDetailsDto>
{
    public DefaultIdType Id { get; set; }

    public GetChargeRequest(DefaultIdType id) => Id = id;
}

public class GetChargeRequestHandler : IRequestHandler<GetChargeRequest, ChargeDetailsDto>
{
    private readonly IRepository<Charge> _repository;
    private readonly IStringLocalizer _t;

    public GetChargeRequestHandler(IRepository<Charge> repository, IStringLocalizer<GetChargeRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<ChargeDetailsDto> Handle(GetChargeRequest request, CancellationToken cancellationToken) =>
        await _repository.GetBySpecAsync(
            (ISpecification<Charge, ChargeDetailsDto>)new ChargeByIdWithDepartmentSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(_t["Charge {0} Not Found.", request.Id]);
}