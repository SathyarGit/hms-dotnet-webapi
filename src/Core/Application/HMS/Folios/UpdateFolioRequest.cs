using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Folios;

public class UpdateFolioRequest : IRequest<DefaultIdType>
{
    public DefaultIdType Id { get; set; }
    public DefaultIdType BookingId { get; set; }
    public DefaultIdType FoliotypeId { get; set; }
    public string? Description { get; set; }
}

public class UpdateFolioRequestHandler : IRequestHandler<UpdateFolioRequest, DefaultIdType>
{
    public readonly IRepository<Folio> _repository;
    public readonly IStringLocalizer _t;
    public readonly IFileStorageService _file;

    public UpdateFolioRequestHandler(IRepository<Folio> repository, IStringLocalizer<UpdateFolioRequestHandler> localizer, IFileStorageService file) =>
        (_repository, _t, _file) = (repository, localizer, file);

    public async Task<DefaultIdType> Handle(UpdateFolioRequest request, CancellationToken cancellationToken)
    {
        var folio = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = folio ?? throw new NotFoundException(_t["Folio {0} Not Found.", request.Id]);

        var updatedFolio = folio.Update(request.BookingId, request.FoliotypeId, request.Description);

        // Add Domain Events to be raised after the commit
        folio.DomainEvents.Add(EntityUpdatedEvent.WithEntity(folio));

        await _repository.UpdateAsync(updatedFolio, cancellationToken);

        return request.Id;
    }
}