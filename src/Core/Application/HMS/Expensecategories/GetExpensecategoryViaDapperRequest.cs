using Mapster;

namespace FSH.WebApi.Application.HMS.Expensecategories;

public class GetExpensecategoryViaDapperRequest : IRequest<ExpensecategoryDto>
{
    public DefaultIdType Id { get; set; }

    public GetExpensecategoryViaDapperRequest(DefaultIdType id) => Id = id;
}

public class GetExpensecategoryViaDapperRequestHandler : IRequestHandler<GetExpensecategoryViaDapperRequest, ExpensecategoryDto>
{
    private readonly IDapperRepository _repository;
    private readonly IStringLocalizer _t;

    public GetExpensecategoryViaDapperRequestHandler(IDapperRepository repository, IStringLocalizer<GetExpensecategoryViaDapperRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<ExpensecategoryDto> Handle(GetExpensecategoryViaDapperRequest request, CancellationToken cancellationToken)
    {
        var roomtype = await _repository.QueryFirstOrDefaultAsync<Expensecategory>(
            $"SELECT * FROM HMS.\"Expensecategories\" WHERE \"Id\"  = '{request.Id}' AND \"TenantId\" = '@tenant'", cancellationToken: cancellationToken);

        _ = roomtype ?? throw new NotFoundException(_t["Expensecategory {0} Not Found.", request.Id]);

        // Using mapster here throws a nullreference exception because of the "BrandName" property
        // in ExpensecategoryDto and the roomtype not having a Brand assigned.
        return new ExpensecategoryDto
        {
            Id = roomtype.Id,
            Description = roomtype.Description,
            Name = roomtype.Name
        };
    }
}