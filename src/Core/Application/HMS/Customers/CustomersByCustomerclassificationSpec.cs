namespace FSH.WebApi.Application.HMS.Customers;

public class CustomersByCustomerclassificationSpec : Specification<Customer>
{
    public CustomersByCustomerclassificationSpec(DefaultIdType custclassificationId) =>
        Query.Where(p => p.CustclassificationId == custclassificationId);
}
