namespace FSH.WebApi.Application.HMS.Foliotypes;

public class GetFoliotypeRequest : IRequest<FoliotypeDto>
{
    public DefaultIdType Id { get; set; }

    public GetFoliotypeRequest(DefaultIdType id) => Id = id;
}

public class GetFoliotypeRequestHandler : IRequestHandler<GetFoliotypeRequest, FoliotypeDto>
{
    private readonly IRepository<Foliotype> _repository;
    private readonly IStringLocalizer _t;

    public GetFoliotypeRequestHandler(IRepository<Foliotype> repository, IStringLocalizer<GetFoliotypeRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<FoliotypeDto> Handle(GetFoliotypeRequest request, CancellationToken cancellationToken) =>
        await _repository.GetBySpecAsync(
            (ISpecification<Foliotype, FoliotypeDto>)new FoliotypeByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(_t["Foliotype {0} Not Found.", request.Id]);
}