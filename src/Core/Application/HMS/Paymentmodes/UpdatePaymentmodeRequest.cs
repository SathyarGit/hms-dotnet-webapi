using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Paymentmodes;

public class UpdatePaymentmodeRequest : IRequest<DefaultIdType>
{
    public DefaultIdType Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}

public class UpdatePaymentmodeRequestHandler : IRequestHandler<UpdatePaymentmodeRequest, DefaultIdType>
{
    private readonly IRepository<Paymentmode> _repository;
    private readonly IStringLocalizer _t;

    public UpdatePaymentmodeRequestHandler(IRepository<Paymentmode> repository, IStringLocalizer<UpdatePaymentmodeRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<DefaultIdType> Handle(UpdatePaymentmodeRequest request, CancellationToken cancellationToken)
    {
        var paymentmode = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = paymentmode ?? throw new NotFoundException(_t["Paymentmode {0} Not Found.", request.Id]);

        var updatedPaymentmode = paymentmode.Update(request.Name, request.Description);

        // Add Domain Events to be raised after the commit
        paymentmode.DomainEvents.Add(EntityUpdatedEvent.WithEntity(paymentmode));

        await _repository.UpdateAsync(updatedPaymentmode, cancellationToken);

        return request.Id;
    }
}