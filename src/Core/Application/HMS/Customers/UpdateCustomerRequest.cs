using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Customers;

public class UpdateCustomerRequest : IRequest<DefaultIdType>
{
    public DefaultIdType Id { get; set; }
    public string Name { get; set; } = default!;
    public string? AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
    public string? Pincode { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? Notes { get; set; }
    public DefaultIdType CustclassificationId { get; set; }
    public bool DeleteCurrentImage { get; set; } = false;
    public FileUploadRequest? Image { get; set; }
}

public class UpdateCustomerRequestHandler : IRequestHandler<UpdateCustomerRequest, DefaultIdType>
{
    public readonly IRepository<Customer> _repository;
    public readonly IStringLocalizer _t;
    public readonly IFileStorageService _file;

    public UpdateCustomerRequestHandler(IRepository<Customer> repository, IStringLocalizer<UpdateCustomerRequestHandler> localizer, IFileStorageService file) =>
        (_repository, _t, _file) = (repository, localizer, file);

    public async Task<DefaultIdType> Handle(UpdateCustomerRequest request, CancellationToken cancellationToken)
    {
        var customer = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = customer ?? throw new NotFoundException(_t["Customer {0} Not Found.", request.Id]);

        // Remove old image if flag is set
        if (request.DeleteCurrentImage)
        {
            string? currentCustomerImagePath = customer.ImagePath;
            if (!string.IsNullOrEmpty(currentCustomerImagePath))
            {
                string root = Directory.GetCurrentDirectory();
                _file.Remove(Path.Combine(root, currentCustomerImagePath));
            }

            customer = customer.ClearImagePath();
        }

        string? customerImagePath = request.Image is not null
            ? await _file.UploadAsync<Customer>(request.Image, FileType.Image, cancellationToken)
            : null;

        var updatedCustomer = customer.Update(request.Name, request.AddressLine1, request.AddressLine2, request.City, request.Country, request.Pincode, request.PhoneNumber, request.Email, request.Notes, customerImagePath, request.CustclassificationId);

        // Add Domain Events to be raised after the commit
        customer.DomainEvents.Add(EntityUpdatedEvent.WithEntity(customer));

        await _repository.UpdateAsync(updatedCustomer, cancellationToken);

        return request.Id;
    }
}