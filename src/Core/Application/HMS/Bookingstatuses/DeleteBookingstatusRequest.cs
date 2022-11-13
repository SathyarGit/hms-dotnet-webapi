using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Bookingstatuses;

public class DeleteBookingstatusRequest : IRequest<DefaultIdType>
{
    public DefaultIdType Id { get; set; }

    public DeleteBookingstatusRequest(DefaultIdType id) => Id = id;
}

public class DeleteBookingstatusRequestHandler : IRequestHandler<DeleteBookingstatusRequest, DefaultIdType>
{
    private readonly IRepository<Bookingstatus> _repository;
    private readonly IStringLocalizer _t;

    public DeleteBookingstatusRequestHandler(IRepository<Bookingstatus> repository, IStringLocalizer<DeleteBookingstatusRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<DefaultIdType> Handle(DeleteBookingstatusRequest request, CancellationToken cancellationToken)
    {
        var bookingstatus = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = bookingstatus ?? throw new NotFoundException(_t["Bookingstatus {0} Not Found."]);

        // Add Domain Events to be raised after the commit
        bookingstatus.DomainEvents.Add(EntityDeletedEvent.WithEntity(bookingstatus));

        await _repository.DeleteAsync(bookingstatus, cancellationToken);

        return request.Id;
    }
}