namespace FSH.WebApi.Application.HMS.Expensecategories;

public class GetExpensecategoryRequest : IRequest<ExpensecategoryDto>
{
    public DefaultIdType Id { get; set; }

    public GetExpensecategoryRequest(DefaultIdType id) => Id = id;
}

public class GetExpensecategoryRequestHandler : IRequestHandler<GetExpensecategoryRequest, ExpensecategoryDto>
{
    private readonly IRepository<Expensecategory> _repository;
    private readonly IStringLocalizer _t;

    public GetExpensecategoryRequestHandler(IRepository<Expensecategory> repository, IStringLocalizer<GetExpensecategoryRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<ExpensecategoryDto> Handle(GetExpensecategoryRequest request, CancellationToken cancellationToken) =>
        await _repository.GetBySpecAsync(
            (ISpecification<Expensecategory, ExpensecategoryDto>)new ExpensecategoryByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(_t["Expensecategory {0} Not Found.", request.Id]);
}