using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Purchases;

public class UpdatePurchaseRequest : IRequest<DefaultIdType>
{
    public DefaultIdType Id { get; set; }
    public DateTime? PurchaseDate { get; private set; }
    public DefaultIdType VendorId { get; private set; }
    public int? Amount { get; private set; }
    public string? Description { get; private set; }
    public DefaultIdType DepartmentId { get; private set; }
    public string? BillsOrInvoiceNumber { get; private set; }
    public DefaultIdType TransactionstatusId { get; private set; }
    public bool DeleteCurrentImage { get; set; } = false;
    public FileUploadRequest? Image { get; set; }
}

public class UpdatePurchaseRequestHandler : IRequestHandler<UpdatePurchaseRequest, DefaultIdType>
{
    public readonly IRepository<Purchase> _repository;
    public readonly IStringLocalizer _t;
    public readonly IFileStorageService _file;

    public UpdatePurchaseRequestHandler(IRepository<Purchase> repository, IStringLocalizer<UpdatePurchaseRequestHandler> localizer, IFileStorageService file) =>
        (_repository, _t, _file) = (repository, localizer, file);

    public async Task<DefaultIdType> Handle(UpdatePurchaseRequest request, CancellationToken cancellationToken)
    {
        var purchase = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = purchase ?? throw new NotFoundException(_t["Purchase {0} Not Found.", request.Id]);

        // Remove old image if flag is set
        if (request.DeleteCurrentImage)
        {
            string? currentPurchaseImagePath = purchase.ImagePath;
            if (!string.IsNullOrEmpty(currentPurchaseImagePath))
            {
                string root = Directory.GetCurrentDirectory();
                _file.Remove(Path.Combine(root, currentPurchaseImagePath));
            }

            purchase = purchase.ClearImagePath();
        }

        string? purchaseImagePath = request.Image is not null
            ? await _file.UploadAsync<Purchase>(request.Image, FileType.Image, cancellationToken)
            : null;

        var updatedPurchase = purchase.Update(request.PurchaseDate, request.VendorId, request.Amount, request.Description, request.DepartmentId, request.BillsOrInvoiceNumber, purchaseImagePath, request.TransactionstatusId);

        // Add Domain Events to be raised after the commit
        purchase.DomainEvents.Add(EntityUpdatedEvent.WithEntity(purchase));

        await _repository.UpdateAsync(updatedPurchase, cancellationToken);

        return request.Id;
    }
}