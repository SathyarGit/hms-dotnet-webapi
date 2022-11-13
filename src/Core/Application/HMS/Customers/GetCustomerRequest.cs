namespace FSH.WebApi.Application.HMS.Customers;

public class GetCustomerRequest : IRequest<CustomerDetailsDto>
{
    public DefaultIdType Id { get; set; }

    public GetCustomerRequest(DefaultIdType id) => Id = id;
}

public class GetCustomerRequestHandler : IRequestHandler<GetCustomerRequest, CustomerDetailsDto>
{
    private readonly IRepository<Customer> _repository;
    private readonly IStringLocalizer _t;

    public GetCustomerRequestHandler(IRepository<Customer> repository, IStringLocalizer<GetCustomerRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<CustomerDetailsDto> Handle(GetCustomerRequest request, CancellationToken cancellationToken) =>
        await _repository.GetBySpecAsync(
            (ISpecification<Customer, CustomerDetailsDto>)new CustomerByIdWithCustomerclassificationSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(_t["Customer {0} Not Found.", request.Id]);
}