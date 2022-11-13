using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Roomstatuses;

public class CreateRoomstatusRequest : IRequest<DefaultIdType>
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}

public class CreateRoomstatusRequestHandler : IRequestHandler<CreateRoomstatusRequest, DefaultIdType>
{
    private readonly IRepository<Roomstatus> _repository;

    public CreateRoomstatusRequestHandler(IRepository<Roomstatus> repository) =>
        _repository = repository;

    public async Task<DefaultIdType> Handle(CreateRoomstatusRequest request, CancellationToken cancellationToken)
    {
        var roomstatus = new Roomstatus(request.Name, request.Description);

        // Add Domain Events to be raised after the commit
        roomstatus.DomainEvents.Add(EntityCreatedEvent.WithEntity(roomstatus));

        await _repository.AddAsync(roomstatus, cancellationToken);

        return roomstatus.Id;
    }
}