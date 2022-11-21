using Mapster;

namespace FSH.WebApi.Application.HMS.Bookings;

public class GetBookingViaDapperRequest : IRequest<BookingDto>
{
    public DefaultIdType Id { get; set; }

    public GetBookingViaDapperRequest(DefaultIdType id) => Id = id;
}

public class GetBookingViaDapperRequestHandler : IRequestHandler<GetBookingViaDapperRequest, BookingDto>
{
    private readonly IDapperRepository _repository;
    private readonly IStringLocalizer _t;

    public GetBookingViaDapperRequestHandler(IDapperRepository repository, IStringLocalizer<GetBookingViaDapperRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<BookingDto> Handle(GetBookingViaDapperRequest request, CancellationToken cancellationToken)
    {
        var booking = await _repository.QueryFirstOrDefaultAsync<Booking>(
            $"SELECT * FROM HMS.\"Bookings\" WHERE \"Id\"  = '{request.Id}' AND \"TenantId\" = '@tenant'", cancellationToken: cancellationToken);

        _ = booking ?? throw new NotFoundException(_t["Booking {0} Not Found.", request.Id]);

        // Using mapster here throws a nullreference exception because of the "DepartmentName" property
        // in BookingDto and the booking not having a Department assigned.
        return new BookingDto
        {
            Id = booking.Id,
            CheckinDate = booking.CheckinDate,
            CheckoutDate = booking.CheckoutDate,
            NumberOfRooms = booking.NumberOfRooms,
            NumberOfAdults = booking.NumberOfAdults,
            NumberOfChildren = booking.NumberOfChildren,
            BookingstatusId = booking.BookingstatusId,
            Amount = booking.Amount,
            Notes = booking.Notes,
            BookingMaterialised = booking.BookingMaterialised,
            CustomerId = booking.CustomerId,
            TravelagentId = booking.TravelagentId,
            BookingstatusName = string.Empty,
            CustomerName = string.Empty,
            TravelagentName = string.Empty
        };
    }
}