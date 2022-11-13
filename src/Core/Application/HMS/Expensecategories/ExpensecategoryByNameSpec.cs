namespace FSH.WebApi.Application.HMS.Expensecategories;

public class ExpensecategoryByNameSpec : Specification<Expensecategory>, ISingleResultSpecification
{
    public ExpensecategoryByNameSpec(string name) =>
        Query.Where(p => p.Name == name);
}