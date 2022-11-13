using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Roomtypes;

public class CreateRoomtypeRequest : IRequest<DefaultIdType>
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}

public class CreateRoomtypeRequestHandler : IRequestHandler<CreateRoomtypeRequest, DefaultIdType>
{
    private readonly IRepository<Roomtype> _repository;

    public CreateRoomtypeRequestHandler(IRepository<Roomtype> repository) =>
        _repository = repository;

    public async Task<DefaultIdType> Handle(CreateRoomtypeRequest request, CancellationToken cancellationToken)
    {
        var roomtype = new Roomtype(request.Name, request.Description);

        // Add Domain Events to be raised after the commit
        roomtype.DomainEvents.Add(EntityCreatedEvent.WithEntity(roomtype));

        await _repository.AddAsync(roomtype, cancellationToken);

        return roomtype.Id;
    }
}