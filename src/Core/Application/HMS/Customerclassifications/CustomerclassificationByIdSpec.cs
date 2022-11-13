namespace FSH.WebApi.Application.HMS.Customerclassifications;

public class CustomerclassificationByIdSpec : Specification<Customerclassification, CustomerclassificationDto>, ISingleResultSpecification
{
    public CustomerclassificationByIdSpec(DefaultIdType id) =>
        Query
            .Where(p => p.Id == id);
}