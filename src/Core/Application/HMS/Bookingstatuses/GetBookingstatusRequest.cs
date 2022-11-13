namespace FSH.WebApi.Application.HMS.Bookingstatuses;

public class GetBookingstatusRequest : IRequest<BookingstatusDto>
{
    public DefaultIdType Id { get; set; }

    public GetBookingstatusRequest(DefaultIdType id) => Id = id;
}

public class GetBookingstatusRequestHandler : IRequestHandler<GetBookingstatusRequest, BookingstatusDto>
{
    private readonly IRepository<Bookingstatus> _repository;
    private readonly IStringLocalizer _t;

    public GetBookingstatusRequestHandler(IRepository<Bookingstatus> repository, IStringLocalizer<GetBookingstatusRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<BookingstatusDto> Handle(GetBookingstatusRequest request, CancellationToken cancellationToken) =>
        await _repository.GetBySpecAsync(
            (ISpecification<Bookingstatus, BookingstatusDto>)new BookingstatusByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(_t["Bookingstatus {0} Not Found.", request.Id]);
}