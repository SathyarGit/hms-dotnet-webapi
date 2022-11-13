using Mapster;

namespace FSH.WebApi.Application.HMS.Foliotypes;

public class GetFoliotypeViaDapperRequest : IRequest<FoliotypeDto>
{
    public DefaultIdType Id { get; set; }

    public GetFoliotypeViaDapperRequest(DefaultIdType id) => Id = id;
}

public class GetFoliotypeViaDapperRequestHandler : IRequestHandler<GetFoliotypeViaDapperRequest, FoliotypeDto>
{
    private readonly IDapperRepository _repository;
    private readonly IStringLocalizer _t;

    public GetFoliotypeViaDapperRequestHandler(IDapperRepository repository, IStringLocalizer<GetFoliotypeViaDapperRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<FoliotypeDto> Handle(GetFoliotypeViaDapperRequest request, CancellationToken cancellationToken)
    {
        var foliotype = await _repository.QueryFirstOrDefaultAsync<Foliotype>(
            $"SELECT * FROM HMS.\"Foliotypes\" WHERE \"Id\"  = '{request.Id}' AND \"TenantId\" = '@tenant'", cancellationToken: cancellationToken);

        _ = foliotype ?? throw new NotFoundException(_t["Foliotype {0} Not Found.", request.Id]);

        // Using mapster here throws a nullreference exception because of the "BrandName" property
        // in FoliotypeDto and the foliotype not having a Brand assigned.
        return new FoliotypeDto
        {
            Id = foliotype.Id,
            Description = foliotype.Description,
            Name = foliotype.Name
        };
    }
}