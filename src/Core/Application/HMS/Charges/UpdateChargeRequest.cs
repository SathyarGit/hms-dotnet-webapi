using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Charges;

public class UpdateChargeRequest : IRequest<DefaultIdType>
{
    public DefaultIdType Id { get; set; }
    public DateTime? ChargeDate { get; set; }
    public DefaultIdType FolioId { get; set; }
    public int? Amount { get; set; }
    public string? Description { get; set; }
    public DefaultIdType DepartmentId { get; set; }
    public DefaultIdType TransactionstatusId { get; set; }
    public DefaultIdType TravelagentId { get; set; }
}

public class UpdateChargeRequestHandler : IRequestHandler<UpdateChargeRequest, DefaultIdType>
{
    public readonly IRepository<Charge> _repository;
    public readonly IStringLocalizer _t;
    public readonly IFileStorageService _file;

    public UpdateChargeRequestHandler(IRepository<Charge> repository, IStringLocalizer<UpdateChargeRequestHandler> localizer, IFileStorageService file) =>
        (_repository, _t, _file) = (repository, localizer, file);

    public async Task<DefaultIdType> Handle(UpdateChargeRequest request, CancellationToken cancellationToken)
    {
        var charge = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = charge ?? throw new NotFoundException(_t["Charge {0} Not Found.", request.Id]);

        var updatedCharge = charge.Update(request.ChargeDate, request.FolioId, request.Amount, request.Description, request.DepartmentId, request.TransactionstatusId, request.TravelagentId);

        // Add Domain Events to be raised after the commit
        charge.DomainEvents.Add(EntityUpdatedEvent.WithEntity(charge));

        await _repository.UpdateAsync(updatedCharge, cancellationToken);

        return request.Id;
    }
}