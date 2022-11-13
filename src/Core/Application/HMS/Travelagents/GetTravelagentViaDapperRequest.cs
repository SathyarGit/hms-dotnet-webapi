using Mapster;

namespace FSH.WebApi.Application.HMS.Travelagents;

public class GetTravelagentViaDapperRequest : IRequest<TravelagentDto>
{
    public DefaultIdType Id { get; set; }

    public GetTravelagentViaDapperRequest(DefaultIdType id) => Id = id;
}

public class GetTravelagentViaDapperRequestHandler : IRequestHandler<GetTravelagentViaDapperRequest, TravelagentDto>
{
    private readonly IDapperRepository _repository;
    private readonly IStringLocalizer _t;

    public GetTravelagentViaDapperRequestHandler(IDapperRepository repository, IStringLocalizer<GetTravelagentViaDapperRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<TravelagentDto> Handle(GetTravelagentViaDapperRequest request, CancellationToken cancellationToken)
    {
        var travelagent = await _repository.QueryFirstOrDefaultAsync<Travelagent>(
            $"SELECT * FROM HMS.\"Travelagents\" WHERE \"Id\"  = '{request.Id}' AND \"TenantId\" = '@tenant'", cancellationToken: cancellationToken);

        _ = travelagent ?? throw new NotFoundException(_t["Travelagent {0} Not Found.", request.Id]);

        // Using mapster here throws a nullreference exception because of the "BrandName" property
        // in TravelagentDto and the travelagent not having a Brand assigned.
        return new TravelagentDto
        {
            Id = travelagent.Id,
            Name = travelagent.Name,
            AddressLine1 = travelagent.AddressLine1,
            AddressLine2 = travelagent.AddressLine2,
            City = travelagent.City,
            Country = travelagent.Country,
            Pincode = travelagent.Pincode,
            PhoneNumber = travelagent.PhoneNumber,
            Email = travelagent.Email,
            Notes = travelagent.Notes
        };
    }
}