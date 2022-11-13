using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Paymentmodes;

public class DeletePaymentmodeRequest : IRequest<DefaultIdType>
{
    public DefaultIdType Id { get; set; }

    public DeletePaymentmodeRequest(DefaultIdType id) => Id = id;
}

public class DeletePaymentmodeRequestHandler : IRequestHandler<DeletePaymentmodeRequest, DefaultIdType>
{
    private readonly IRepository<Paymentmode> _repository;
    private readonly IStringLocalizer _t;

    public DeletePaymentmodeRequestHandler(IRepository<Paymentmode> repository, IStringLocalizer<DeletePaymentmodeRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<DefaultIdType> Handle(DeletePaymentmodeRequest request, CancellationToken cancellationToken)
    {
        var paymentmode = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = paymentmode ?? throw new NotFoundException(_t["Paymentmode {0} Not Found."]);

        // Add Domain Events to be raised after the commit
        paymentmode.DomainEvents.Add(EntityDeletedEvent.WithEntity(paymentmode));

        await _repository.DeleteAsync(paymentmode, cancellationToken);

        return request.Id;
    }
}