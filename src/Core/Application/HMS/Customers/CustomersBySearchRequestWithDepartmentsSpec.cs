namespace FSH.WebApi.Application.HMS.Customers;

public class CustomersBySearchRequestWithCustomerclassificationsSpec : EntitiesByPaginationFilterSpec<Customer, CustomerDto>
{
    public CustomersBySearchRequestWithCustomerclassificationsSpec(SearchCustomersRequest request)
        : base(request) =>
        Query
            .Include(p => p.Customerclassification)
            .OrderBy(c => c.Name, !request.HasOrderBy())
            .Where(p => p.CustomerclassificationId.Equals(request.CustomerclassificationId!.Value), request.CustomerclassificationId.HasValue);
}