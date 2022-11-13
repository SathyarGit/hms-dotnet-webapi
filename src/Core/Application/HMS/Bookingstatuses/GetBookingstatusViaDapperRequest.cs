using Mapster;

namespace FSH.WebApi.Application.HMS.Bookingstatuses;

public class GetBookingstatusViaDapperRequest : IRequest<BookingstatusDto>
{
    public DefaultIdType Id { get; set; }

    public GetBookingstatusViaDapperRequest(DefaultIdType id) => Id = id;
}

public class GetBookingstatusViaDapperRequestHandler : IRequestHandler<GetBookingstatusViaDapperRequest, BookingstatusDto>
{
    private readonly IDapperRepository _repository;
    private readonly IStringLocalizer _t;

    public GetBookingstatusViaDapperRequestHandler(IDapperRepository repository, IStringLocalizer<GetBookingstatusViaDapperRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<BookingstatusDto> Handle(GetBookingstatusViaDapperRequest request, CancellationToken cancellationToken)
    {
        var bookingstatus = await _repository.QueryFirstOrDefaultAsync<Bookingstatus>(
            $"SELECT * FROM HMS.\"Bookingstatuses\" WHERE \"Id\"  = '{request.Id}' AND \"TenantId\" = '@tenant'", cancellationToken: cancellationToken);

        _ = bookingstatus ?? throw new NotFoundException(_t["Bookingstatus {0} Not Found.", request.Id]);

        return new BookingstatusDto
        {
            Id = bookingstatus.Id,
            Description = bookingstatus.Description,
            Name = bookingstatus.Name
        };
    }
}