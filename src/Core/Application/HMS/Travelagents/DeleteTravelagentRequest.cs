using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Travelagents;

public class DeleteTravelagentRequest : IRequest<DefaultIdType>
{
    public DefaultIdType Id { get; set; }

    public DeleteTravelagentRequest(DefaultIdType id) => Id = id;
}

public class DeleteTravelagentRequestHandler : IRequestHandler<DeleteTravelagentRequest, DefaultIdType>
{
    private readonly IRepository<Travelagent> _repository;
    private readonly IStringLocalizer _t;

    public DeleteTravelagentRequestHandler(IRepository<Travelagent> repository, IStringLocalizer<DeleteTravelagentRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<DefaultIdType> Handle(DeleteTravelagentRequest request, CancellationToken cancellationToken)
    {
        var travelagent = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = travelagent ?? throw new NotFoundException(_t["Travelagent {0} Not Found."]);

        // Add Domain Events to be raised after the commit
        travelagent.DomainEvents.Add(EntityDeletedEvent.WithEntity(travelagent));

        await _repository.DeleteAsync(travelagent, cancellationToken);

        return request.Id;
    }
}