namespace FSH.WebApi.Application.HMS.Bookings;

public class GetBookingRequest : IRequest<BookingDetailsDto>
{
    public DefaultIdType Id { get; set; }

    public GetBookingRequest(DefaultIdType id) => Id = id;
}

public class GetBookingRequestHandler : IRequestHandler<GetBookingRequest, BookingDetailsDto>
{
    private readonly IRepository<Booking> _repository;
    private readonly IStringLocalizer _t;

    public GetBookingRequestHandler(IRepository<Booking> repository, IStringLocalizer<GetBookingRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<BookingDetailsDto> Handle(GetBookingRequest request, CancellationToken cancellationToken) =>
        await _repository.GetBySpecAsync(
            (ISpecification<Booking, BookingDetailsDto>)new BookingByIdWithCustomerSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(_t["Booking {0} Not Found.", request.Id]);
}