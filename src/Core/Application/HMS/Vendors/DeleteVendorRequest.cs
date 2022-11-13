using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Vendors;

public class DeleteVendorRequest : IRequest<DefaultIdType>
{
    public DefaultIdType Id { get; set; }

    public DeleteVendorRequest(DefaultIdType id) => Id = id;
}

public class DeleteVendorRequestHandler : IRequestHandler<DeleteVendorRequest, DefaultIdType>
{
    private readonly IRepository<Vendor> _repository;
    private readonly IStringLocalizer _t;

    public DeleteVendorRequestHandler(IRepository<Vendor> repository, IStringLocalizer<DeleteVendorRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<DefaultIdType> Handle(DeleteVendorRequest request, CancellationToken cancellationToken)
    {
        var vendor = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = vendor ?? throw new NotFoundException(_t["Vendor {0} Not Found."]);

        // Add Domain Events to be raised after the commit
        vendor.DomainEvents.Add(EntityDeletedEvent.WithEntity(vendor));

        await _repository.DeleteAsync(vendor, cancellationToken);

        return request.Id;
    }
}