namespace FSH.WebApi.Application.HMS.Customerclassifications;

public class CustomerclassificationsBySearchRequestSpec : EntitiesByPaginationFilterSpec<Customerclassification, CustomerclassificationDto>
{
    public CustomerclassificationsBySearchRequestSpec(SearchCustomerclassificationsRequest request)
        : base(request) =>
        Query
            .OrderBy(c => c.Name, !request.HasOrderBy());
}