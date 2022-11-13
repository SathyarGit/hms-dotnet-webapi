using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Bookings;

public class UpdateBookingRequest : IRequest<DefaultIdType>
{
    public DefaultIdType Id { get; set; }
    public DateTime? CheckinDate { get; set; }
    public DateTime? CheckoutDate { get; set; }
    public int? NumberOfRooms { get; set; }
    public int? NumberOfAdults { get; set; }
    public int? NumberOfChildren { get; set; }
    public DefaultIdType BookingstatusId { get; set; }
    public int? Amount { get; set; }
    public string? Notes { get; set; }
    public bool? BookingMaterialised { get; set; }
    public DefaultIdType CustomerId { get; set; }
    public DefaultIdType TravelagentId { get; set; }
    public DefaultIdType FolioId { get; set; }
}

public class UpdateBookingRequestHandler : IRequestHandler<UpdateBookingRequest, DefaultIdType>
{
    public readonly IRepository<Booking> _repository;
    public readonly IStringLocalizer _t;
    public readonly IFileStorageService _file;

    public UpdateBookingRequestHandler(IRepository<Booking> repository, IStringLocalizer<UpdateBookingRequestHandler> localizer, IFileStorageService file) =>
        (_repository, _t, _file) = (repository, localizer, file);

    public async Task<DefaultIdType> Handle(UpdateBookingRequest request, CancellationToken cancellationToken)
    {
        var booking = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = booking ?? throw new NotFoundException(_t["Booking {0} Not Found.", request.Id]);

        // var updatedBooking = booking.Update(request.CheckinDate, request.CheckoutDate, request.NumberOfRooms, request.NumberOfAdults, request.NumberOfChildren, request.BookingstatusId, request.Amount, request.Notes, request.BookingMaterialised, request.CustomerId, request.TravelagentId, request.FolioId);
        var updatedBooking = booking.Update(request.CheckinDate, request.CheckoutDate, request.NumberOfRooms, request.NumberOfAdults, request.NumberOfChildren, request.BookingstatusId, request.Amount, request.Notes, request.BookingMaterialised, request.CustomerId, request.TravelagentId);

        // Add Domain Events to be raised after the commit
        booking.DomainEvents.Add(EntityUpdatedEvent.WithEntity(booking));

        await _repository.UpdateAsync(updatedBooking, cancellationToken);

        return request.Id;
    }
}