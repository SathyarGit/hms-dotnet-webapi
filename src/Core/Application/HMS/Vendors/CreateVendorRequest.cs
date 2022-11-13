using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Vendors;

public class CreateVendorRequest : IRequest<DefaultIdType>
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public string? Notes { get; set; }
}

public class CreateVendorRequestHandler : IRequestHandler<CreateVendorRequest, DefaultIdType>
{
    private readonly IRepository<Vendor> _repository;

    public CreateVendorRequestHandler(IRepository<Vendor> repository) =>
        _repository = repository;

    public async Task<DefaultIdType> Handle(CreateVendorRequest request, CancellationToken cancellationToken)
    {
        var vendor = new Vendor(request.Name, request.Description, request.Notes);

        // Add Domain Events to be raised after the commit
        vendor.DomainEvents.Add(EntityCreatedEvent.WithEntity(vendor));

        await _repository.AddAsync(vendor, cancellationToken);

        return vendor.Id;
    }
}