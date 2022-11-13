using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Charges;

public class CreateChargeRequest : IRequest<DefaultIdType>
{
    public DateTime? ChargeDate { get; set; }
    public DefaultIdType FolioId { get; set; }
    public int? Amount { get; set; }
    public string? Description { get; set; }
    public DefaultIdType DepartmentId { get; set; }
    public DefaultIdType TransactionstatusId { get; set; }
    public DefaultIdType TravelagentId { get; set; }
}

public class CreateChargeRequestHandler : IRequestHandler<CreateChargeRequest, DefaultIdType>
{
    private readonly IRepository<Charge> _repository;
    private readonly IFileStorageService _file;

    public CreateChargeRequestHandler(IRepository<Charge> repository, IFileStorageService file) =>
        (_repository, _file) = (repository, file);

    public async Task<DefaultIdType> Handle(CreateChargeRequest request, CancellationToken cancellationToken)
    {
        var charge = new Charge(request.ChargeDate, request.FolioId, request.Amount, request.Description, request.DepartmentId, request.TransactionstatusId, request.TravelagentId);

        // Add Domain Events to be raised after the commit
        charge.DomainEvents.Add(EntityCreatedEvent.WithEntity(charge));

        await _repository.AddAsync(charge, cancellationToken);

        return charge.Id;
    }
}