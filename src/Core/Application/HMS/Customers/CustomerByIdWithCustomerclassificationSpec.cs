namespace FSH.WebApi.Application.HMS.Customers;

public class CustomerByIdWithCustomerclassificationSpec : Specification<Customer, CustomerDetailsDto>, ISingleResultSpecification
{
    public CustomerByIdWithCustomerclassificationSpec(DefaultIdType id) =>
        Query
            .Where(p => p.Id == id)
            .Include(p => p.Customerclassification);
}