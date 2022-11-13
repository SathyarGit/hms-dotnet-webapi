using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Bookingstatuses;

public class CreateBookingstatusRequest : IRequest<DefaultIdType>
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}

public class CreateBookingstatusRequestHandler : IRequestHandler<CreateBookingstatusRequest, DefaultIdType>
{
    private readonly IRepository<Bookingstatus> _repository;

    public CreateBookingstatusRequestHandler(IRepository<Bookingstatus> repository) =>
        _repository = repository;

    public async Task<DefaultIdType> Handle(CreateBookingstatusRequest request, CancellationToken cancellationToken)
    {
        var bookingstatus = new Bookingstatus(request.Name, request.Description);

        // Add Domain Events to be raised after the commit
        bookingstatus.DomainEvents.Add(EntityCreatedEvent.WithEntity(bookingstatus));

        await _repository.AddAsync(bookingstatus, cancellationToken);

        return bookingstatus.Id;
    }
}