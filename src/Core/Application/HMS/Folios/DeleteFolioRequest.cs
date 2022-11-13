using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Folios;

public class DeleteFolioRequest : IRequest<DefaultIdType>
{
    public DefaultIdType Id { get; set; }

    public DeleteFolioRequest(DefaultIdType id) => Id = id;
}

public class DeleteFolioRequestHandler : IRequestHandler<DeleteFolioRequest, DefaultIdType>
{
    private readonly IRepository<Folio> _repository;
    private readonly IStringLocalizer _t;

    public DeleteFolioRequestHandler(IRepository<Folio> repository, IStringLocalizer<DeleteFolioRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<DefaultIdType> Handle(DeleteFolioRequest request, CancellationToken cancellationToken)
    {
        var folio = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = folio ?? throw new NotFoundException(_t["Folio {0} Not Found."]);

        // Add Domain Events to be raised after the commit
        folio.DomainEvents.Add(EntityDeletedEvent.WithEntity(folio));

        await _repository.DeleteAsync(folio, cancellationToken);

        return request.Id;
    }
}