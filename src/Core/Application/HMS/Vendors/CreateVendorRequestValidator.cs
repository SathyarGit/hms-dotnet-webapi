namespace FSH.WebApi.Application.HMS.Vendors;

public class CreateVendorRequestValidator : CustomValidator<CreateVendorRequest>
{
    public CreateVendorRequestValidator(IReadRepository<Vendor> vendorRepo, IStringLocalizer<CreateVendorRequestValidator> T)
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(128)
            .MustAsync(async (name, ct) => await vendorRepo.GetBySpecAsync(new VendorByNameSpec(name), ct) is null)
                .WithMessage((_, name) => T["Vendor {0} already Exists.", name]);
    }
}