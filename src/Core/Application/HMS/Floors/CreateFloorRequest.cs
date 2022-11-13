using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Floors;

public class CreateFloorRequest : IRequest<DefaultIdType>
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}

public class CreateFloorRequestHandler : IRequestHandler<CreateFloorRequest, DefaultIdType>
{
    private readonly IRepository<Floor> _repository;

    public CreateFloorRequestHandler(IRepository<Floor> repository) =>
        _repository = repository;

    public async Task<DefaultIdType> Handle(CreateFloorRequest request, CancellationToken cancellationToken)
    {
        var floor = new Floor(request.Name, request.Description);

        // Add Domain Events to be raised after the commit
        floor.DomainEvents.Add(EntityCreatedEvent.WithEntity(floor));

        await _repository.AddAsync(floor, cancellationToken);

        return floor.Id;
    }
}