namespace FSH.WebApi.Application.HMS.Customerclassifications;

public class GetCustomerclassificationRequest : IRequest<CustomerclassificationDto>
{
    public DefaultIdType Id { get; set; }

    public GetCustomerclassificationRequest(DefaultIdType id) => Id = id;
}

public class GetCustomerclassificationRequestHandler : IRequestHandler<GetCustomerclassificationRequest, CustomerclassificationDto>
{
    private readonly IRepository<Customerclassification> _repository;
    private readonly IStringLocalizer _t;

    public GetCustomerclassificationRequestHandler(IRepository<Customerclassification> repository, IStringLocalizer<GetCustomerclassificationRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<CustomerclassificationDto> Handle(GetCustomerclassificationRequest request, CancellationToken cancellationToken) =>
        await _repository.GetBySpecAsync(
            (ISpecification<Customerclassification, CustomerclassificationDto>)new CustomerclassificationByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(_t["Customerclassification {0} Not Found.", request.Id]);
}