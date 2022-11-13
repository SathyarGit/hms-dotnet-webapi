using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Accountentries;

public class UpdateAccountentryRequest : IRequest<DefaultIdType>
{
    public DefaultIdType Id { get; set; }
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

public class UpdateAccountentryRequestHandler : IRequestHandler<UpdateAccountentryRequest, DefaultIdType>
{
    public readonly IRepository<Accountentry> _repository;
    public readonly IStringLocalizer _t;
    public readonly IFileStorageService _file;

    public UpdateAccountentryRequestHandler(IRepository<Accountentry> repository, IStringLocalizer<UpdateAccountentryRequestHandler> localizer, IFileStorageService file) =>
        (_repository, _t, _file) = (repository, localizer, file);

    public async Task<DefaultIdType> Handle(UpdateAccountentryRequest request, CancellationToken cancellationToken)
    {
        var accountentry = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = accountentry ?? throw new NotFoundException(_t["Accountentry {0} Not Found.", request.Id]);

        var updatedAccountentry = accountentry.Update(request.TransactionDate, request.FolioId, request.PurchaseId, request.PaymentmodeId, request.DepartmentId, request.ExpensecategoryId, request.Amount, request.TransactiontypeId, request.Description);

        // Add Domain Events to be raised after the commit
        accountentry.DomainEvents.Add(EntityUpdatedEvent.WithEntity(accountentry));

        await _repository.UpdateAsync(updatedAccountentry, cancellationToken);

        return request.Id;
    }
}