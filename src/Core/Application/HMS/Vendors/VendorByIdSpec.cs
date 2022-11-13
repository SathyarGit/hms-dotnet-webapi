namespace FSH.WebApi.Application.HMS.Vendors;

public class VendorByIdSpec : Specification<Vendor, VendorDto>, ISingleResultSpecification
{
    public VendorByIdSpec(DefaultIdType id) =>
        Query
            .Where(p => p.Id == id);
}