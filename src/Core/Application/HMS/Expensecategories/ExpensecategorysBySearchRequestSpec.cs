namespace FSH.WebApi.Application.HMS.Expensecategories;

public class ExpensecategoriesBySearchRequestSpec : EntitiesByPaginationFilterSpec<Expensecategory, ExpensecategoryDto>
{
    public ExpensecategoriesBySearchRequestSpec(SearchExpensecategoriesRequest request)
        : base(request) =>
        Query
            .OrderBy(c => c.Name, !request.HasOrderBy());
}