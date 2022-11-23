using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Customers;

public class CreateCustomerRequest : IRequest<DefaultIdType>
{
    public string Name { get; set; } = default!;
    public string? AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
    public string? Pincode { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? Notes { get; set; }
    public FileUploadRequest? Image { get; set; }
    public DefaultIdType CustomerclassificationId { get; set; }
}

public class CreateCustomerRequestHandler : IRequestHandler<CreateCustomerRequest, DefaultIdType>
{
    private readonly IRepository<Customer> _repository;
    private readonly IFileStorageService _file;

    public CreateCustomerRequestHandler(IRepository<Customer> repository, IFileStorageService file) =>
        (_repository, _file) = (repository, file);

    public async Task<DefaultIdType> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
    {
        string customerImagePath = await _file.UploadAsync<Product>(request.Image, FileType.Image, cancellationToken);

        var customer = new Customer(request.Name, request.AddressLine1, request.AddressLine2, request.City, request.Country, request.Pincode, request.PhoneNumber, request.Email, request.Notes, customerImagePath, request.CustomerclassificationId);

        // Add Domain Events to be raised after the commit
        customer.DomainEvents.Add(EntityCreatedEvent.WithEntity(customer));

        await _repository.AddAsync(customer, cancellationToken);

        return customer.Id;
    }
}