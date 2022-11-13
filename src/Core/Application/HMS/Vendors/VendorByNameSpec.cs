namespace FSH.WebApi.Application.HMS.Vendors;

public class VendorByNameSpec : Specification<Vendor>, ISingleResultSpecification
{
    public VendorByNameSpec(string name) =>
        Query.Where(p => p.Name == name);
}