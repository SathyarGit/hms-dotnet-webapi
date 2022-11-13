using Mapster;

namespace FSH.WebApi.Application.HMS.Customerclassifications;

public class GetCustomerclassificationViaDapperRequest : IRequest<CustomerclassificationDto>
{
    public DefaultIdType Id { get; set; }

    public GetCustomerclassificationViaDapperRequest(DefaultIdType id) => Id = id;
}

public class GetCustomerclassificationViaDapperRequestHandler : IRequestHandler<GetCustomerclassificationViaDapperRequest, CustomerclassificationDto>
{
    private readonly IDapperRepository _repository;
    private readonly IStringLocalizer _t;

    public GetCustomerclassificationViaDapperRequestHandler(IDapperRepository repository, IStringLocalizer<GetCustomerclassificationViaDapperRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<CustomerclassificationDto> Handle(GetCustomerclassificationViaDapperRequest request, CancellationToken cancellationToken)
    {
        var customerclassification = await _repository.QueryFirstOrDefaultAsync<Customerclassification>(
            $"SELECT * FROM HMS.\"Customerclassifications\" WHERE \"Id\"  = '{request.Id}' AND \"TenantId\" = '@tenant'", cancellationToken: cancellationToken);

        _ = customerclassification ?? throw new NotFoundException(_t["Customerclassification {0} Not Found.", request.Id]);

        // Using mapster here throws a nullreference exception because of the "BrandName" property
        // in CustomerclassificationDto and the customerclassification not having a Brand assigned.
        return new CustomerclassificationDto
        {
            Id = customerclassification.Id,
            Description = customerclassification.Description,
            Name = customerclassification.Name
        };
    }
}