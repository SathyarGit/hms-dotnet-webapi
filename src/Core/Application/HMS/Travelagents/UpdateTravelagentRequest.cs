using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Travelagents;

public class UpdateTravelagentRequest : IRequest<DefaultIdType>
{
    public DefaultIdType Id { get; set; }
    public string Name { get; set; } = default!;
    public string? AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
    public string? Pincode { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? Notes { get; set; }

}

public class UpdateTravelagentRequestHandler : IRequestHandler<UpdateTravelagentRequest, DefaultIdType>
{
    private readonly IRepository<Travelagent> _repository;
    private readonly IStringLocalizer _t;
    private readonly IFileStorageService _file;

    public UpdateTravelagentRequestHandler(IRepository<Travelagent> repository, IStringLocalizer<UpdateTravelagentRequestHandler> localizer, IFileStorageService file) =>
        (_repository, _t, _file) = (repository, localizer, file);

    public async Task<DefaultIdType> Handle(UpdateTravelagentRequest request, CancellationToken cancellationToken)
    {
        var travelagent = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = travelagent ?? throw new NotFoundException(_t["Travelagent {0} Not Found.", request.Id]);

        var updatedTravelagent = travelagent.Update(
                                                request.Name,
                                                request.AddressLine1,
                                                request.AddressLine2,
                                                request.City,
                                                request.Country,
                                                request.Pincode,
                                                request.PhoneNumber,
                                                request.Email,
                                                request.Notes);

        // Add Domain Events to be raised after the commit
        travelagent.DomainEvents.Add(EntityUpdatedEvent.WithEntity(travelagent));

        await _repository.UpdateAsync(updatedTravelagent, cancellationToken);

        return request.Id;
    }
}