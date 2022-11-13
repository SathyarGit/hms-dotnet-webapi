using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Accountentries;

public class CreateAccountentryRequest : IRequest<DefaultIdType>
{
    public DateTime? TransactionDate { get; set; }
    public DefaultIdType FolioId { get; set; }
    public DefaultIdType PurchaseId { get; set; }
    public DefaultIdType PaymentmodeId { get; set; }
    public DefaultIdType DepartmentId { get; set; }
    public DefaultIdType ExpensecategoryId { get; set; }
    public int? Amount { get; set; }
    public DefaultIdType TransactiontypeId { get; set; }
    public string? Description { get; set; }
}

public class CreateAccountentryRequestHandler : IRequestHandler<CreateAccountentryRequest, DefaultIdType>
{
    private readonly IRepository<Accountentry> _repository;
    private readonly IFileStorageService _file;

    public CreateAccountentryRequestHandler(IRepository<Accountentry> repository, IFileStorageService file) =>
        (_repository, _file) = (repository, file);

    public async Task<DefaultIdType> Handle(CreateAccountentryRequest request, CancellationToken cancellationToken)
    {
        var accountentry = new Accountentry(request.TransactionDate, request.FolioId, request.PurchaseId, request.PaymentmodeId, request.DepartmentId, request.ExpensecategoryId, request.Amount, request.TransactiontypeId, request.Description);

        // Add Domain Events to be raised after the commit
        accountentry.DomainEvents.Add(EntityCreatedEvent.WithEntity(accountentry));

        await _repository.AddAsync(accountentry, cancellationToken);

        return accountentry.Id;
    }
}