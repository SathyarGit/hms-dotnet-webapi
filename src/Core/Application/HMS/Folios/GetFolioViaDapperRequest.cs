using Mapster;

namespace FSH.WebApi.Application.HMS.Folios;

public class GetFolioViaDapperRequest : IRequest<FolioDto>
{
    public DefaultIdType Id { get; set; }

    public GetFolioViaDapperRequest(DefaultIdType id) => Id = id;
}

public class GetFolioViaDapperRequestHandler : IRequestHandler<GetFolioViaDapperRequest, FolioDto>
{
    private readonly IDapperRepository _repository;
    private readonly IStringLocalizer _t;

    public GetFolioViaDapperRequestHandler(IDapperRepository repository, IStringLocalizer<GetFolioViaDapperRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<FolioDto> Handle(GetFolioViaDapperRequest request, CancellationToken cancellationToken)
    {
        var folio = await _repository.QueryFirstOrDefaultAsync<Folio>(
            $"SELECT * FROM HMS.\"Folios\" WHERE \"Id\"  = '{request.Id}' AND \"TenantId\" = '@tenant'", cancellationToken: cancellationToken);

        _ = folio ?? throw new NotFoundException(_t["Folio {0} Not Found.", request.Id]);

        // Using mapster here throws a nullreference exception because of the "DepartmentName" property
        // in FolioDto and the folio not having a Department assigned.
        return new FolioDto
        {
            Id = folio.Id,
            BookingId = folio.BookingId,
            FoliotypeId = folio.FoliotypeId,
            Description = folio.Description,
            FoliotypeName = string.Empty
        };
    }
}