using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Foliotypes;

public class DeleteFoliotypeRequest : IRequest<DefaultIdType>
{
    public DefaultIdType Id { get; set; }

    public DeleteFoliotypeRequest(DefaultIdType id) => Id = id;
}

public class DeleteFoliotypeRequestHandler : IRequestHandler<DeleteFoliotypeRequest, DefaultIdType>
{
    private readonly IRepository<Foliotype> _repository;
    private readonly IStringLocalizer _t;

    public DeleteFoliotypeRequestHandler(IRepository<Foliotype> repository, IStringLocalizer<DeleteFoliotypeRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<DefaultIdType> Handle(DeleteFoliotypeRequest request, CancellationToken cancellationToken)
    {
        var foliotype = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = foliotype ?? throw new NotFoundException(_t["Foliotype {0} Not Found."]);

        // Add Domain Events to be raised after the commit
        foliotype.DomainEvents.Add(EntityDeletedEvent.WithEntity(foliotype));

        await _repository.DeleteAsync(foliotype, cancellationToken);

        return request.Id;
    }
}