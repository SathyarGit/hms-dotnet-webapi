using Mapster;

namespace FSH.WebApi.Application.HMS.Vendors;

public class GetVendorViaDapperRequest : IRequest<VendorDto>
{
    public DefaultIdType Id { get; set; }

    public GetVendorViaDapperRequest(DefaultIdType id) => Id = id;
}

public class GetVendorViaDapperRequestHandler : IRequestHandler<GetVendorViaDapperRequest, VendorDto>
{
    private readonly IDapperRepository _repository;
    private readonly IStringLocalizer _t;

    public GetVendorViaDapperRequestHandler(IDapperRepository repository, IStringLocalizer<GetVendorViaDapperRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<VendorDto> Handle(GetVendorViaDapperRequest request, CancellationToken cancellationToken)
    {
        var vendor = await _repository.QueryFirstOrDefaultAsync<Vendor>(
            $"SELECT * FROM HMS.\"Vendors\" WHERE \"Id\"  = '{request.Id}' AND \"TenantId\" = '@tenant'", cancellationToken: cancellationToken);

        _ = vendor ?? throw new NotFoundException(_t["Vendor {0} Not Found.", request.Id]);

        // Using mapster here throws a nullreference exception because of the "BrandName" property
        // in VendorDto and the vendor not having a Brand assigned.
        return new VendorDto
        {
            Id = vendor.Id,
            Description = vendor.Description,
            Name = vendor.Name,
            Notes = vendor.Notes
        };
    }
}