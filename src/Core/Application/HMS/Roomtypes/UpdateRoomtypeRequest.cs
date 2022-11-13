using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Roomtypes;

public class UpdateRoomtypeRequest : IRequest<DefaultIdType>
{
    public DefaultIdType Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}

public class UpdateRoomtypeRequestHandler : IRequestHandler<UpdateRoomtypeRequest, DefaultIdType>
{
    private readonly IRepository<Roomtype> _repository;
    private readonly IStringLocalizer _t;

    public UpdateRoomtypeRequestHandler(IRepository<Roomtype> repository, IStringLocalizer<UpdateRoomtypeRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<DefaultIdType> Handle(UpdateRoomtypeRequest request, CancellationToken cancellationToken)
    {
        var roomtype = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = roomtype ?? throw new NotFoundException(_t["Roomtype {0} Not Found.", request.Id]);

        var updatedRoomtype = roomtype.Update(request.Name, request.Description);

        // Add Domain Events to be raised after the commit
        roomtype.DomainEvents.Add(EntityUpdatedEvent.WithEntity(roomtype));

        await _repository.UpdateAsync(updatedRoomtype, cancellationToken);

        return request.Id;
    }
}