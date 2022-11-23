using Mapster;

namespace FSH.WebApi.Application.HMS.Customers;

public class GetCustomerViaDapperRequest : IRequest<CustomerDto>
{
    public DefaultIdType Id { get; set; }

    public GetCustomerViaDapperRequest(DefaultIdType id) => Id = id;
}

public class GetCustomerViaDapperRequestHandler : IRequestHandler<GetCustomerViaDapperRequest, CustomerDto>
{
    private readonly IDapperRepository _repository;
    private readonly IStringLocalizer _t;

    public GetCustomerViaDapperRequestHandler(IDapperRepository repository, IStringLocalizer<GetCustomerViaDapperRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<CustomerDto> Handle(GetCustomerViaDapperRequest request, CancellationToken cancellationToken)
    {
        var customer = await _repository.QueryFirstOrDefaultAsync<Customer>(
            $"SELECT * FROM HMS.\"Customers\" WHERE \"Id\"  = '{request.Id}' AND \"TenantId\" = '@tenant'", cancellationToken: cancellationToken);

        _ = customer ?? throw new NotFoundException(_t["Customer {0} Not Found.", request.Id]);

        // Using mapster here throws a nullreference exception because of the "DepartmentName" property
        // in CustomerDto and the customer not having a Department assigned.
        return new CustomerDto
        {
            Id = customer.Id,
            Name = customer.Name,
            AddressLine1 = customer.AddressLine1,
            AddressLine2 = customer.AddressLine2,
            City = customer.City,
            Country = customer.Country,
            Pincode = customer.Pincode,
            PhoneNumber = customer.PhoneNumber,
            Email = customer.Email,
            Notes = customer.Notes,
            ImagePath = customer.ImagePath,
            CustomerclassificationId = customer.CustomerclassificationId,
            CustomerclassificationName = string.Empty
        };
    }
}