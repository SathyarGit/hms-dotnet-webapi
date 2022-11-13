using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Paymentmodes;

public class CreatePaymentmodeRequest : IRequest<DefaultIdType>
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}

public class CreatePaymentmodeRequestHandler : IRequestHandler<CreatePaymentmodeRequest, DefaultIdType>
{
    private readonly IRepository<Paymentmode> _repository;

    public CreatePaymentmodeRequestHandler(IRepository<Paymentmode> repository) =>
        _repository = repository;

    public async Task<DefaultIdType> Handle(CreatePaymentmodeRequest request, CancellationToken cancellationToken)
    {
        var paymentmode = new Paymentmode(request.Name, request.Description);

        // Add Domain Events to be raised after the commit
        paymentmode.DomainEvents.Add(EntityCreatedEvent.WithEntity(paymentmode));

        await _repository.AddAsync(paymentmode, cancellationToken);

        return paymentmode.Id;
    }
}