namespace FSH.WebApi.Application.HMS.Expensecategories;

public class ExpensecategoryByIdSpec : Specification<Expensecategory, ExpensecategoryDto>, ISingleResultSpecification
{
    public ExpensecategoryByIdSpec(DefaultIdType id) =>
        Query
            .Where(p => p.Id == id);
}