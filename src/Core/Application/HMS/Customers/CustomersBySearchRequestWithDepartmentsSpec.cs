namespace FSH.WebApi.Application.HMS.Customers;

public class CustomersBySearchRequestWithCustomerclassificationsSpec : EntitiesByPaginationFilterSpec<Customer, CustomerDto>
{
    public CustomersBySearchRequestWithCustomerclassificationsSpec(SearchCustomersRequest request)
        : base(request) =>
        Query
            .Include(p => p.Customerclassification)
            .OrderBy(c => c.Name, !request.HasOrderBy())
            .Where(p => p.CustclassificationId.Equals(request.CustclassificationId!.Value), request.CustclassificationId.HasValue);
}