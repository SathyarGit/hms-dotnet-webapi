namespace FSH.WebApi.Application.HMS.Vendors;

public class UpdateVendorRequestValidator : CustomValidator<UpdateVendorRequest>
{
    public UpdateVendorRequestValidator(IReadRepository<Vendor> vendorRepo, IReadRepository<Brand> brandRepo, IStringLocalizer<UpdateVendorRequestValidator> T)
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(128)
            .MustAsync(async (vendor, name, ct) =>
                    await vendorRepo.GetBySpecAsync(new VendorByNameSpec(name), ct)
                        is not Vendor existingVendor || existingVendor.Id == vendor.Id)
                .WithMessage((_, name) => T["Vendor {0} already Exists.", name]);
    }
}