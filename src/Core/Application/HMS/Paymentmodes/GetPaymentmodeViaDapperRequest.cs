using Mapster;

namespace FSH.WebApi.Application.HMS.Paymentmodes;

public class GetPaymentmodeViaDapperRequest : IRequest<PaymentmodeDto>
{
    public DefaultIdType Id { get; set; }

    public GetPaymentmodeViaDapperRequest(DefaultIdType id) => Id = id;
}

public class GetPaymentmodeViaDapperRequestHandler : IRequestHandler<GetPaymentmodeViaDapperRequest, PaymentmodeDto>
{
    private readonly IDapperRepository _repository;
    private readonly IStringLocalizer _t;

    public GetPaymentmodeViaDapperRequestHandler(IDapperRepository repository, IStringLocalizer<GetPaymentmodeViaDapperRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<PaymentmodeDto> Handle(GetPaymentmodeViaDapperRequest request, CancellationToken cancellationToken)
    {
        var paymentmode = await _repository.QueryFirstOrDefaultAsync<Paymentmode>(
            $"SELECT * FROM HMS.\"Paymentmodes\" WHERE \"Id\"  = '{request.Id}' AND \"TenantId\" = '@tenant'", cancellationToken: cancellationToken);

        _ = paymentmode ?? throw new NotFoundException(_t["Paymentmode {0} Not Found.", request.Id]);

        // Using mapster here throws a nullreference exception because of the "BrandName" property
        // in PaymentmodeDto and the paymentmode not having a Brand assigned.
        return new PaymentmodeDto
        {
            Id = paymentmode.Id,
            Description = paymentmode.Description,
            Name = paymentmode.Name
        };
    }
}