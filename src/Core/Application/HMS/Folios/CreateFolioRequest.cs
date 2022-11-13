using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Folios;

public class CreateFolioRequest : IRequest<DefaultIdType>
{
    public DefaultIdType BookingId { get; set; }
    public DefaultIdType FoliotypeId { get; set; }
    public string? Description { get; set; }
}

public class CreateFolioRequestHandler : IRequestHandler<CreateFolioRequest, DefaultIdType>
{
    private readonly IRepository<Folio> _repository;
    private readonly IFileStorageService _file;

    public CreateFolioRequestHandler(IRepository<Folio> repository, IFileStorageService file) =>
        (_repository, _file) = (repository, file);

    public async Task<DefaultIdType> Handle(CreateFolioRequest request, CancellationToken cancellationToken)
    {
        var folio = new Folio(request.BookingId, request.FoliotypeId, request.Description);

        // Add Domain Events to be raised after the commit
        folio.DomainEvents.Add(EntityCreatedEvent.WithEntity(folio));

        await _repository.AddAsync(folio, cancellationToken);

        return folio.Id;
    }
}