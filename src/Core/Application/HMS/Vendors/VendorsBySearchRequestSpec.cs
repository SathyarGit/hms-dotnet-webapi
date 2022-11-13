namespace FSH.WebApi.Application.HMS.Vendors;

public class VendorsBySearchRequestSpec : EntitiesByPaginationFilterSpec<Vendor, VendorDto>
{
    public VendorsBySearchRequestSpec(SearchVendorsRequest request)
        : base(request) =>
        Query
            .OrderBy(c => c.Name, !request.HasOrderBy());
}