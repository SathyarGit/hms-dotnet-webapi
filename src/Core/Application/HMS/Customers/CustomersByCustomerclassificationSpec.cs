namespace FSH.WebApi.Application.HMS.Customers;

public class CustomersByCustomerclassificationSpec : Specification<Customer>
{
    public CustomersByCustomerclassificationSpec(DefaultIdType customerclassificationId) =>
        Query.Where(p => p.CustomerclassificationId == customerclassificationId);
}
