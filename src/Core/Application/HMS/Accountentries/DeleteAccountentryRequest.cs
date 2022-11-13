using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Accountentries;

public class DeleteAccountentryRequest : IRequest<DefaultIdType>
{
    public DefaultIdType Id { get; set; }

    public DeleteAccountentryRequest(DefaultIdType id) => Id = id;
}

public class DeleteAccountentryRequestHandler : IRequestHandler<DeleteAccountentryRequest, DefaultIdType>
{
    private readonly IRepository<Accountentry> _repository;
    private readonly IStringLocalizer _t;

    public DeleteAccountentryRequestHandler(IRepository<Accountentry> repository, IStringLocalizer<DeleteAccountentryRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<DefaultIdType> Handle(DeleteAccountentryRequest request, CancellationToken cancellationToken)
    {
        var accountentry = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = accountentry ?? throw new NotFoundException(_t["Accountentry {0} Not Found."]);

        // Add Domain Events to be raised after the commit
        accountentry.DomainEvents.Add(EntityDeletedEvent.WithEntity(accountentry));

        await _repository.DeleteAsync(accountentry, cancellationToken);

        return request.Id;
    }
}