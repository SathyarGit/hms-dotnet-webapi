using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Charges;

public class DeleteChargeRequest : IRequest<DefaultIdType>
{
    public DefaultIdType Id { get; set; }

    public DeleteChargeRequest(DefaultIdType id) => Id = id;
}

public class DeleteChargeRequestHandler : IRequestHandler<DeleteChargeRequest, DefaultIdType>
{
    private readonly IRepository<Charge> _repository;
    private readonly IStringLocalizer _t;

    public DeleteChargeRequestHandler(IRepository<Charge> repository, IStringLocalizer<DeleteChargeRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<DefaultIdType> Handle(DeleteChargeRequest request, CancellationToken cancellationToken)
    {
        var charge = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = charge ?? throw new NotFoundException(_t["Charge {0} Not Found."]);

        // Add Domain Events to be raised after the commit
        charge.DomainEvents.Add(EntityDeletedEvent.WithEntity(charge));

        await _repository.DeleteAsync(charge, cancellationToken);

        return request.Id;
    }
}