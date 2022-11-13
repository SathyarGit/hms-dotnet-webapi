using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Purchases;

public class CreatePurchaseRequest : IRequest<DefaultIdType>
{
    public DateTime? PurchaseDate { get; set; }
    public DefaultIdType VendorId { get; set; }
    public int? Amount { get; set; }
    public string? Description { get; set; }
    public DefaultIdType DepartmentId { get; set; }
    public string? BillsOrInvoiceNumber { get; set; }
    public DefaultIdType TransactionstatusId { get; set; }
    public FileUploadRequest? Image { get; set; }
}

public class CreatePurchaseRequestHandler : IRequestHandler<CreatePurchaseRequest, DefaultIdType>
{
    private readonly IRepository<Purchase> _repository;
    private readonly IFileStorageService _file;

    public CreatePurchaseRequestHandler(IRepository<Purchase> repository, IFileStorageService file) =>
        (_repository, _file) = (repository, file);

    public async Task<DefaultIdType> Handle(CreatePurchaseRequest request, CancellationToken cancellationToken)
    {
        string purchaseImagePath = await _file.UploadAsync<Purchase>(request.Image, FileType.Image, cancellationToken);

        var purchase = new Purchase(request.PurchaseDate, request.VendorId, request.Amount, request.Description, request.DepartmentId, request.BillsOrInvoiceNumber, purchaseImagePath, request.TransactionstatusId);

        // Add Domain Events to be raised after the commit
        purchase.DomainEvents.Add(EntityCreatedEvent.WithEntity(purchase));

        await _repository.AddAsync(purchase, cancellationToken);

        return purchase.Id;
    }
}