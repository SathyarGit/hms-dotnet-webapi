using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Travelagents;

public class CreateTravelagentRequest : IRequest<DefaultIdType>
{
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

public class CreateTravelagentRequestHandler : IRequestHandler<CreateTravelagentRequest, DefaultIdType>
{
    private readonly IRepository<Travelagent> _repository;
    private readonly IFileStorageService _file;

    public CreateTravelagentRequestHandler(IRepository<Travelagent> repository, IFileStorageService file) =>
        (_repository, _file) = (repository, file);

    public async Task<DefaultIdType> Handle(CreateTravelagentRequest request, CancellationToken cancellationToken)
    {
        var travelagent = new Travelagent(
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
        travelagent.DomainEvents.Add(EntityCreatedEvent.WithEntity(travelagent));

        await _repository.AddAsync(travelagent, cancellationToken);

        return travelagent.Id;
    }
}