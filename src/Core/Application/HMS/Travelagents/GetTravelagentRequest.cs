namespace FSH.WebApi.Application.HMS.Travelagents;

public class GetTravelagentRequest : IRequest<TravelagentDto>
{
    public DefaultIdType Id { get; set; }

    public GetTravelagentRequest(DefaultIdType id) => Id = id;
}

public class GetTravelagentRequestHandler : IRequestHandler<GetTravelagentRequest, TravelagentDto>
{
    private readonly IRepository<Travelagent> _repository;
    private readonly IStringLocalizer _t;

    public GetTravelagentRequestHandler(IRepository<Travelagent> repository, IStringLocalizer<GetTravelagentRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<TravelagentDto> Handle(GetTravelagentRequest request, CancellationToken cancellationToken) =>
        await _repository.GetBySpecAsync(
            (ISpecification<Travelagent, TravelagentDto>)new TravelagentByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(_t["Travelagent {0} Not Found.", request.Id]);
}