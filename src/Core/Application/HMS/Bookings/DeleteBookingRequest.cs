using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Bookings;

public class DeleteBookingRequest : IRequest<DefaultIdType>
{
    public DefaultIdType Id { get; set; }

    public DeleteBookingRequest(DefaultIdType id) => Id = id;
}

public class DeleteBookingRequestHandler : IRequestHandler<DeleteBookingRequest, DefaultIdType>
{
    private readonly IRepository<Booking> _repository;
    private readonly IStringLocalizer _t;

    public DeleteBookingRequestHandler(IRepository<Booking> repository, IStringLocalizer<DeleteBookingRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<DefaultIdType> Handle(DeleteBookingRequest request, CancellationToken cancellationToken)
    {
        var booking = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = booking ?? throw new NotFoundException(_t["Booking {0} Not Found."]);

        // Add Domain Events to be raised after the commit
        booking.DomainEvents.Add(EntityDeletedEvent.WithEntity(booking));

        await _repository.DeleteAsync(booking, cancellationToken);

        return request.Id;
    }
}