namespace FSH.WebApi.Application.HMS.Paymentmodes;

public class GetPaymentmodeRequest : IRequest<PaymentmodeDto>
{
    public DefaultIdType Id { get; set; }

    public GetPaymentmodeRequest(DefaultIdType id) => Id = id;
}

public class GetPaymentmodeRequestHandler : IRequestHandler<GetPaymentmodeRequest, PaymentmodeDto>
{
    private readonly IRepository<Paymentmode> _repository;
    private readonly IStringLocalizer _t;

    public GetPaymentmodeRequestHandler(IRepository<Paymentmode> repository, IStringLocalizer<GetPaymentmodeRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<PaymentmodeDto> Handle(GetPaymentmodeRequest request, CancellationToken cancellationToken) =>
        await _repository.GetBySpecAsync(
            (ISpecification<Paymentmode, PaymentmodeDto>)new PaymentmodeByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(_t["Paymentmode {0} Not Found.", request.Id]);
}