namespace FSH.WebApi.Application.HMS.Customers;

public class CustomerByNameSpec : Specification<Customer>, ISingleResultSpecification
{
    public CustomerByNameSpec(string name) =>
        Query.Where(p => p.Name == name);
}