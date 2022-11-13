namespace FSH.WebApi.Application.HMS.Vendors;

public class GetVendorRequest : IRequest<VendorDto>
{
    public DefaultIdType Id { get; set; }

    public GetVendorRequest(DefaultIdType id) => Id = id;
}

public class GetVendorRequestHandler : IRequestHandler<GetVendorRequest, VendorDto>
{
    private readonly IRepository<Vendor> _repository;
    private readonly IStringLocalizer _t;

    public GetVendorRequestHandler(IRepository<Vendor> repository, IStringLocalizer<GetVendorRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<VendorDto> Handle(GetVendorRequest request, CancellationToken cancellationToken) =>
        await _repository.GetBySpecAsync(
            (ISpecification<Vendor, VendorDto>)new VendorByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(_t["Vendor {0} Not Found.", request.Id]);
}