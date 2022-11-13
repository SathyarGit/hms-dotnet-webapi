namespace FSH.WebApi.Application.HMS.Customerclassifications;

public class CustomerclassificationByNameSpec : Specification<Customerclassification>, ISingleResultSpecification
{
    public CustomerclassificationByNameSpec(string name) =>
        Query.Where(p => p.Name == name);
}