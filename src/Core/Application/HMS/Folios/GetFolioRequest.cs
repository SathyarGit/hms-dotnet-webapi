namespace FSH.WebApi.Application.HMS.Folios;

public class GetFolioRequest : IRequest<FolioDetailsDto>
{
    public DefaultIdType Id { get; set; }

    public GetFolioRequest(DefaultIdType id) => Id = id;
}

public class GetFolioRequestHandler : IRequestHandler<GetFolioRequest, FolioDetailsDto>
{
    private readonly IRepository<Folio> _repository;
    private readonly IStringLocalizer _t;

    public GetFolioRequestHandler(IRepository<Folio> repository, IStringLocalizer<GetFolioRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<FolioDetailsDto> Handle(GetFolioRequest request, CancellationToken cancellationToken) =>
        await _repository.GetBySpecAsync(
            (ISpecification<Folio, FolioDetailsDto>)new FolioByIdWithBookingSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(_t["Folio {0} Not Found.", request.Id]);
}