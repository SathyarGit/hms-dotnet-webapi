using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Bookings;

public class CreateBookingRequest : IRequest<DefaultIdType>
{
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

public class CreateBookingRequestHandler : IRequestHandler<CreateBookingRequest, DefaultIdType>
{
    private readonly IRepository<Booking> _repository;
    private readonly IFileStorageService _file;

    public CreateBookingRequestHandler(IRepository<Booking> repository, IFileStorageService file) =>
        (_repository, _file) = (repository, file);

    public async Task<DefaultIdType> Handle(CreateBookingRequest request, CancellationToken cancellationToken)
    {
        // var booking = new Booking(request.CheckinDate, request.CheckoutDate, request.NumberOfRooms, request.NumberOfAdults, request.NumberOfChildren, request.BookingstatusId, request.Amount, request.Notes, request.BookingMaterialised, request.CustomerId, request.TravelagentId, request.FolioId);
        var booking = new Booking(request.CheckinDate, request.CheckoutDate, request.NumberOfRooms, request.NumberOfAdults, request.NumberOfChildren, request.BookingstatusId, request.Amount, request.Notes, request.BookingMaterialised, request.CustomerId, request.TravelagentId);

        // Add Domain Events to be raised after the commit
        booking.DomainEvents.Add(EntityCreatedEvent.WithEntity(booking));

        await _repository.AddAsync(booking, cancellationToken);

        return booking.Id;
    }
}