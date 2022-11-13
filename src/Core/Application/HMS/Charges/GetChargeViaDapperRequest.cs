using Mapster;

namespace FSH.WebApi.Application.HMS.Charges;

public class GetChargeViaDapperRequest : IRequest<ChargeDto>
{
    public DefaultIdType Id { get; set; }

    public GetChargeViaDapperRequest(DefaultIdType id) => Id = id;
}

public class GetChargeViaDapperRequestHandler : IRequestHandler<GetChargeViaDapperRequest, ChargeDto>
{
    private readonly IDapperRepository _repository;
    private readonly IStringLocalizer _t;

    public GetChargeViaDapperRequestHandler(IDapperRepository repository, IStringLocalizer<GetChargeViaDapperRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<ChargeDto> Handle(GetChargeViaDapperRequest request, CancellationToken cancellationToken)
    {
        var charge = await _repository.QueryFirstOrDefaultAsync<Charge>(
            $"SELECT * FROM HMS.\"Charges\" WHERE \"Id\"  = '{request.Id}' AND \"TenantId\" = '@tenant'", cancellationToken: cancellationToken);

        _ = charge ?? throw new NotFoundException(_t["Charge {0} Not Found.", request.Id]);

        // Using mapster here throws a nullreference exception because of the "DepartmentName" property
        // in ChargeDto and the charge not having a Department assigned.
        return new ChargeDto
        {
            Id = charge.Id,
            ChargeDate = charge.ChargeDate,
            FolioId = charge.FolioId,
            Amount = charge.Amount,
            Description = charge.Description,
            DepartmentId = charge.DepartmentId,
            TransactionstatusId = charge.TransactionstatusId,
            TravelagentId = charge.TravelagentId,
            DepartmentName = string.Empty,
            TransactionstatusName = string.Empty,
            TravelagentName = string.Empty
        };
    }
}