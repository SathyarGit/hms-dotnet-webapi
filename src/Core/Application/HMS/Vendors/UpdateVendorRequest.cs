using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Vendors;

public class UpdateVendorRequest : IRequest<DefaultIdType>
{
    public DefaultIdType Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public string? Notes { get; set; }
}

public class UpdateVendorRequestHandler : IRequestHandler<UpdateVendorRequest, DefaultIdType>
{
    private readonly IRepository<Vendor> _repository;
    private readonly IStringLocalizer _t;

    public UpdateVendorRequestHandler(IRepository<Vendor> repository, IStringLocalizer<UpdateVendorRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<DefaultIdType> Handle(UpdateVendorRequest request, CancellationToken cancellationToken)
    {
        var vendor = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = vendor ?? throw new NotFoundException(_t["Vendor {0} Not Found.", request.Id]);

        var updatedVendor = vendor.Update(request.Name, request.Description, request.Notes);

        // Add Domain Events to be raised after the commit
        vendor.DomainEvents.Add(EntityUpdatedEvent.WithEntity(vendor));

        await _repository.UpdateAsync(updatedVendor, cancellationToken);

        return request.Id;
    }
}