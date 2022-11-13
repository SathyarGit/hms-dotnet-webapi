using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Bookingstatuses;

public class UpdateBookingstatusRequest : IRequest<DefaultIdType>
{
    public DefaultIdType Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}

public class UpdateBookingstatusRequestHandler : IRequestHandler<UpdateBookingstatusRequest, DefaultIdType>
{
    private readonly IRepository<Bookingstatus> _repository;
    private readonly IStringLocalizer _t;

    public UpdateBookingstatusRequestHandler(IRepository<Bookingstatus> repository, IStringLocalizer<UpdateBookingstatusRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<DefaultIdType> Handle(UpdateBookingstatusRequest request, CancellationToken cancellationToken)
    {
        var bookingstatus = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = bookingstatus ?? throw new NotFoundException(_t["Bookingstatus {0} Not Found.", request.Id]);

        var updatedBookingstatus = bookingstatus.Update(request.Name, request.Description);

        // Add Domain Events to be raised after the commit
        bookingstatus.DomainEvents.Add(EntityUpdatedEvent.WithEntity(bookingstatus));

        await _repository.UpdateAsync(updatedBookingstatus, cancellationToken);

        return request.Id;
    }
}